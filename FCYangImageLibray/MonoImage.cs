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

    public class MonoImage
    {
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
            forwarded = Fourier.DiscreteFourierTransform( source );

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
            forwarded = Fourier.DiscreteFourierTransform( source, true );
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
