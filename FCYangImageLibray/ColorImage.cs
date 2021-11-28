using System;
using System.Drawing;
using System.Threading.Tasks;

namespace FCYangImageLibray
{
    public enum ColorModel
    {
        RGB, HSI, LAB, XYZ, CMY, YUV
    }

    public class ColorImage
    {

        #region static data, functions, overloaded operators

        static Random[] randomizers = new Random[3];

        static ColorImage()
        {
            for (int i = 0; i < randomizers.Length; i++)
                randomizers[i] = new Random(Guid.NewGuid().GetHashCode());
        }


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

        public MonoImage[] GetPlaneImages( ColorModel mode )
        {
            double[,,] data = null;
            switch( mode )
            {
                case ColorModel.XYZ:
                    data = GetXYZData();
                    break;
                case ColorModel.RGB:
                    data = GetRGBData();
                    break;
                case ColorModel.HSI:
                    data = GetHSIData();
                    break;
                case ColorModel.LAB:
                    data = GetLABData();
                    break;
                case ColorModel.CMY:
                    data = GetCMYData();
                    break;
                case ColorModel.YUV:
                    data = GetYUVData();
                    break;                    
            }
            MonoImage[] planeImages = new MonoImage[3];
            double[] ranges = new double[3];
            double[] mins = new double[3];
            for (int d = 0; d < 3; d++)
            {
                ranges[d] = double.MinValue;
                mins[d] = double.MaxValue;
                for (int r = 0; r < height; r++)
                    for (int c = 0; c < width; c++)
                    {
                        if (data[d, r, c] < mins[d]) mins[d] = data[d, r, c];
                        else if (data[d, r, c] > ranges[d]) ranges[d] = data[d, r, c];
                    }
            }

            int[][,] planes = new int[3][,];
            for (int i = 0; i < 3; i++)
            {
                planes[i] = new int[height, width];
                ranges[i] = ranges[i] - mins[i];
            }

            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    planes[0][r, c] = (int)(255 * (data[0, r, c] - mins[0]) / ranges[0]);
                    planes[1][r, c] = (int)(255 * (data[1, r, c] - mins[1]) / ranges[1]);
                    planes[2][r, c] = (int)(255 * (data[2, r, c] - mins[2]) / ranges[2]);
                }
            for (int i = 0; i < 3; i++)
            {
                planeImages[i] = new MonoImage(planes[i]);
            }
            return planeImages;
        }

        #endregion


        int[,] segmentationIDs;
        public Bitmap displayedBitmap;
        public int height;
        public int width;
        public int[,,] pixels;
        double[,] histograms;


        #region Convert Pixels to Different Color Model 

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

        private double[,,] GetXYZData()
        {
            double[,,] data = GetRGBData();
            // Transform RGB to XYZ
            // D65/2°
            // --------- RGB to XYZ ---------//
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    double red = data[0, r, c];
                    double green = data[1, r, c];
                    double blue = data[2, r, c];

                    if (red > 0.04045)
                        red = Math.Pow((red + 0.055) / 1.055, 2.4);
                    else
                        red = red / 12.92;

                    if (green > 0.04045)
                        green = Math.Pow((green + 0.055) / 1.055, 2.4);
                    else
                        green = green / 12.92;

                    if (blue > 0.04045)
                        blue = Math.Pow((blue + 0.055) / 1.055, 2.4);
                    else
                        blue = blue / 12.92;

                    red *= 100;
                    green *= 100;
                    blue *= 100;
                    data[0,r,c] = 0.4124 * red + 0.3576 * green + 0.1805 * blue;
                    data[1, r, c] = 0.2126 * red + 0.7152 * green + 0.0722 * blue;
                    data[2, r, c] = 0.0193 * red + 0.1192 * green + 0.9505 * blue;

                }

            return data;
        }

        private double[,,] GetLABData()
        {
            // Transform RGB to XYZ
            // D65/2°
            double Xr = 95.047;
            double Yr = 100.0;
            double Zr = 108.883;

            double[,,] data = GetXYZData();

            // --------- XYZ to Lab --------- //
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    double red = data[0,r,c] / Xr;
                    double green = data[1, r, c] / Yr;
                    double blue = data[2, r, c] / Zr;

                    if (red > 0.008856)
                        red = (float)Math.Pow(red, 1 / 3.0);
                    else
                        red = (float)((7.787 * red) + 16 / 116.0);

                    if (green > 0.008856)
                        green = (float)Math.Pow(green, 1 / 3.0);
                    else
                        green = (float)((7.787 * green) + 16 / 116.0);

                    if (blue > 0.008856)
                        blue = (float)Math.Pow(blue, 1 / 3.0);
                    else
                        blue = (float)((7.787 * blue) + 16 / 116.0);

                    data[0,r,c] =  ( (116 * green) - 16 ) /100.0;
                    data[1, r, c] = ( 500 * (red - green) ) / 100.0;
                    data[2, r, c] = ( 200 * (green - blue) ) / 100.0;
                }

            return data;
        }

        private double[,,] GetCMYData()
        {
            double[,,] data = new double[3, height, width];
            for (int d = 0; d < 3; d++)
                for (int r = 0; r < height; r++)
                    for (int c = 0; c < width; c++)
                        data[d, r, c] =  1.0 - pixels[d, r, c] / 255.0;
            return data;
        }

        private double[,,] GetYUVData()
        {
            double[,,] data = new double[3, height, width];
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    double red = pixels[0, r, c] / 255.0;
                        double green = pixels[1, r, c] / 255.0;
                    double blue = pixels[2, r, c] / 255.0;
                    data[0, r, c] = 0.299 * red + 0.587 * green + 0.114 * blue;
                    data[1, r, c] = -0.169 * red - 0.331 * green + 0.5 * blue + 0.5;
                    data[2, r, c] = 0.5 * red - 0.419 * green - 0.081 * blue + 0.5;
                }
            return data;
        }

        #endregion



        #region Create Segmentation Images

        public ColorImage CreateRGBSegmentationImage(int k)
        {
            return CreateSegmentationImage(k, GetRGBData(), new double[] { 1.0, 1.0, 1.0 }, ColorModel.RGB);
        }

        public ColorImage CreateHSISegmentationImage(int k)
        {
         
            double[,,] data = GetHSIData();
            //double[] maxs = new double[3];
            //double[] mins = new double[3];
            //for (int d = 0; d < 3; d++)
            //{
            //    maxs[d] = double.MinValue;
            //    mins[d] = double.MaxValue;
            //    for (int r = 0; r < height; r++)
            //        for (int c = 0; c < width; c++)
            //        {
            //            if (data[d, r, c] > maxs[d]) maxs[d] = data[d, r, c];
            //            else if (data[d, r, c] < mins[d]) mins[d] = data[d, r, c];
            //        }
            //}
            return CreateSegmentationImage(k, data, new double[] { Math.PI * 2, 1.0, 1.0 }, ColorModel.HSI);

        }

        public ColorImage CreateLABSegmentationImage(int k)
        {
            double[,,] data = GetLABData();
            double[] limits = new double[3];
            for (int d = 0; d < 3; d++)
            {
                limits[d] = double.MinValue;
                for (int r = 0; r < height; r++)

                    for (int c = 0; c < width; c++)
                    {
                        if (data[d, r, c] > limits[d]) limits[d] = data[d, r, c];
                    }
            }
            limits[0] = limits[2] = limits[1] = 1.0;
            return CreateSegmentationImage(k, data, limits, ColorModel.LAB);
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
                double red, green, blue;

                switch (mode)
                {
                    case ColorModel.RGB:
                        R = (int)(256 * centers[j, 0]);
                        G = (int)(256 * centers[j, 1]);
                        B = (int)(256 * centers[j, 2]);
                        break;
                    case ColorModel.HSI:
                        double Sixty =  Math.PI / 3.0;
                        double hue = centers[j, 0];
                        if (hue < 2 * Sixty)
                        {
                            blue =  centers[j, 2] * (1.0 - centers[j, 1]);
                            red = centers[j, 2] * (1.0 + centers[j, 1] * Math.Cos(hue) / Math.Cos(Sixty - hue));
                            green = 3 * centers[j, 2] - red - blue;
                        }
                        else
                        {
                            if(hue < 4 * Sixty)
                            {
                                hue -= 2 * Sixty;
                                red = centers[j, 2] * (1.0 - centers[j, 1]);
                                green = centers[j, 2] * (1.0 + centers[j, 1] * Math.Cos(hue) / Math.Cos(Sixty - hue));
                                blue = 3 * centers[j, 2] - red - green;
                            }
                            else
                            {
                                hue -= 4 * Sixty;
                                green = centers[j, 2] * (1.0 - centers[j, 1]);
                                blue = centers[j, 2] * (1.0 + centers[j, 1] * Math.Cos(hue) / Math.Cos(Sixty - hue));
                                red = 3 * centers[j, 2] - blue - green;
                            }
                        }
                        R = (int)(256 * red);
                        G = (int)(256 * green);
                        B = (int)(256 * blue);
                        break;
                    case ColorModel.LAB:
                        double L=  centers[j, 0] * 100;
                        double a = centers[j,  1] * 100;
                        double b = centers[j, 2] * 100;
                        double X, Y, Z, fX, fY, fZ;

                        fY = Math.Pow((L + 16.0) / 116.0, 3.0);
                        if (fY < 0.008856)
                            fY = L / 903.3;
                        Y = fY;

                        if (fY > 0.008856)
                            fY = Math.Pow(fY, 1.0 / 3.0);
                        else
                            fY = 7.787 * fY + 16.0 / 116.0;

                        fX = a / 500.0 + fY;
                        if (fX > 0.206893)
                            X = Math.Pow(fX, 3.0);
                        else
                            X = (fX - 16.0 / 116.0) / 7.787;

                        fZ = fY - b / 200.0;
                        if (fZ > 0.206893)
                            Z = Math.Pow(fZ, 3.0);
                        else
                            Z = (fZ - 16.0 / 116.0) / 7.787;

                        X *= (0.950456 * 255);
                        Y *= 255;
                        Z *= (1.088754 * 255);

                        R = (int)(3.240479 * X - 1.537150 * Y - 0.498535 * Z + 0.5);
                        G = (int)(-0.969256 * X + 1.875992 * Y + 0.041556 * Z + 0.5);
                        B = (int)(0.055648 * X - 0.204043 * Y + 1.057311 * Z + 0.5);

                        break;
                }

                R = R < 0 ? 0 : R > 255 ? 255 : R;
                G = G < 0 ? 0 : G > 255 ? 255 : G;
                B = B < 0 ? 0 : B > 255 ? 255 : B;

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

            return new ColorImage( segmentatedData );
        } 

        #endregion



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
                    // to be continued
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
