using System;
using System.Drawing;
using System.Threading.Tasks;

namespace FCYangImageLibray
{
    public enum ColorModel
    {
        RGB, HSI, LAB
    }

    public class ColorImage
    {
        static Random[] randomizers = new Random[3];

        static ColorImage()
        {
            for (int i = 0; i < randomizers.Length; i++)
                randomizers[i] = new Random(Guid.NewGuid().GetHashCode());
        }

        #region Overloaded Operators

        public static double[,,] operator +(double[,] mask, ColorImage img)
        {
            double[,,] pixels = new double[3, img.height, img.width];

            int hhh = mask.GetLength(0);
            int www = mask.GetLength(1);
            for (int d = 0; d < 3; d++)
                for (int r = 0; r < img.height; r++)
                {
                    for (int c = 0; c < img.width; c++)
                    {
                        pixels[d, r, c] = 0;
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
                        pixels[d, r, c] = (int)(img1.pixels[d, r, c] - img2.pixels[d, r, c]);
                        if (pixels[d, r, c] > 255) pixels[d, r, c] = 255;
                        else if (pixels[d, r, c] < 0) pixels[d, r, c] = 0;
                    }
                }
            return new ColorImage(pixels);
        }

        #endregion

        #region Public Utility Functions

        public MonoImage CreateAverageMonoImage()
        {
            int[,] mono = new int[height, width];
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                    mono[r, c] = (int)((pixels[0, r, c] + pixels[1, r, c] + pixels[2, r, c]) / 3.0);
            return new MonoImage(mono);
        }

        public MonoImage[] GetRGBPlaneImages()
        {
            MonoImage[] rgbPlanes = new MonoImage[3];
            int[][,] planes = new int[3][,];
            for (int i = 0; i < 3; i++)
            {
                planes[i] = new int[height, width];
                for (int r = 0; r < height; r++)
                    for (int c = 0; c < width; c++)
                        planes[i][r, c] = pixels[i, r, c];
                rgbPlanes[i] = new MonoImage(planes[i]);
            }
            return rgbPlanes;
        }

        public MonoImage[] GetCMYPlaneImages()
        {
            MonoImage[] cmyPlanes = new MonoImage[3];
            int[][,] planes = new int[3][,];
            for (int i = 0; i < 3; i++)
            {
                planes[i] = new int[height, width];
                for (int r = 0; r < height; r++)
                    for (int c = 0; c < width; c++)
                    {
                        planes[i][r, c] = 255 - pixels[i, r, c];
                    }
                cmyPlanes[i] = new MonoImage(planes[i]);
            }
            return cmyPlanes;
        }

        double[] rgb = new double[3];
        double[] hsi = new double[3];
        public MonoImage[] GetHSIPlaneImages()
        {
            MonoImage[] hsiPlanes = new MonoImage[3];
            int[][,] planes = new int[3][,];
            for (int i = 0; i < 3; i++)
            {
                planes[i] = new int[height, width];
            }

            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    //pixels[ 0, r, c ] = 255;
                    //pixels[ 1, r, c ] = pixels[ 2, r, c ] = 0;
                    double total = pixels[0, r, c] + pixels[1, r, c] + pixels[2, r, c];
                    if (total == 0)
                    {
                        planes[0][r, c] = 256 / 4; // 90 degree;
                        planes[1][r, c] =
                        planes[2][r, c] = 0;
                    }
                    else
                    {
                        // Intensity
                        planes[2][r, c] = (int)(total / 3.0);

                        //  Saturation 
                        double temp;
                        if (pixels[0, r, c] < pixels[1, r, c])
                            temp = pixels[0, r, c];
                        else
                            temp = pixels[1, r, c];
                        if (pixels[2, r, c] < temp) temp = pixels[2, r, c];
                        planes[1][r, c] = 255 * (int)(1.0 - 3 * temp / total);
                        // Hue
                        double rmb = pixels[0, r, c] - pixels[2, r, c];
                        double rmg = pixels[0, r, c] - pixels[1, r, c];
                        if (rmb == 0 && rmg == 0) planes[0][r, c] = 256 / 4;
                        else
                        {
                            temp = 0.5 * (rmg + rmb) / Math.Sqrt(rmg * rmg + rmb * (pixels[1, r, c] - pixels[2, r, c]));
                            temp = Math.Acos(temp) * 180.0 / Math.PI;
                            if (temp < 0)
                                temp = 360.0 + temp;
                            if (pixels[2, r, c] > pixels[1, r, c])
                                planes[0][r, c] = (int)(255 * (360.0 - temp) / 360.0);
                            else
                                planes[0][r, c] = (int)(255 * (temp) / 360.0);
                        }
                    }
                }
            for (int i = 0; i < 3; i++)
            {
                hsiPlanes[i] = new MonoImage(planes[i]);
            }
            return hsiPlanes;
        }




        int[,] segmentationIDs;



        private double[,,] GetRGBData()
        {
            double[,,] data = new double[3, height, width];
            for (int d = 0; d < 3; d++)
                for (int r = 0; r < height; r++)
                    for (int c = 0; c < width; c++)
                        data[d, r, c] = pixels[d, r, c] / 255.0;
            return data;
        }
        
        private double[,,] GetHSIData()
        {
            double[,,] data = GetRGBData();
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    double total = data[ 0, r, c] + data[1, r, c] + data[2, r, c];
                    double min = data[0, r, c] > data[1, r, c] ? data[1, r, c] : data[0, r, c];
                    if (data[2, r, c] < min) min = data[2, r, c];
                    double rmb = data[0, r, c] - data[2, r, c];
                    double rmg = data[0, r, c] - data[1, r, c];
                    double gmb = data[1, r, c] - data[2, r, c];
                    if ( total == 0 )
                    {
                        data[0, r, c] = 0.0;
                        data[1, r, c] = 1.0;
                        data[2, r, c] = 0.0;
                    }
                    else
                    {
                        if( rmg == 0 && ( rmb ==0 || gmb == 0)) data[0, r, c] = 0.0;
                        else
                        {
                            double temp = 0.5 * (rmg + rmb) / Math.Sqrt(rmg * rmg + rmb * gmb);
                            temp = Math.Acos(temp);
                            if (temp < 0) temp = 2 * Math.PI - temp;
                            if (gmb < 0) temp = 2 * Math.PI - temp;
                            data[0, r, c] = temp; 
                        }
                        data[1, r, c] = 3.0 * min / total;
                        data[2, r, c] = total / 3.0;
                    }

                    data[2, r, c] = total / 3.0;
                }
            return data;
        }


        private double[,,] GetLABData()
        {
            throw new NotImplementedException();
        }

        public ColorImage CreateRGBSegmentationImage(int k)
        {
            return CreateSegmentationImage(k, GetRGBData(), new double[] { 1.0, 1.0, 1.0 }, ColorModel.RGB);
        }

        public ColorImage CreateHSISegmentationImage(int k)
        {
         
            double[,,] data = GetHSIData();
            double[] maxs = new double[3];
            double[] mins = new double[3];
            for (int d = 0; d < 3; d++)
            {
                maxs[d] = double.MinValue;
                mins[d] = double.MaxValue;
                for (int r = 0; r < height; r++)
                    for (int c = 0; c < width; c++)
                    {
                        if (data[d, r, c] > maxs[d]) maxs[d] = data[d, r, c];
                        else if (data[d, r, c] < mins[d]) mins[d] = data[d, r, c];
                    }
            }
            return CreateSegmentationImage(k, data, new double[] { Math.PI * 2, 1.0, 1.0 }, ColorModel.HSI);
            //double[,,] HSIData = CreateSegmentationImage(k, data, new double[] { Math.PI * 2, 1.0, 1.0 });
            //return new ColorImage(HSIData, ColorModel.HSI);

        }

        public ColorImage CreateLABSegmentationImage(int k)
        {
            return CreateSegmentationImage(k, GetLABData(), new double[] { 1.0, 1.0, 1.0 }, ColorModel.LAB);
        }

 
         ColorImage CreateSegmentationImage(int k, double[,,] array, double[] limits, ColorModel mode)
        {
            double[,] centers = new double[k, 3];
            Color[] centerColors = new Color[k];
            int[] cnts = new int[k];

            for (int r = 0; r < k; r++)
            {
                cnts[r] = 0;
                for (int c = 0; c < 3; c++)
                    centers[r, c] = randomizers[c].NextDouble()*limits[c];
            }

            if (segmentationIDs == null || segmentationIDs.GetLength(0) != height || segmentationIDs.GetLength(1) != width )
            {
                // allocate memeory
                segmentationIDs = new int[height, width];
            }

            // Clustering 
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    double min = double.MaxValue;
                    int minID = -1;
                    //        // loop throught each cluster
                    for (int i = 0; i < k; i++)
                    {
                        double dx = array[0, r, c] - centers[i, 0], dy = array[1, r, c] - centers[i, 1], dz = array[2, r, c] - centers[i, 2];
                        double dis = dx * dx + dy * dy + dz * dz;
                        if (dis < min)
                        {
                            minID = i;
                            min = dis;
                        }
                    }
                    segmentationIDs[r, c] = minID;
                    // cluster to cluster minID then adjust the center
                    for (int j = 0; j < 3; j++)
                        centers[minID, j] = (centers[minID, j] * cnts[minID] + array[j, r, c]) / (cnts[minID] + 1);
                    cnts[minID]++;
                }
            }

            // Transfrom centers back to RGB colors
            for( int j = 0; j < k; j ++)
            {
                int R=0, G=0, B=0;

                switch (mode)
                {
                    case ColorModel.RGB:
                        R = (int)(256 * centers[j, 0]);
                        G = (int)(256 * centers[j, 1]);
                        B = (int)(256 * centers[j, 2]);
                        break;
                    case ColorModel.HSI:
                        double temp = 120.0 * Math.PI / 180.0;
                        double hue = centers[j, 0];
                        R = (int)(256 * centers[j, 0]);
                        G = (int)(256 * centers[j, 1]);
                        B = (int)(256 * centers[j, 2]);
                        break;
                    case ColorModel.LAB:
                        break;
                }


                centerColors[j] = Color.FromArgb(R, G, B);
            }

            int[,,] segmentatedData = new int[3, height, width];
            // Create a new color image
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    int tid = segmentationIDs[r, c];
                    segmentatedData[0, r, c] = centerColors[tid].R;
                    segmentatedData[1, r, c] = centerColors[tid].G;
                    segmentatedData[2, r, c] = centerColors[tid].B;
                }

            //// Create a new color image
            //int[,,] segmentatedPixels = new int[3, height, width];
            //for( int r = 0; r < height; r++)
            //    for( int c = 0; c < width; c++)
            //    {
            //        int tid = segmentationIDs[r, c];
            //        for(int j = 0; j < 3; j++) segmentatedPixels[j, r, c] = (int)centers[tid, j];
            //    }
            return new ColorImage( segmentatedData );
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

        public ColorImage(double[,,] data, ColorModel model)
        {
            height = data.GetLength(1);
            width = data.GetLength(2);
            pixels = new int[3, height, width];
            switch (model)
            {
                case ColorModel.RGB:
                    for (int d = 0; d < 3; d++)
                        for (int r = 0; r < height; r++)
                            for (int c = 0; c < width; c++)
                                pixels[d, r, c] = (int)(256 * data[d, r, c]);
                    break;
                case ColorModel.HSI:
                    double sixtyDegree = Math.PI / 3.0;
                    for (int d = 0; d < 3; d++)
                    {
                        for (int r = 0; r < height; r++)
                        {
                            for (int c = 0; c < width; c++)
                            {
                                double red, green, blue;
                                blue = data[2, r, c] * (1.0 - data[1, r, c]);
                                red = data[2, r, c] * (1.0 + data[1, r, c] * Math.Cos(data[0, r, c]) / Math.Cos(sixtyDegree - data[0, r, c]));
                                green = 3.0 * data[2, r, c] - red - blue;
                                pixels[0, r, c] = red == 1.0 ? 255 : (int)(256 * red);
                                pixels[1, r, c] = green == 1.0 ? 255 : (int)(256 * green);
                                pixels[2, r, c] = blue == 1.0 ? 255 : (int)(256 * blue);
                            }
                        }
                    }
                    break;
                case ColorModel.LAB:
                    break;
            }
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
