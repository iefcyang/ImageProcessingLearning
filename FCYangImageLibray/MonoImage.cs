using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace FCYangImageLibray
{
    public enum OrderStatisticsMode
    {
        Median, Min, Max
    }
    public enum Padding
    {
        None, Zero, Mirrow, Replicate
    }

    public class Filter
    { 
        public virtual Complex GetValue( double distanceToCenter) { return new Complex(0, 0); }
    }

    public class ZeroCenterLowPassFilter : Filter
    {
        public override Complex GetValue(double distanceToCenter)
        {
            if (distanceToCenter == 0) return new Complex(0,0);
            else return new Complex(1,0);
        }
    }

    public class IdealLowPassFilter : Filter
    {
        double radius = 10.0;
        public IdealLowPassFilter( double dis )
        {
            radius = dis;
        }
        public override Complex GetValue(double distanceToCenter)
        {
            if (distanceToCenter <= radius) return new Complex(1, 0);
            else return new Complex(0, 0);
        }
    }

    public class ButterworthLowPassFilter : Filter
    {
        int order = 2;
        double radius = 10.0;

        public ButterworthLowPassFilter(double radius, int order )
        {
            this.radius = radius;
            this.order = order;
        }

        public override Complex GetValue(double distanceToCenter)
        {
            double temp =1.0 + Math.Pow(distanceToCenter / radius, 2 * order);
            return new Complex(1.0/temp, 0);
        }
    }



    public class GaussianLowPassFilter : Filter
    {
        double std = 10.0;

        public GaussianLowPassFilter(double value)
        {
        }

        public override Complex GetValue(double distanceToCenter)
        {
            double temp = distanceToCenter / std;
            double real = Math.Exp(-0.5 * temp * temp);
            return new Complex(real, 0);
        }
    }


    public class MonoImage
    {
 
        /// <summary>
        ///  (1) padding target image and set (-1)^(x+y) for centered Fourier Transform
        ///  (2) Perform forwad Fourier Transform
        ///  (3) Element-wise multiplication of filter function and the Fourier 
        ///  (4) Perform Inverse Fourier Transform
        ///  (5) Get clipper Image and set (-1)^(x+y) conversion
        /// </summary>
        /// <param name="target"></param>
        /// <param name="filterUsed"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        public static MonoImage FrequencyDomainFiltering( MonoImage target, Filter filterUsed, Padding pad = Padding.None )
        {
            int p , q;
            if( pad == Padding.None)
            {
                p = target.height;
                q = target.width;
            }
            else
            {
                p = target.height * 2;
                q = target.width * 2;
            }
            int centerU, centerV;
            centerU = p / 2;
            centerV = q / 2;

            // (1) Padding & interchangely alter signs
            double[,] augmentedCenteredImage = new double[p, q];
            bool positive = true;
            for( int r = 0; r < p; r++)
            {
                positive = r % 2 == 0;

                if (r < target.height)
                {
                    // upper half
                    for (int c = 0; c < q; c++)
                    {
                        if ( c < target.width )
                        {
                            // First quadrant
                            augmentedCenteredImage[r, c] = positive ? target.pixels[r, c] : -target.pixels[r, c];
                        }
                        else  
                        {
                            // Second quadrant
                            switch (pad)
                            {
                                case Padding.Zero:
                                    augmentedCenteredImage[r, c] = 0;
                                    break;
                                case Padding.Mirrow:
                                    augmentedCenteredImage[r, c] = positive ?
                                        target.pixels[r, target.width + target.width - c] : -target.pixels[r, target.width + target.width - c ];
                                    break;
                                case Padding.Replicate:
                                    augmentedCenteredImage[r, c] = positive ? 
                                        target.pixels[r, c-target.width] : -target.pixels[r, c-target.width];
                                    break;
                            }
                        }
                        positive = !positive;
                    }
                }
                else
                {
                    // lower half
                    for (int c = 0; c < q; c++)
                    {
                        if (c < target.width)
                        {

                            // Third quadrant
                            switch (pad)
                            {
                                case Padding.Zero:
                                    augmentedCenteredImage[r, c] = 0;
                                    break;
                                case Padding.Mirrow:
                                    augmentedCenteredImage[r, c] = positive ?
                                        target.pixels[target.height + target.height - r,  c] : -target.pixels[ target.height + target.height - r, c];
                                    break;
                                case Padding.Replicate:
                                    augmentedCenteredImage[r, c] = positive ?
                                        target.pixels[r - target.height, c ] : - target.pixels[r - target.height, c ];
                                    break;
                            }
                        }
                        else
                        {
                            // Forth quadrant
                            switch (pad)
                            {
                                case Padding.Zero:
                                    augmentedCenteredImage[r, c] = 0;
                                    break;
                                case Padding.Mirrow:
                                    augmentedCenteredImage[r, c] = positive ?
                                        target.pixels[target.height + target.height - r, target.width + target.width - c] :
                                        -target.pixels[target.height + target.height - r, target.width + target.width - c];
                                    break;
                                case Padding.Replicate:
                                    augmentedCenteredImage[r, c] = positive ?
                                        target.pixels[r - target.height, c-target.width] : -target.pixels[r - target.height, c-target.width];
                                    break;
                            }
                        }
                        positive = !positive;
                    }
                }
            }

            // (2) Perform forwad Fourier Transform
            Complex[,] FTransformed = Fourier.Discrete2DTransform( augmentedCenteredImage, true );

            // (3) Element - wise multiplication of filter function and the Fourier
            for( int r = 0; r <= p/2; r++  )
                for( int c = 0; c <= q/2; c++)
                {
                    double dis = Math.Sqrt((r - centerU) * (r - centerU) + (c - centerV) * (c - centerV));
                    Complex C = filterUsed.GetValue( dis ); // Filter function value
                    FTransformed[r, c] *= C;
                    FTransformed[p-1-r, c] *= C;
                    FTransformed[r, q-1-c] *= C;
                    FTransformed[p-1-r, q-1-c] *= C;
                }

            // (4) Perform Inverse Fourier Transform
            Complex[,] Filtered = Fourier.Discrete2DInverseTransform(FTransformed);

            // (5) Get clipper Image and set (-1)^(x+y) conversion
            int[,] resultPixels = new int[target.height, target.width];
            for( int r = 0; r< target.height; r++)
                for( int c = 0; c < target.width; c++)
                {
                    resultPixels[r, c] = (int)FTransformed[r, c].real;
                    if (resultPixels[r, c] < 0) resultPixels[r, c] = 0;
                    if (resultPixels[r, c] > 255) resultPixels[r, c] = 255;
                }

            return new MonoImage(resultPixels);
        }

        //public static MonoImage FrequencyDomainFiltering( MonoImage target, FilterFunctionComplex filterFunction, Padding pad = Padding.None )
        //{
        //    return null;
        //}

        public static MonoImage FrequencyDomainFiltering( MonoImage target, Complex[ , ] filter, Padding pad = Padding.None )
        {
            return null;
        }




        public static StringBuilder TextMessage = new StringBuilder( );

        public static MonoImage ExtractSpecturmAndPhaseAngleImages( MonoImage source,  out MonoImage phaseAngleImg, out MonoImage centeredSpectrum, 
            out MonoImage LogTransformedSpectrum )
        {
            TextMessage.Clear( );
            DateTime start = DateTime.Now;
            int height = source.height;
            int width = source.width;

            MonoImage spectrumImage = null;
            phaseAngleImg = centeredSpectrum = LogTransformedSpectrum = null;

            Complex[,] forwarded; 
            double realMax = double.MinValue, realMin = double.MaxValue;
            double imageMax = double.MinValue, imageMin = double.MaxValue;
            double[ , ] real = new double[ height, width ];
            double[ , ] imaginary = new double[ height, width ];
            TextMessage.AppendLine( $"*****Fourier Transform {height}x{width} Image *****" );

            // *** Standard spectrum  //  Normal FT 
            int[ , ] spectrum = new int[ height, width ];
            TextMessage.AppendLine( $"(1) Standard DFT for Spectrum: " );
            start = DateTime.Now;
            forwarded = Fourier.DiscreteFourierTransform2DImage( source );

            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                {
                    real[ r, c ] = Math.Sqrt( forwarded[ r, c ].real * forwarded[ r, c ].real + forwarded[ r, c ].image * forwarded[ r, c ].image );
                    if( real[ r, c ] > realMax ) realMax = real[ r, c ];
                    else if( real[ r, c ] < realMin ) realMin = real[ r, c ];
                }
            // Normalize to [0,255]
            realMax = realMax - realMin;
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                    spectrum[ r, c ] = (int) ( ( real[ r, c ] - realMin ) / realMax * 255 );
            spectrumImage = new MonoImage( spectrum );

            TextMessage.AppendLine( $"    Spectrum Image Obtained!  time spent: {DateTime.Now-start} \n" );

            // ***  Centered F // Normal FT  
            spectrum = new int[ height, width ];
            realMax = double.MinValue;
            realMin = double.MaxValue;
            TextMessage.AppendLine( $"(2) Standard DEF for Center-Shifted Spectrum: " );

            start = DateTime.Now;
            forwarded = Fourier.DiscreteFourierTransform2DImage( source, true );
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                {
                    // Spectrum
                    real[ r, c ] =  Math.Sqrt( forwarded[ r, c ].real * forwarded[ r, c ].real + forwarded[ r, c ].image * forwarded[ r, c ].image );
                    if( real[ r, c ] > realMax ) realMax = real[ r, c ];
                    else if( real[ r, c ] < realMin ) realMin = real[ r, c ];
                    // Phase Angle Range -Pi ~ Pi
                    imaginary[ r, c ] = Math.Atan2( forwarded[ r, c ].image, forwarded[r,c].real);
                }
            double Range = realMax - realMin;
            double Two55Over2Pi = 127.5 / Math.PI; // = realMax - realMin;
            int[ , ] phaseAngle = new int[ height, width ];
            // Normalize to [0,255]
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                {
                    spectrum[ r, c ] = (int) ( ( real[ r, c ] - realMin ) / Range * 255 );
                    // Actan -Pi ~ Pi, 
                    phaseAngle[ r, c ] = (int) ( ( imaginary[ r, c ] + Math.PI ) * Two55Over2Pi );
                }

            TextMessage.AppendLine( $"    Centered Spectrum and Phase Angle Images Obtained!  time spent: { DateTime.Now - start} \n" );


            centeredSpectrum = new MonoImage( spectrum );
            phaseAngleImg = new MonoImage( phaseAngle );

            TextMessage.AppendLine( $"(3) Log Transformation: " );
            start = DateTime.Now;

            // Log mapped 
            spectrum = new int[ height, width ];
            realMax = Math.Log( 1.0 + realMax );
            realMin = Math.Log( 1.0 + realMin );
            Range = realMax - realMin;
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                        spectrum[ r, c ] = (int) ( ( Math.Log( 1.0 + real[ r, c ] ) - realMin ) / Range * 255 );
            TextMessage.AppendLine( $"    Log Transformed Spectrum Image Obtained!  time spent: { DateTime.Now - start} \n" );

            LogTransformedSpectrum = new MonoImage( spectrum );

            return spectrumImage;
        }


        public static double[,] operator+( double[,] mask, MonoImage img)
        {
            double[,] pixels = new double[img.height, img.width];
            int hhh = mask.GetLength(0);
            int www = mask.GetLength(1);
            for (int r = 0; r < img.height; r++)
            {
                for (int c = 0; c < img.width; c++)
                {
                    pixels[r,c] = 0;
                    for (int h = 0, y = r - hhh / 2; h < hhh; h++, y++)
                    {
                        for (int w = 0, x = c - www / 2; w < www; w++, x++)
                        {
                            if (x < 0 || x >= img.width) continue;
                            if (y < 0 || y >= img.height) continue;
                            pixels[r, c] += mask[h, w] * img.pixels[y, x];
                        }
                    }
                }
            }
            return pixels;
        }

        // Parallel operation 
        public static MonoImage operator *( Mask msk, MonoImage img )
        {
            int[ , ] pixels = new int[img.height, img.width ];
            Parallel.For( 0, img.height, ( r ) =>
            {
 
                    for( int c = 0 ; c < img.width ; c++ )
                    {
                        double net = 0;
                        for( int h = 0, y = r - msk.height / 2 ; h < msk.height ; h++, y++ )
                        {
                            for( int w = 0, x = c - msk.width / 2 ; w < msk.width ; w++, x++ )
                            {
                                if( x < 0 || x >= img.width ) continue;
                                if( y < 0 || y >= img.height ) continue;
                                net += msk.weights[ h, w ] * img.pixels[ y, x ];
                            }
                        }
                        int pxl = (int) ( net / msk.total );
                        if( pxl > 255 ) pxl = 255;
                        else if( pxl < 0 ) pxl = 0;
                        pixels[ r, c ] = pxl;
                    }
               
            } );
            return new MonoImage( pixels );
        }


        public static MonoImage operator +( Mask msk, MonoImage img )
        {
            int[ , ] pixels = new int[ img.height, img.width ];
 
                for( int r = 0 ; r < img.height ; r++ )
                {
                    for( int c = 0 ; c < img.width ; c++ )
                    {
                        double net = 0;
                        for( int h = 0, y = r - msk.height / 2 ; h < msk.height ; h++, y++ )
                        {
                            for( int w = 0, x = c - msk.width / 2 ; w < msk.width ; w++, x++ )
                            {
                                if( x < 0 || x >= img.width ) continue;
                                if( y < 0 || y >= img.height ) continue;
                                net += msk.weights[ h, w ] * img.pixels[  y, x ];
                            }
                        }
                        int pxl = (int) ( net / msk.total );
                        if( pxl > 255 ) pxl = 255;
                        else if( pxl < 0 ) pxl = 0;
                        pixels[  r, c ] = pxl;
                    }
                }
 
            return new MonoImage( pixels );
        }


        public static MonoImage operator +( MonoImage img1, MonoImage img2 )
        {
            int[ , ] pixels = new int[ img1.height, img1.width ];
            for( int r = 0 ; r < img1.height ; r++ )
            {

                for( int c = 0 ; c < img1.width ; c++ )
                {
                    pixels[ r, c ] = (int) ( img1.pixels[ r, c ] + img2.pixels[ r, c ] / 2.0 );
                    if( pixels[ r, c ] > 255 ) pixels[ r, c ] = 255;
                    else if( pixels[ r, c ] < 0 ) pixels[ r, c ] = 0;
                }
            }
            return new MonoImage( pixels );
        }

        public static MonoImage operator -(MonoImage img1, MonoImage img2)
        {
            int[,] pixels = new int[img1.height, img1.width];
            for (int r = 0; r < img1.height; r++)
            {

                for (int c = 0; c < img1.width; c++)
                {
                    pixels[r, c] = (int)(img1.pixels[r, c] - img2.pixels[r, c] );
                    if (pixels[r, c] > 255) pixels[r, c] = 255;
                    else if (pixels[r, c] < 0) pixels[r, c] = 0;
                }
            }
            return new MonoImage(pixels);
        }

        public static MonoImage OrderStatistics( MonoImage img, int h ,int w, OrderStatisticsMode mode = OrderStatisticsMode.Median)
        {
            int cnt = 0;
            int[] orders = new int[w * h];
            int[,] pixels = new int[img.height, img.width];

            for( int r = 0; r < img.height; r++)
            {
                for( int c = 0; c < img.width; c++)
                {
                    cnt = 0;
                    for( int vv = 0, y=r-h/2; vv < h; vv++,y++)
                    {
                        for( int hh = 0, x= c-w/2; hh < w; hh++,x++)
                        {
                            if (x < 0 || x >= img.width) continue;
                            if (y < 0 || y >= img.height) continue;
                            orders[cnt++] = img.pixels[y, x];
                        }
                    }
                    Array.Sort(orders, 0, cnt);
                    switch( mode)
                    {
                        case OrderStatisticsMode.Median:
                            pixels[r, c] = orders[cnt / 2];
                            break;
                        case OrderStatisticsMode.Min:
                            pixels[r, c] = orders[0];
                            break;
                        case OrderStatisticsMode.Max:
                            pixels[r, c] = orders[cnt-1];
                            break;
                    }
                }
            }
            return new MonoImage(pixels);
        }

        public static ColorImage OrderStatistics(ColorImage img, int h, int w, OrderStatisticsMode mode = OrderStatisticsMode.Median)
        {
            int cnt = 0;
            int[] orders = new int[w * h];
            int[,,] pixels = new int[3,img.height, img.width];

            for (int d = 0; d < 3; d++)
                for (int r = 0; r < img.height; r++)
                {
                    for (int c = 0; c < img.width; c++)
                    {
                        cnt = 0;
                        // Construct an ordered sequence
                        for (int vv = 0, y = r - h / 2; vv < h; vv++, y++)
                        {
                            for (int hh = 0, x = c - w / 2; hh < w; hh++, x++)
                            {
                                if (x < 0 || x >= img.width) continue;
                                if (y < 0 || y >= img.height) continue;

                                orders[cnt] = img.pixels[d, y, x];
                                for (int i = 0; i < cnt; i++)
                                {
                                    if (orders[i] >= img.pixels[d, y, x])
                                    {
                                        for (int j = cnt - 1; j >= i; j--)
                                            orders[j + 1] = orders[j];
                                        orders[i] = img.pixels[d, y, x];
                                        break;
                                    }
                                }
                                cnt++;
                            }
                        }

                        //Array.Sort(orders, 0, cnt);
                        switch (mode)
                        {
                            case OrderStatisticsMode.Median:
                                pixels[d, r, c] = orders[cnt / 2];
                                break;
                            case OrderStatisticsMode.Min:
                                pixels[d, r, c] = orders[0];
                                break;
                            case OrderStatisticsMode.Max:
                                pixels[d, r, c] = orders[cnt - 1];
                                break;
                        }
                    }

                }
            return new ColorImage(pixels);
        }


        public Bitmap displayedBitmap;
        public int height;
        public int width;
        public int[ , ] pixels;
        double[ ] histograms = new double[256];

        #region HELPING FUNCTIONS

        void SetPixelsFromImage( bool weightedGray = false )
        {
            if( displayedBitmap == null ) return;
 
             for( int i = 0 ; i < 256 ; i++ ) histograms[  i ] = 0;
            height = displayedBitmap.Height;
            width = displayedBitmap.Width;
            pixels = new int[ height, width ];
            for( int r = 0 ; r < displayedBitmap.Height ; r++ )
                for( int c = 0 ; c < displayedBitmap.Width ; c++ )
                {
                    Color clr = displayedBitmap.GetPixel( c, r );
                    //double rFactor = 0.299, double gFactor = 0.587,double bFactor = 0.114 
                    if( weightedGray )
                        pixels[ r, c ] = (int)( clr.R * 0.299+ clr.G *0.587 + clr.B * 0.114);
                    else
                        pixels[ r, c ] = (int) ( ( clr.R + clr.G + clr.B ) / 3.0 );

                    histograms[ pixels[ r, c ] ] += 1;
                }
            int total = displayedBitmap.Height * displayedBitmap.Width;
                for( int i = 0 ; i < 256 ; i++ ) histograms[ i ] /= total;
        }

        void SetImageFromPixels( )
        {
            if( pixels == null ) return;

            width = pixels.GetLength( 1 );
            height = pixels.GetLength( 0 );
            if( displayedBitmap == null || displayedBitmap.Width != width ||
                displayedBitmap.Height != height || pixels.GetLength( 0 ) != 3 )
                displayedBitmap = new Bitmap( width, height );

            for( int r = 0 ; r < displayedBitmap.Height ; r++ )
                for( int c = 0 ; c < displayedBitmap.Width ; c++ )
                {
                    Color clr = Color.FromArgb( pixels[ r, c ], pixels[  r, c ], pixels[ r, c ] );
                    displayedBitmap.SetPixel( c, r, clr );
                    histograms[ pixels[ r, c ] ] += 1;
                }
        }

        #endregion


        #region CONSTRUCTORS


        /// <summary>
        ///  Create a color image form a given bitmap.
        /// </summary>
        /// <param name="originalImage"></param>
        public MonoImage( Bitmap originalImage, bool weightedGray = false )
        {
            height = originalImage.Height;
            width = originalImage.Width;
            displayedBitmap = new Bitmap( width, height  );
            // reassign pixel value to gray image
            int i;
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                {
                    Color clr = originalImage.GetPixel( c, r );
                    if(   weightedGray )
                        i = (int) ( 0.299 * clr.R + 0.587 * clr.G + 0.114 * clr.B  );
                    else
                        i = (int) ( ( clr.R + clr.G + clr.B ) / 3.0 );

                    displayedBitmap.SetPixel( c, r, Color.FromArgb(i,i,i) );
                }
            // 
            SetPixelsFromImage( weightedGray );
       }


        /// <summary>
        ///  Create a color image from given pixel data
        /// </summary>
        /// <param name="data"></param>
        public MonoImage( int[ , ] data )
        {
            pixels = data;
            SetImageFromPixels( );
        }

        #endregion
    }

}
