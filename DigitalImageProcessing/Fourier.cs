using System;

namespace DigitalImageProcessing
{
    public class Fourier
    {

        public static double[ , ] DiscreteFourierTransform( double[ , ] x )
        {
            int rows = x.GetLength( 0 );
            int cols = x.GetLength( 1 );
            double[ ] xary = new double[ cols ];
            double[ ] yary = new double[ rows ];
            Complex[ ] y;
            double[ , ] output = new double[ rows, cols ];

            // Row-wise transform
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ ) xary[ c ] = x[ r, c ];
                y = DiscreteFourierTransform( xary );
                for( int c = 0 ; c < cols ; c++ ) output[ r, c ] = y[ c ].real;
            }
            // Column-wise transform
            for( int c = 0 ; c < cols ; c++ )
            {
                for( int r = 0 ; r < rows ; r++ ) yary[ c ] = output[ r, c ];
                y = DiscreteFourierTransform( yary );
                for( int r = 0 ; r < cols ; r++ ) output[ r, c ] = y[ r ].real;
            }
            return output;
        }

        public static Complex[ ] DiscreteFourierTransform( Complex[ ] x )
        {
            double twoPiOverN = 2.0 * Math.PI / x.Length;
            int k, n;
            Complex[ ] X = new Complex[ x.Length ];

            for( k = 0 ; k < x.Length ; k++ )
            {
                X[ k ] = new Complex( 0.0, 0.0 );

                for( n = 0 ; n < x.Length ; n++ )
                {
                    double cs = Math.Cos( twoPiOverN * k * n );
                    double ss = Math.Sin( twoPiOverN * k * n );
                    X[ k ].real += x[ n ].real * cs - x[ n ].image * ss;
                    X[ k ].image -= x[ n ].real * ss - x[ n ].image * cs;
                }
                X[ k ] = X[ k ] / x.Length;
            }
            return X;
        }


        public static Complex[ ] DiscreteFourierTransform( double[ ] x )
        {
            double twoPiOverN = 2.0 * Math.PI / x.Length;
            int k, n;
            Complex[ ] X = new Complex[ x.Length ];

            for( k = 0 ; k < x.Length ; k++ )
            {
                X[ k ] = new Complex( 0.0, 0.0 );

                for( n = 0 ; n < x.Length ; n++ )
                {
                    X[ k ].real += x[ n ] * Math.Cos( twoPiOverN * k * n );
                    X[ k ].image -= x[ n ] * Math.Sin( twoPiOverN * k * n );
                }
                X[ k ] = X[ k ] / x.Length;
            }
            return X;
        }


        public static double[ ] InverseDiscreteFourierTransfrom( Complex[ ] X )
        {
            double[ ] x = new double[ X.Length ];
            double twoPiOverN = 2.0 * Math.PI / X.Length;

            for( int n = 0 ; n < X.Length ; n++ )
            {
                for( int k = 0 ; k < X.Length ; k++ )
                {
                    x[ n ] += X[ k ].real * Math.Cos( twoPiOverN * k * n )
                          - X[ k ].image * Math.Sin( twoPiOverN * k * n );
                }
            }
            return x;
        }


        // This computes an in-place complex-to-complex FFT  
        // x and y are the real and imaginary arrays of 2^m points. 
        // forwardNotReverse =  true gives forward transform 
        // forwardNotReverse = false gives reverse transform  
        // see http://astronomy.swin.edu.au/~pbourke/analysis/dft/ 
        public static void FastFourierTransform( bool forwardNotReverse, int powerOf2, double[ ] real, double[ ] image )
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tx, ty, t1, t2, u1, u2, z;

            // Calculate the number of points 
            n = 1;
            for( i = 0 ; i < powerOf2 ; i++ )
                n *= 2;

            // Do the bit reversal 
            i2 = n >> 1;
            j = 0;
            for( i = 0 ; i < n - 1 ; i++ )
            {
                if( i < j )
                {
                    tx = real[ i ];
                    ty = image[ i ];
                    real[ i ] = real[ j ];
                    image[ i ] = image[ j ];
                    real[ j ] = tx;
                    image[ j ] = ty;
                }
                k = i2;
                while( k <= j )
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }

            // Compute the FFT 
            c1 = -1.0;
            c2 = 0.0;
            l2 = 1;

            for( l = 0 ; l < powerOf2 ; l++ )
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0;
                u2 = 0.0;

                for( j = 0 ; j < l1 ; j++ )
                {
                    for( i = j ; i < n ; i += l2 )
                    {
                        i1 = i + l1;
                        t1 = u1 * real[ i1 ] - u2 * image[ i1 ];
                        t2 = u1 * image[ i1 ] + u2 * real[ i1 ];
                        real[ i1 ] = real[ i ] - t1;
                        image[ i1 ] = image[ i ] - t2;
                        real[ i ] += t1;
                        image[ i ] += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = Math.Sqrt( ( 1.0 - c1 ) / 2.0 );
                if( forwardNotReverse ) c2 = -c2;
                c1 = Math.Sqrt( ( 1.0 + c1 ) / 2.0 );
            }

            // Scaling for forward transform 
            if( forwardNotReverse )
            {
                for( i = 0 ; i < n ; i++ )
                {
                    real[ i ] /= n;
                    image[ i ] /= n;
                }
            }
        }


        public static Complex[ ] RecursiveFFT( Complex[ ] a )
        {
            int n = a.Length;
            int n2 = n / 2;

            if( n == 1 )
                return a;

            Complex z = new Complex( 0.0, 2.0 * Math.PI / n );
            Complex omegaN = Complex.Exp( z );
            Complex omega = new Complex( 1.0, 0.0 );
            Complex[ ] a0 = new Complex[ n2 ];
            Complex[ ] a1 = new Complex[ n2 ];
            Complex[ ] y0 = new Complex[ n2 ];
            Complex[ ] y1 = new Complex[ n2 ];
            Complex[ ] y = new Complex[ n ];

            for( int i = 0 ; i < n2 ; i++ )
            {
                a0[ i ] = new Complex( 0.0, 0.0 );
                a0[ i ] = a[ 2 * i ];
                a1[ i ] = new Complex( 0.0, 0.0 );
                a1[ i ] = a[ 2 * i + 1 ];
            }

            y0 = RecursiveFFT( a0 );
            y1 = RecursiveFFT( a1 );

            for( int k = 0 ; k < n2 ; k++ )
            {
                //y[k] = new Complex(0.0, 0.0);
                //y[k] = y0[k].Add(y1[k].Mul(omega));
                //y[k + n2] = new Complex(0.0, 0.0);
                //y[k + n2] = y0[k].Sub(y1[k].Mul(omega));
                //omega = omega.Mul(omegaN);
                y[ k ] = new Complex( 0.0, 0.0 );
                y[ k ] = y0[ k ] + ( y1[ k ] * omega );
                y[ k + n2 ] = new Complex( 0.0, 0.0 );
                y[ k + n2 ] = y0[ k ] - ( y1[ k ] * omega );
                omega *= omegaN;
            }

            return y;
        }

    }


}
