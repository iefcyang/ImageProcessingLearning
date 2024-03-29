﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021HWK03
{
    public class ColorImage
    {
        public static double[,,] operator +(double[,] mask, ColorImage img)
        {
            double[,,] pixels = new double[3,img.height, img.width];
            
            int hhh = mask.GetLength(0);
            int www = mask.GetLength(1);
            for( int d = 0; d < 3; d++ )
            for (int r = 0; r < img.height; r++)
            {
                for (int c = 0; c < img.width; c++)
                {
                    pixels[d,r, c] = 0;
                    for (int h = 0, y = r - hhh / 2; h < hhh; h++, y++)
                    {
                        for (int w = 0, x = c - www / 2; w < www; w++, x++)
                        {
                            if (x < 0 || x >= img.width) continue;
                            if (y < 0 || y >= img.height) continue;
                                pixels[d, r, c] += mask[h, w] * img.pixels[d, y, x];
                        }
                    }
                }
            }
            return pixels;
        }

        // Parallel operation 
        public static ColorImage operator *(Mask msk, ColorImage img)
        {
            int[,,] pixels = new int[3, img.height, img.width];
            Parallel.For(0, 3, (d) =>
              {
                  for (int r = 0; r < img.height; r++)
                  {
                      for (int c = 0; c < img.width; c++)
                      {
                          double net = 0;
                          for (int h = 0, y = r - msk.height / 2; h < msk.height; h++, y++)
                          {
                              for (int w = 0, x = c - msk.width / 2; w < msk.width; w++, x++)
                              {
                                  if (x < 0 || x >= img.width) continue;
                                  if (y < 0 || y >= img.height) continue;
                                  net += msk.weights[h, w] * img.pixels[d, y, x];
                              }
                          }
                          int pxl = (int)(net / msk.total);
                          if (pxl > 255) pxl = 255;
                          else if (pxl < 0) pxl = 0;
                          pixels[d, r, c] = pxl;
                      }
                  }
              });
            return new ColorImage(pixels);
        }


        public static ColorImage operator +(Mask msk, ColorImage img)
        {
            int[,,] pixels = new int[3, img.height, img.width];
            for (int d = 0; d < 3; d++)
            {
                for (int r = 0; r < img.height; r++)
                {
                    for (int c = 0; c < img.width; c++)
                    {
                        double net = 0;
                        for (int h = 0, y = r - msk.height / 2; h < msk.height; h++, y++)
                        {
                            for (int w = 0, x = c - msk.width / 2; w < msk.width; w++, x++)
                            {
                                if (x < 0 || x >= img.width) continue;
                                if (y < 0 || y >= img.height) continue;
                                net += msk.weights[h, w] * img.pixels[d, y, x];
                            }
                        }
                        int pxl = (int)(net / msk.total);
                        if (pxl > 255) pxl = 255;
                        else if (pxl < 0) pxl = 0;
                        pixels[d, r, c] = pxl;
                    }
                }
            }
            return new ColorImage(pixels);
        }



        public static ColorImage operator +(ColorImage img1, ColorImage img2)
        {
            int[,,] pixels = new int[3, img1.height, img1.width];
            for (int d = 0; d < 3; d++)
                for (int r = 0; r < img1.height; r++)
                {

                    for (int c = 0; c < img1.width; c++)
                    {
                        pixels[d, r, c] = (int)(img1.pixels[d, r, c] + img2.pixels[d, r, c] / 2.0);
                        if (pixels[d, r, c] > 255) pixels[d, r, c] = 255;
                        else if (pixels[d, r, c] < 0) pixels[d, r, c] = 0;
                    }
                }
            return new ColorImage(pixels);
        }

        public static ColorImage operator -(ColorImage img1, ColorImage img2)
        {
            int[,,] pixels = new int[3, img1.height, img1.width];
            for (int d = 0; d < 3; d++)
                for (int r = 0; r < img1.height; r++)
                {

                    for (int c = 0; c < img1.width; c++)
                    {
                        pixels[d, r, c] = (int)(img1.pixels[d, r, c] - img2.pixels[d, r, c] ) ;
                        if (pixels[d, r, c] > 255) pixels[d, r, c] = 255;
                        else if (pixels[d, r, c] < 0) pixels[d, r, c] = 0;
                    }
                }
            return new ColorImage(pixels);
        }

        //public static ColorImage operator -(ColorImage img1, ColorImage img2)
        //{
        //    int[,,] pixels = new int[3, img1.height, img1.width];
        //    for (int d = 0; d < 3; d++)
        //        for (int r = 0; r < img1.height; r++)
        //            for (int c = 0; c < img1.width; c++)
        //            {
        //                pixels[d, r, c] = (int)(img1.pixels[d, r, c] - img2.pixels[d, r, c]));
        //             }

        //    if (pixels[d, r, c] > 255) pixels[d, r, c] = 255;
        //    else if (pixels[d, r, c] < 0) pixels[d, r, c] = 0;

        //    return new ColorImage(pixels);
        //}



        public Bitmap displayedBitmap;
        public int height; 
        public int width; 
        public  int[,,] pixels;
        double[,] histograms;

        #region HELPING FUNCTIONS

        void SetPixelsFromImage()
        {
            if (displayedBitmap == null) return;

            histograms = new double[3, 256];
            for (int d = 0; d < 3; d++)
                for (int i = 0; i < 256; i++) histograms[d, i] = 0;
            height = displayedBitmap.Height;
            width = displayedBitmap.Width;
            pixels = new int[3,height , width];
            for (int r = 0; r < displayedBitmap.Height; r++)
                for (int c = 0; c < displayedBitmap.Width; c++)
                {
                    Color clr = displayedBitmap.GetPixel(c, r);
                    pixels[0, r, c] = clr.R;
                    pixels[1, r, c] = clr.G;
                    pixels[2, r, c] = clr.B;
                    histograms[0, clr.R] += 1;
                    histograms[1, clr.G] += 1;
                    histograms[2, clr.B] += 1;
                }
            int total = displayedBitmap.Height * displayedBitmap.Width;
            for (int d = 0; d < 3; d++)
                for (int i = 0; i < 256; i++) histograms[d, i] /= total;
        }

        void SetImageFromPixels( )
        {
            if (pixels == null ) return;

            width = pixels.GetLength(2);
            height = pixels.GetLength(1);
            if (displayedBitmap == null || displayedBitmap.Width != width||
                displayedBitmap.Height != height || pixels.GetLength(0) != 3)
                displayedBitmap = new Bitmap( width, height);
            if (histograms == null)
                histograms = new double[3, 256];

            for (int r = 0; r < displayedBitmap.Height; r++)
                for (int c = 0; c < displayedBitmap.Width; c++)
                {
                    Color clr = Color.FromArgb(pixels[0, r, c], pixels[1, r, c], pixels[2, r, c]);
                    displayedBitmap.SetPixel(c, r, clr);
                    histograms[0, clr.R] += 1;
                    histograms[1, clr.G] += 1;
                    histograms[2, clr.B] += 1;
                }
        }

        #endregion


        #region CONSTRUCTORS


        /// <summary>
        ///  Create a color image form a given bitmap.
        /// </summary>
        /// <param name="originalImage"></param>
        public ColorImage( Bitmap originalImage )
        {
            displayedBitmap = originalImage;
            SetPixelsFromImage();
        }


        /// <summary>
        ///  Create a color image from given pixel data
        /// </summary>
        /// <param name="data"></param>
        public ColorImage(int[,,] data )
        {
            pixels = data;
            SetImageFromPixels();
        }

        #endregion
    }
}
