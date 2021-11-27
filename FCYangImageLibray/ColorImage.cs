using System;
using System.Drawing;
using System.Threading.Tasks;

namespace FCYangImageLibray
{
    public class ColorImage
    {


        #region Overloaded Operators

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

        #endregion

        #region Public Utility Functions

        public MonoImage[] GetRGBPlaneImages()
        {
            MonoImage[ ] rgbPlanes = new MonoImage[ 3 ];
            int[ ][ , ] planes = new int[ 3 ][ , ];
            for( int i = 0 ; i < 3 ; i++ )
            {
                planes[ i ] = new int[ height, width ];
                for( int r = 0 ; r < height ; r++ )
                    for( int c = 0 ; c < width ; c++ )
                        planes[ i ][ r, c ] = pixels[ i, r, c ];
                rgbPlanes[ i ] = new MonoImage( planes[ i ] );
            }
            return rgbPlanes;
        }

        public MonoImage[ ] GetCMYPlaneImages( )
        {
            MonoImage[ ] cmyPlanes = new MonoImage[ 3 ];
            int[ ][ , ] planes = new int[ 3 ][ , ];
            for( int i = 0 ; i < 3 ; i++ )
            {
                planes[ i ] = new int[ height, width ];
                for( int r = 0 ; r < height ; r++ )
                    for( int c = 0 ; c < width ; c++ )
                    {
                        planes[ i ][ r, c ] = 255 - pixels[ i, r, c ];
                    }
                cmyPlanes[ i ] = new MonoImage( planes[ i ] );
            }
            return cmyPlanes;
        }

        double[ ] rgb = new double[ 3 ];
        double[ ] hsi = new double[ 3 ];
        public MonoImage[ ] GetHSIPlaneImages( )
        {
            MonoImage[ ] hsiPlanes = new MonoImage[ 3 ];
            int[ ][ , ] planes = new int[ 3 ][ , ];
            for( int i = 0 ; i < 3 ; i++ )
            {
                planes[ i ] = new int[ height, width ];
            }

            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                {
                    //pixels[ 0, r, c ] = 255;
                    //pixels[ 1, r, c ] = pixels[ 2, r, c ] = 0;
                    double total = pixels[ 0, r, c ] + pixels[ 1, r, c ] + pixels[ 2, r, c ];
                    if( total == 0 )
                    {
                        planes[ 0 ][ r, c ] = 256 / 4; // 90 degree;
                        planes[ 1 ][ r, c ] = 
                        planes[ 2 ][ r, c ] = 0;
                    }
                    else
                    {
                        // Intensity
                        planes[ 2 ][ r, c ] = (int) (  total / 3.0 );

                        //  Saturation 
                        double temp;
                        if( pixels[ 0, r, c ] < pixels[ 1, r, c ] ) 
                            temp = pixels[ 0, r, c ];
                        else 
                            temp = pixels[ 1, r, c ];
                        if( pixels[ 2, r, c ] < temp ) temp = pixels[ 2, r, c ];
                        planes[ 1 ][ r, c ] = 255 * (int) ( 1.0 - 3 * temp / total );
                        // Hue
                        double rmb = pixels[ 0, r, c ] - pixels[ 2, r, c ];
                        double rmg = pixels[ 0, r, c ] - pixels[ 1, r, c ];
                        if( rmb == 0 && rmg == 0 ) planes[ 0 ][ r, c ] = 256 / 4;
                        else
                        {
                            temp = 0.5 * ( rmg + rmb ) / Math.Sqrt( rmg * rmg + rmb * ( pixels[ 1, r, c ] - pixels[ 2, r, c ] ) );
                            temp = Math.Acos( temp ) * 180.0 / Math.PI;
                            if( temp < 0 )
                                temp = 360.0 + temp;
                            if( pixels[ 2, r, c ] > pixels[ 1, r, c ] )
                                planes[ 0 ][ r, c ] = (int) ( 255 * ( 360.0 - temp ) / 360.0 );
                            else
                                planes[ 0 ][ r, c ] = (int) ( 255 * ( temp ) / 360.0 );
                        }
                    }
                }
            for( int i = 0 ; i < 3 ; i++ )
            {
                hsiPlanes[ i ] = new MonoImage( planes[ i ] );
            }
            return hsiPlanes;
        }

        //public static double[ ] SetRGBToHSI( int r, int g, int b )
        //{

      //  HSI, XYZ, L* a*b*, YUV
        //    Red = r; Green = g; Blue = b;
        //    int min = Red;
        //    if( Green < min ) min = Green;
        //    if( Blue < min ) min = Blue;
        //    Saturation = 1.0 - 3.0 * min / ( Red + Green + Blue );
        //    int RmG = Red - Green;
        //    int RmB = Red - Blue;
        //    int GmB = Green - Blue;
        //    Hue = Math.Acos( 0.5 * ( RmG + RmB ) / Math.Sqrt( RmG * RmG + RmB * GmB ) ) * 180.0 / Math.PI;
        //    if( Hue < 0 ) Hue += 360;
        //    if( Blue > Green ) Hue = 360 - Hue;

        //    Intensity = ( Red + Green + Blue ) / 3.0;
        //    HSI[ 0 ] = Hue;
        //    HSI[ 1 ] = Saturation;
        //    HSI[ 2 ] = Intensity;
        //    return HSI;
        //}

        #endregion

        public Bitmap displayedBitmap;
        public int height; 
        public int width; 
        public  int[,,] pixels;
        double[,] histograms;

        #region CONSTRUCTORS

        public ColorImage( string imageFilePath )
        {
            displayedBitmap = new Bitmap( imageFilePath );
            SetPixelsFromImage( );
        }
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



    }
}
