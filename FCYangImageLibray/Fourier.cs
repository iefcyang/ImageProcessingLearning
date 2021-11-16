
using System;

namespace FCYangImageLibray
{

    //public delegate Complex FilterFunctionComplex( double dis );
    //public delegate double FilterFunctionReal( double dis  );

    public class Fourier
    {


        public static Complex[,] DiscreteFourierTransform2DImage( MonoImage img, bool isCentered = false )
        {
            int rows = img.height;// x.GetLength(0);
            int cols = img.width; // x.GetLength(1);
            double[] rowArray = new double[cols];
            Complex[] columnArray = new Complex[rows];
            Complex[] tempResult;
            Complex[,] output = new Complex[rows, cols];

            // Row-wise transform
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++) 
                    if( isCentered)
                        rowArray[c] = (r+c) % 2 == 0 ? img.pixels[r, c] : -img.pixels[ r, c ];
                    else
                        rowArray[ c ] = img.pixels[ r, c ];

                // Real array in Complex array out
                tempResult = Discrete1DTransform(rowArray);
                for (int c = 0; c < cols; c++) output[r, c] = tempResult[c];
            }
            // Column-wise transform
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++) columnArray[ r] = output[r, c];
                tempResult = Discrete1DTransform( columnArray );
                for (int r = 0; r < rows; r++) output[r, c] = tempResult[r];
            }
            return output;
        }

        public static Complex[ , ] Discrete2DInverseTransform( Complex[ , ] x )
        {
            int rows = x.GetLength( 0 );
            int cols = x.GetLength( 1 );
            Complex[ ] xary = new Complex[ cols ];
            Complex[ ] yary = new Complex[ rows ];
            Complex[ ] C;
            Complex[ , ] output = new Complex[ rows, cols ];

            // Row-wise transform
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ ) xary[ c ] = x[ r, c ];
                C = Discrete1DInverseTransfromToComplex( xary );
                for( int c = 0 ; c < cols ; c++ ) output[ r, c ] = C[ c ] ;
            }
            // Column-wise transform
            for( int c = 0 ; c < cols ; c++ )
            {
                for( int r = 0 ; r < rows ; r++ ) yary[ r ] = output[ r, c ];
                C = Discrete1DInverseTransfromToComplex( yary );
                for( int r = 0 ; r < rows ; r++ ) output[ r, c ] = C[ r ];
            }
            return output;
        }

        public static Complex[ , ] Discrete2DTransform( Complex[ , ] x )
        {
            int rows = x.GetLength( 0 );
            int cols = x.GetLength( 1 );
            Complex[ ] xary = new Complex[ cols ];
            Complex[ ] yary = new Complex[ rows ];
            Complex[ ] C;
            Complex[ , ] output = new Complex[ rows, cols ];

            // Row-wise transform
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ ) xary[ c ] = x[ r, c ];
                C = Discrete1DTransform( xary );
                for( int c = 0 ; c < cols ; c++ ) output[ r, c ] = C[ c ];
            }
            // Column-wise transform
            for( int c = 0 ; c < cols ; c++ )
            {
                for( int r = 0 ; r < rows ; r++ ) yary[ r ] = output[ r, c ];
                C = Discrete1DTransform( yary );
                for( int r = 0 ; r < rows ; r++ ) output[ r, c ] = C[ r ];
            }
            return output;
        }




        public static Complex[,] Discrete2DTransform(double[,] x, bool ToComplex = true)
        {
            int rows = x.GetLength(0);
            int cols = x.GetLength(1);
            Complex[] xary = new Complex[cols];
            Complex[] yary = new Complex[rows];
            Complex[] C;
            Complex[,] output = new Complex[rows, cols];

            // Row-wise transform
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++) xary[c].real =  x[r, c];
                C = Discrete1DTransform(xary);
                for (int c = 0; c < cols; c++) output[r, c] = C[c];
            }
            // Column-wise transform
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++) yary[r] = output[r, c];
                C = Discrete1DTransform(yary);
                for (int r = 0; r < rows; r++) output[r, c] = C[r];
            }
            return output;
        }


        public static double[ , ] Discrete2DTransform( double[ , ] x )
        {
            int rows = x.GetLength( 0 );
            int cols = x.GetLength( 1 );
            double[ ] xary = new double[ cols ];
            double[ ] yary = new double[ rows ];
            Complex[ ] C;
            double[ , ] output = new double[ rows, cols ];

            // Row-wise transform
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ ) xary[ c ] = x[ r, c ];
                C = Discrete1DTransform( xary );
                for( int c = 0 ; c < cols ; c++ ) output[ r, c ] = C[ c ].real;
            }
            // Column-wise transform
            for( int c = 0 ; c < cols ; c++ )
            {
                for( int r = 0 ; r < rows ; r++ ) yary[ r ] = output[ r, c ];
                C = Discrete1DTransform( yary );
                for( int r = 0 ; r < rows ; r++ ) output[ r, c ] = C[ r ].real;
            }
            return output;
        }

        public static Complex[ ] Discrete1DTransform( Complex[ ] x )
        {
            double twoPiOverN = 2.0 * Math.PI / x.Length;
            int k, n;
            Complex[ ] Z = new Complex[ x.Length ];

            for( k = 0 ; k < x.Length ; k++ )
            {
                Z[ k ] = new Complex( 0.0, 0.0 ); // initialize; it is a struct, no dynamical allocation

                for( n = 0 ; n < x.Length ; n++ )
                {
                    double cs = Math.Cos( -twoPiOverN * k * n );
                    double ss = Math.Sin( -twoPiOverN * k * n );
                    Z[ k ].real += x[ n ].real * cs - x[ n ].imaginary * ss;
                    Z[ k ].imaginary += x[ n ].real * ss + x[ n ].imaginary * cs;
                }
               // Z[ k ] = Z[ k ] / x.Length;
            }
            return Z;
        }



        public static Complex[ ] Discrete1DTransform( double[ ] x )
        {
            double twoPiOverN = 2.0 * Math.PI / x.Length;
            int k, n;
            Complex[ ] Z = new Complex[ x.Length ];

            for( k = 0 ; k < x.Length ; k++ )
            {
                Z[ k ] = new Complex( 0.0, 0.0 );

                for( n = 0 ; n < x.Length ; n++ )
                {
                    Z[ k ].real += x[ n ] * Math.Cos( -twoPiOverN * k * n );
                    Z[ k ].imaginary += x[ n ] * Math.Sin( -twoPiOverN * k * n );
                }
                //Z[ k ] = Z[ k ] / x.Length;
            }
            return Z;
        }


        public static double[ ] Discrete1DInverseTransfromToReal( Complex[ ] Z )
        {
            double[ ] x = new double[ Z.Length ];
            double twoPiOverN = 2.0 * Math.PI / Z.Length;

            for( int n = 0 ; n < Z.Length ; n++ )
            {
                for( int k = 0 ; k < Z.Length ; k++ )
                {
                    x[ n ] += Z[ k ].real * Math.Cos( twoPiOverN * k * n ) - Z[ k ].imaginary * Math.Sin( twoPiOverN * k * n );
                }
                x[ n ] = x[ n ] / Z.Length;
            }
            return x;
        }

        public static Complex[ ] Discrete1DInverseTransfromToComplex( Complex[ ] Z )
        {
            Complex[ ] x = new Complex[ Z.Length ];
            double twoPiOverN = 2.0 * Math.PI / Z.Length;

            for( int n = 0 ; n < Z.Length ; n++ )
            {
                x[n].real = 0;
                x[n].imaginary = 0;
                for( int k = 0 ; k < Z.Length ; k++ )
                {
                    double cs = Math.Cos( twoPiOverN * k * n );
                    double ss = Math.Sin( twoPiOverN * k * n );

                    x[ n ].real += Z[ k ].real * cs - Z[ k ].imaginary * ss;
                    x[ n ].imaginary += Z[ k ].real * ss + Z[ k ].imaginary * cs;
                }
                x[ n ] /= Z.Length;
            }
            return x;
        }





        // This computes an in-place complex-to-complex FFT  
        // x and y are the real and imaginary arrays of 2^m points. 
        // forwardNotReverse =  true gives forward transform 
        // forwardNotReverse = false gives reverse transform  
        // see http://astronomy.swin.edu.au/~pbourke/analysis/dft/ 
        public static void FastFourierTransform(  double[ ] real, double[ ] image,  bool isForward  )
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tempR, rempI, t1, t2, u1, u2, z;
            n = real.Length;
            if( image.Length != n ) throw new Exception( "Array sizes of real and image arrays are different!" );
            if( n < 2 ) throw new Exception( "Size is less than 2!" );
            // Calculate the number of points 
            i = 2;
            int powerOf2 = 1;
            while( n > i )
            {
                i = i * 2;
                powerOf2++;
            }
            if( i != n ) throw new Exception( "Array length is not the power of 2!" ); 

            // Do the bit reversal 
            i2 = n >> 1;
            j = 0;
            for( i = 0 ; i < n - 1 ; i++ )
            {
                if( i < j )
                {
                    // Swap elements i and j
                    tempR = real[ i ];
                    rempI = image[ i ];
                    real[ i ] = real[ j ];
                    image[ i ] = image[ j ];
                    real[ j ] = tempR;
                    image[ j ] = rempI;
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
                if( !isForward ) c2 = -c2;
                c1 = Math.Sqrt( ( 1.0 + c1 ) / 2.0 );
            }

            // Scaling for forward transform 
            if( !isForward )
            {
                for( i = 0 ; i < n ; i++ )
                {
                    real[ i ] /= n;
                    image[ i ] /= n;
                }
            }
        }

        public static void FastFourierTransform( Complex[ ] C, bool isForward )
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tempR, tempI, t1, t2, u1, u2, z;
            int powerOf2 = 1;

            // Calculate the number of points 
            n = C.Length;
            if( n < 2 ) throw new Exception( "Size is less than 2!" );
            // Calculate the number of points 
            i = 2;
            while( n > i )
            {
                i = i * 2;
                powerOf2++;
            }
            if( i != n ) throw new Exception( "Array length is not the power of 2!" );

            // Do the bit reversal 
            i2 = n >> 1;
            j = 0;
            for( i = 0 ; i < n - 1 ; i++ )
            {
                if( i < j )
                {
                    // Swap elements i and j
                    tempR = C[ i ].real;
                    tempI = C[ i ].imaginary;
                    C[ i ].real = C[ j ].real;
                    C[ i ].imaginary= C[ j ].imaginary;
                    C[ j ].real = tempR;
                    C[ j ].imaginary = tempI;
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
                        t1 = u1 * C[ i1 ].real - u2 * C[ i1 ].imaginary;
                        t2 = u1 * C[ i1 ].imaginary + u2 * C[ i1 ].real;
                        C[ i1 ].real = C[ i ].real - t1;
                        C[ i1 ].imaginary = C[ i ].imaginary - t2;
                        C[ i ].real += t1;
                        C[ i ].imaginary += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = Math.Sqrt( ( 1.0 - c1 ) / 2.0 );
                if( !isForward ) c2 = -c2;
                c1 = Math.Sqrt( ( 1.0 + c1 ) / 2.0 );
            }

            // Scaling for forward transform 
            if( !isForward )
            {
                for( i = 0 ; i < n ; i++ )
                {
                    C[ i ].real /= n;
                    C[ i ].imaginary /= n;
                }
            }
        }

        public static Complex[ , ] DiscreteFast2DTransform( Complex[ , ] x )
        {
            int rows = x.GetLength( 0 );
            int cols = x.GetLength( 1 );
            Complex[ ] xary = new Complex[ cols ];
            Complex[ ] yary = new Complex[ rows ];
            Complex[ , ] output = new Complex[ rows, cols ];

            // Row-wise transform
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ ) xary[ c ] = x[ r, c ];
                FastFourierTransform( xary, true );
                for( int c = 0 ; c < cols ; c++ ) output[ r, c ] = xary[ c ];
            }
            // Column-wise transform
            for( int c = 0 ; c < cols ; c++ )
            {
                for( int r = 0 ; r < rows ; r++ ) yary[ r ] = output[ r, c ];
                FastFourierTransform( yary, true );
                for( int r = 0 ; r < rows ; r++ ) output[ r, c ] = yary[ r ];
            }
            return output;
        }

        public static Complex[ , ] DiscreteFastInverse2DTransform( Complex[ , ] x )
        {
            int rows = x.GetLength( 0 );
            int cols = x.GetLength( 1 );
            Complex[ ] xary = new Complex[ cols ];
            Complex[ ] yary = new Complex[ rows ];
            Complex[ , ] output = new Complex[ rows, cols ];

            // Row-wise transform
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ ) xary[ c ] = x[ r, c ];
                FastFourierTransform( xary, false );
                for( int c = 0 ; c < cols ; c++ ) output[ r, c ] = xary[ c ];
            }
            // Column-wise transform
            for( int c = 0 ; c < cols ; c++ )
            {
                for( int r = 0 ; r < rows ; r++ ) yary[ r ] = output[ r, c ];
                FastFourierTransform( yary, false );
                for( int r = 0 ; r < rows ; r++ ) output[ r, c ] = yary[ r ];
            }
            return output;
        }

        public static Complex[ ] RecursiveFFT( Complex[ ] C )
        {
            int len = C.Length;
            int half = len / 2;

            if( len == 1 ) return C;

            Complex temp = new Complex( 0.0, 2.0 * Math.PI / len );
            Complex omegaN = Complex.Exp( temp );
            Complex omega = new Complex( 1.0, 0.0 );
            Complex[ ] even = new Complex[ half ];
            Complex[ ] odd = new Complex[ half ];
            Complex[ ] evenOut; // = new Complex[ half ];
            Complex[ ] oddOut; // = new Complex[ half ];
            Complex[ ] Z = new Complex[ len ];

            for( int i = 0 ; i < half ; i++ )
            {
                even[ i ] = new Complex( 0.0, 0.0 );
                even[ i ] = C[ 2 * i ];
                odd[ i ] = new Complex( 0.0, 0.0 );
                odd[ i ] = C[ 2 * i + 1 ];
            }

            evenOut = RecursiveFFT( even );
            oddOut = RecursiveFFT( odd );

            for( int k = 0 ; k < half ; k++ )
            {
                //y[k] = new Complex(0.0, 0.0);
                //y[k] = y0[k].Add(y1[k].Mul(omega));
                //y[k + n2] = new Complex(0.0, 0.0);
                //y[k + n2] = y0[k].Sub(y1[k].Mul(omega));
                //omega = omega.Mul(omegaN);
                Z[ k ] = new Complex( 0.0, 0.0 );
                Z[ k ] = evenOut[ k ] + ( oddOut[ k ] * omega );
                Z[ k + half ] = new Complex( 0.0, 0.0 );
                Z[ k + half ] = evenOut[ k ] - ( oddOut[ k ] * omega );
                omega *= omegaN;

                // half?
                //Z[ k ] = Z[ k ] / 2.0;
                //Z[ k + half ] = Z[ k + half ] / 2.0;
            }

            return Z;
        }


        public static void InPlaceRecursiveFFT( Complex[ ] C )
        {
            int len = C.Length;
            int half = len / 2;

            if( len == 1 ) return;

            Complex temp = new Complex( 0.0, 2.0 * Math.PI / len );
            Complex omegaN = Complex.Exp( temp );
            Complex omega = new Complex( 1.0, 0.0 );
            Complex[ ] even = new Complex[ half ];
            Complex[ ] odd = new Complex[ half ];
            Complex[ ] evenOut; // = new Complex[ half ];
            Complex[ ] oddOut; // = new Complex[ half ];
            //Complex[ ] Z = new Complex[ len ];

            for( int i = 0 ; i < half ; i++ )
            {
                even[ i ] = new Complex( 0.0, 0.0 );
                even[ i ] = C[ 2 * i ];
                odd[ i ] = new Complex( 0.0, 0.0 );
                odd[ i ] = C[ 2 * i + 1 ];
            }

            evenOut = RecursiveFFT( even );
            oddOut = RecursiveFFT( odd );

            for( int k = 0 ; k < half ; k++ )
            {
                //y[k] = new Complex(0.0, 0.0);
                //y[k] = y0[k].Add(y1[k].Mul(omega));
                //y[k + n2] = new Complex(0.0, 0.0);
                //y[k + n2] = y0[k].Sub(y1[k].Mul(omega));
                //omega = omega.Mul(omegaN);
                C[ k ] = new Complex( 0.0, 0.0 );
                C[ k ] = evenOut[ k ] + ( oddOut[ k ] * omega );
                C[ k + half ] = new Complex( 0.0, 0.0 );
                C[ k + half ] = evenOut[ k ] - ( oddOut[ k ] * omega );
                omega *= omegaN;

                // half??
                //C[ k ] = C[ k ] / 2;
                //C[ k + half ] = C[ k + half ] / 2;
            }

            //return Z;
        }

        static Complex[ , ] TwoDimensionalDiscreteFourierTransform( Complex[ , ] X )
        {
            int rows = X.GetLength( 0 );
            int cols = X.GetLength( 1 );
            Complex[ , ] Z = new Complex[ rows, cols ];
            Complex target = new Complex( 0, 0 );
            double twoPi = Math.PI * 2.0;
            double theta;
            for( int r = 0 ; r < rows ; r++ )
            {
                for( int c = 0 ; c < cols ; c++ )
                {
                    Z[ r, c ] = new Complex( 0, 0 );
                    for( int y = 0 ; y < rows ; y++ )
                    {
                        double temp = (double) r * y / rows;
                        for( int x = 0 ; x < cols ; x++ )
                        {
                            theta = twoPi * ( (double) c * x / cols + temp );
                            target.real = Math.Cos( theta );
                            target.imaginary = Math.Sin( -theta );
                            Z[ r, c ] += X[ y, x ] * target;
                        }
                    }
                    Z[ r, c ] /= rows * cols;
                }
            }

            return Z;
        }

    }


}
