using System;
using System.Collections.Generic;
using System.Text;

namespace FCYangImageLibray
{
    public struct Complex
    {
        static Random rnd = new Random( );

        public override string ToString( )
        {
            return $"({real:0.00},{imaginary:0.00})";
        }
        public override bool Equals( object obj )
        {
            Complex target = (Complex) obj;
            if( real == target.real && imaginary == target.imaginary ) return true;
            return false;
        }


        public static string ArrayText( Complex[] C )
        {
            StringBuilder sb = new StringBuilder( );
            foreach( Complex c in C )
            {
                sb.Append( $"({c.real:0.00},{c.imaginary:0.00}), " );
            }
            sb.Append( $"Count = {C.Length}" );
            return sb.ToString( );
        }

        public static Complex[] GetArray( double upBound = 2000, int TwoPower = 8 )
        {
            int n = 1;
            for( int i = 0 ; i < TwoPower ; i++ ) n *= 2;
            Complex[ ] C = new Complex[ n ];
            double half = upBound / 2;
            for( int i = 0 ; i < n ; i++ )
            {
                C[ i ] = new Complex( );
                C[ i ].real = rnd.NextDouble( ) * upBound - half;
                C[ i ].imaginary = rnd.NextDouble( ) * upBound - half;
            }
            return C;
        }

        //  離散傅立葉轉換僅處理1維資訊，因此對於影像屬於2維資訊需進行兩次的離散傅立葉轉換。
        // 針對row進行DFT，後針對column進行DFT方能得到目標影像。

        public List<Complex> transform( List<Complex> inputs, bool _IsInverse, List<Complex> outputs )
        {
            int size = inputs.Count;
            int DFTdir = ( _IsInverse ) ? -1 : 1;
            double Theta, cosineA, sineA;
            Complex[ ] ary = new Complex[ size ];
            for( int i = 0 ; i < size ; i++ )
            {
                ary[ i ].real = ary[ i ].imaginary = 0;
                for( int j = 0 ; j < size ; j++ )
                {
                    Theta = ( Math.PI * 2 * i * j * DFTdir ) / size;
                    cosineA = Math.Cos( Theta );
                    sineA = Math.Sin( Theta );

                    ary[ i ].real += inputs[ j ].real * cosineA - inputs[ j ].imaginary * sineA;
                    ary[ i ].imaginary += inputs[ j ].real * sineA + inputs[ j ].imaginary * cosineA;
                }
                outputs.Add( ary[i] );
            }
            return outputs;
        }


        public double real, imaginary;


        public Complex( double r, double i )
        {
            real = r;
            imaginary = i;
        }


        public static Complex operator +( Complex a, Complex b )
        {
            return new Complex( a.real + b.real, a.imaginary + b.imaginary );
        }


        public Complex Add( Complex z )
        {
            return new Complex( real + z.real, imaginary + z.imaginary );
        }


        public static Complex operator -( Complex a, Complex b )
        {
            return new Complex( a.real - b.real, a.imaginary - b.imaginary );
        }

        public static Complex operator -(Complex a )
        {
            a.real = -a.real;
            a.imaginary = -a.imaginary;
            return a;
        }

        public Complex Sub( Complex z )
        {
            return new Complex( real - z.real, imaginary - z.imaginary );
        }


        public static Complex operator *( Complex a, Complex b )
        {
            double r = a.real * b.real - a.imaginary * b.imaginary;
            double i = a.real * b.imaginary + a.imaginary * b.real;
            return new Complex( r, i );
        }


        public static Complex operator *( double b, Complex a )
        {
            a.real *= b;
            a.imaginary *= b;
            return a;
        }


        public Complex Mul( Complex z )
        {
            double r = real * z.real - imaginary * z.imaginary;
            double i = real * z.imaginary + imaginary * z.real;

            return new Complex( r, i );
        }


        public static Complex operator /( Complex a, Complex b )
        {
            double d = b.real * b.real + b.imaginary * b.imaginary;
            double r = ( a.real * b.real + a.imaginary * b.imaginary ) / d;
            double i = ( a.imaginary * b.real - a.real * b.imaginary ) / d;
            return new Complex( r, i );
        }

        public static Complex operator / (double k, Complex c)
        {
            double temp = c.real * c.real + c.imaginary * c.imaginary;
            if (temp == 0)
            {
                c.real = 0;
                c.imaginary = 0;
            }
            else
            {
                c.real = k * c.real / temp;
                c.imaginary = -k * c.imaginary / temp;
            }
            return c;
        }


        public static Complex operator /( Complex a, double b )
        {
            a.real /= b;
            a.imaginary /= b;
            return a;
        }


        public Complex Div( Complex z )
        {
            double d = z.real * z.real + z.imaginary * z.imaginary;
            double r = ( real * z.real + imaginary * z.imaginary ) / d;
            double i = ( imaginary * z.real - real * z.imaginary ) / d;

            return new Complex( r, i );
        }


        public static double Abs( Complex z )
        {
            return Math.Sqrt( z.real * z.real + z.imaginary * z.imaginary );
        }


        public static Complex Exp( Complex z )
        {
            double e = Math.Exp( z.real );
            double r = Math.Cos( z.imaginary );
            double i = Math.Sin( z.imaginary );

            return new Complex( e * r, e * i );
        }

        public static string MatrixText( Complex[ , ] C )
        {
            StringBuilder sb = new StringBuilder( );
            int cols = C.GetLength( 1 );
            int cnt = 0;
            foreach( Complex c in C )
            {
                sb.Append( $"({c.real:0.00},{c.imaginary:0.00}), " );
                cnt++;
                if( cnt >= cols)
                {
                    sb.Append( "\n" );
                    cnt = 0;
                }
            }
            sb.Append( $" Dim = {C.GetLength(0)}x{C.GetLength(1)}" );
            return sb.ToString( );
        }

        public static Complex[, ] Get2DMatrix( double upBound = 2000, int TwoPower = 8, bool NoImaginary = false )
        {
            int n = 1;
            for( int i = 0 ; i < TwoPower ; i++ ) n *= 2;
            Complex[, ] C = new Complex[ n,n ];
            double half = upBound / 2;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (NoImaginary)
                        C[i, j] = new Complex(rnd.NextDouble() * upBound - half, 0);
                    else
                        C[i, j] = new Complex(rnd.NextDouble() * upBound - half, rnd.NextDouble() * upBound - half);
            return C;
        }
    }

    //public class OriComplex
    //{
    //    public override bool Equals( object obj )
    //    {
    //        Complex target = obj as Complex;
    //        if( real == target.real && image == target.image ) return true;
    //        return false;
    //    }

    //    static Random rnd = new Random( );

    //    public static string ArrayText( Complex[ ] C )
    //    {
    //        StringBuilder sb = new StringBuilder( );
    //        foreach( Complex c in C )
    //        {
    //            sb.Append( $"({c.real:0.00},{c.image:0.00}), " );
    //        }
    //        sb.Append( $"Count = {C.Length}" );
    //        return sb.ToString( );
    //    }

    //    public static Complex[ ] GetArray( double upBound = 2000, int TwoPower = 8 )
    //    {
    //        int n = 1;
    //        for( int i = 0 ; i < TwoPower ; i++ ) n *= 2;
    //        Complex[ ] C = new Complex[ n ];
    //        double half = upBound / 2;
    //        for( int i = 0 ; i < n ; i++ )
    //        {
    //            C[ i ] = new Complex( );
    //            C[ i ].real = rnd.NextDouble( ) * upBound - half;
    //            C[ i ].image = rnd.NextDouble( ) * upBound - half;
    //        }
    //        return C;
    //    }

    //    //  離散傅立葉轉換僅處理1維資訊，因此對於影像屬於2維資訊需進行兩次的離散傅立葉轉換。
    //    // 針對row進行DFT，後針對column進行DFT方能得到目標影像。

    //    public List<Complex> transform( List<Complex> inputs, bool _IsInverse, List<Complex> outputs )
    //    {
    //        int size = inputs.Count;
    //        int DFTdir = ( _IsInverse ) ? -1 : 1;
    //        double Theta, cosineA, sineA;
    //        for( int i = 0 ; i < size ; i++ )
    //        {
    //            outputs.Add( new Complex( ) );
    //            for( int j = 0 ; j < size ; j++ )
    //            {
    //                Theta = ( Math.PI * 2 * i * j * DFTdir ) / size;
    //                cosineA = Math.Cos( Theta );
    //                sineA = Math.Sin( Theta );

    //                outputs[ i ].real += inputs[ j ].real * cosineA - inputs[ j ].image * sineA;
    //                outputs[ i ].image += inputs[ j ].real * sineA + inputs[ j ].image * cosineA;
    //            }
    //        }
    //        return outputs;
    //    }


    //    public double real, image;

    //    public Complex( )
    //    {
    //        real = image = 0.0;
    //    }


    //    public Complex( double r, double i )
    //    {
    //        real = r;
    //        image = i;
    //    }


    //    public static Complex operator +( Complex a, Complex b )
    //    {
    //        return new Complex( a.real + b.real, a.image + b.image );
    //    }


    //    public Complex Add( Complex z )
    //    {
    //        return new Complex( real + z.real, image + z.image );
    //    }


    //    public static Complex operator -( Complex a, Complex b )
    //    {
    //        return new Complex( a.real - b.real, a.image - b.image );
    //    }


    //    public Complex Sub( Complex z )
    //    {
    //        return new Complex( real - z.real, image - z.image );
    //    }


    //    public static Complex operator *( Complex a, Complex b )
    //    {
    //        double r = a.real * b.real - a.image * b.image;
    //        double i = a.real * b.image + a.image * b.real;
    //        return new Complex( r, i );
    //    }


    //    public static Complex operator *( double b, Complex a )
    //    {
    //        a.real *= b;
    //        a.image *= b;
    //        return a;
    //    }


    //    public Complex Mul( Complex z )
    //    {
    //        double r = real * z.real - image * z.image;
    //        double i = real * z.image + image * z.real;

    //        return new Complex( r, i );
    //    }


    //    public static Complex operator /( Complex a, Complex b )
    //    {
    //        double d = b.real * b.real + b.image * b.image;
    //        double r = ( a.real * b.real + a.image * b.image ) / d;
    //        double i = ( a.image * b.real - a.real * b.image ) / d;
    //        return new Complex( r, i );
    //    }


    //    public static Complex operator /( Complex a, double b )
    //    {
    //        a.real /= b;
    //        a.image /= b;
    //        return a;
    //    }


    //    public Complex Div( Complex z )
    //    {
    //        double d = z.real * z.real + z.image * z.image;
    //        double r = ( real * z.real + image * z.image ) / d;
    //        double i = ( image * z.real - real * z.image ) / d;

    //        return new Complex( r, i );
    //    }


    //    public static double Abs( Complex z )
    //    {
    //        return Math.Sqrt( z.real * z.real + z.image * z.image );
    //    }


    //    public static Complex Exp( Complex z )
    //    {
    //        double e = Math.Exp( z.real );
    //        double r = Math.Cos( z.image );
    //        double i = Math.Sin( z.image );

    //        return new Complex( e * r, e * i );
    //    }

    //}

}
