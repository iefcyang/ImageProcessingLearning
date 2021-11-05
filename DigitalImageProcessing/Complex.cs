using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalImageProcessing
{
    public class Complex
    {

        //  離散傅立葉轉換僅處理1維資訊，因此對於影像屬於2維資訊需進行兩次的離散傅立葉轉換。
        // 針對row進行DFT，後針對column進行DFT方能得到目標影像。

        public List<Complex> transform( List<Complex> inputs, bool _IsInverse, List<Complex> outputs )
        {
            int size = inputs.Count;
            int DFTdir = ( _IsInverse ) ? -1 : 1;
            double Theta, cosineA, sineA;
            for( int i = 0 ; i < size ; i++ )
            {
                outputs.Add( new Complex( ) );
                for( int j = 0 ; j < size ; j++ )
                {
                    Theta = ( Math.PI * 2 * i * j * DFTdir ) / size;
                    cosineA = Math.Cos( Theta );
                    sineA = Math.Sin( Theta );

                    outputs[ i ].real += inputs[ j ].real * cosineA - inputs[ j ].image * sineA;
                    outputs[ i ].image += inputs[ j ].real * sineA + inputs[ j ].image * cosineA;
                }
            }
            return outputs;
        }


        public double real, image;

        public Complex( )
        {
            real = image = 0.0;
        }


        public Complex( double r, double i )
        {
            real = r;
            image = i;
        }


        public static Complex operator +( Complex a, Complex b )
        {
            return new Complex( a.real + b.real, a.image + b.image );
        }


        public Complex Add( Complex z )
        {
            return new Complex( real + z.real, image + z.image );
        }


        public static Complex operator -( Complex a, Complex b )
        {
            return new Complex( a.real - b.real, a.image - b.image );
        }


        public Complex Sub( Complex z )
        {
            return new Complex( real - z.real, image - z.image );
        }


        public static Complex operator *( Complex a, Complex b )
        {
            double r = a.real * b.real - a.image * b.image;
            double i = a.real * b.image + a.image * b.real;
            return new Complex( r, i );
        }


        public static Complex operator *( double b, Complex a )
        {
            a.real *= b;
            a.image *= b;
            return a;
        }


        public Complex Mul( Complex z )
        {
            double r = real * z.real - image * z.image;
            double i = real * z.image + image * z.real;

            return new Complex( r, i );
        }


        public static Complex operator /( Complex a, Complex b )
        {
            double d = b.real * b.real + b.image * b.image;
            double r = ( a.real * b.real + a.image * b.image ) / d;
            double i = ( a.image * b.real - a.real * b.image ) / d;
            return new Complex( r, i );
        }


        public static Complex operator /( Complex a, double b )
        {
            a.real /= b;
            a.image /= b;
            return a;
        }


        public Complex Div( Complex z )
        {
            double d = z.real * z.real + z.image * z.image;
            double r = ( real * z.real + image * z.image ) / d;
            double i = ( image * z.real - real * z.image ) / d;

            return new Complex( r, i );
        }


        public static double Abs( Complex z )
        {
            return Math.Sqrt( z.real * z.real + z.image * z.image );
        }


        public static Complex Exp( Complex z )
        {
            double e = Math.Exp( z.real );
            double r = Math.Cos( z.image );
            double i = Math.Sin( z.image );

            return new Complex( e * r, e * i );
        }

    }


}
