﻿using System;
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
            int DFTdir = (_IsInverse) ? -1 : 1;
            double Theta, cosineA, sineA;
            for (int i = 0; i < size; i++)
            {
                outputs.Add(new Complex());
                for (int j = 0; j < size; j++)
                {
                    Theta = (Math.PI * 2 * i * j * DFTdir) / size;
                    cosineA = Math.Cos(Theta);
                    sineA = Math.Sin(Theta);

                    outputs[i].real += inputs[j].real * cosineA - inputs[j].image * sineA;
                    outputs[i].image += inputs[j].real * sineA + inputs[j].image * cosineA;
                }
            }
            return outputs;
        }


        public double real, image;
        
        public Complex()
        {
            real = image = 0.0;
        }

        public Complex(double r, double i)
        {
            real = r;
            image = i;
        }
        public static Complex operator+ (Complex a, Complex b )
        {
            return new Complex(a.real + b.real, a.image + b.image);
        }

        public Complex Add(Complex z)
        {
            return new Complex(real + z.real, image + z.image);
        }

        public static Complex operator- (Complex a, Complex b )
        {
            return new Complex(a.real - b.real, a.image - b.image);
        }

        public Complex Sub(Complex z)
        {
            return new Complex(real - z.real, image - z.image);
        }

        public static Complex operator* (Complex a, Complex b)
        {
            double r = a.real * b.real - a.image * b.image;
            double i = a.real * b.image + a.image * b.real;
            return new Complex(r, i);
        }

        public Complex Mul(Complex z)
        {
            double r = real * z.real - image * z.image;
            double i = real * z.image + image * z.real;

            return new Complex(r, i);
        }

        public static Complex operator/ (Complex a, Complex b)
        {
            double d = b.real * b.real + b.image * b.image;
            double r = (a.real * b.real + a.image * b.image) / d;
            double i = (a.image * b.real - a.real * b.image) / d;
            return new Complex(r, i);
        }

        public Complex Div(Complex z)
        {
            double d = z.real * z.real + z.image * z.image;
            double r = (real * z.real + image * z.image) / d;
            double i = (image * z.real - real * z.image) / d;

            return new Complex(r, i);
        }

        public static double Abs(Complex z)
        {
            return Math.Sqrt(z.real * z.real + z.image * z.image);
        }

        public static Complex Exp(Complex z)
        {
            double e = Math.Exp(z.real);
            double r = Math.Cos(z.image);
            double i = Math.Sin(z.image);

            return new Complex(e * r, e * i);
        }

        public static Complex[] RecursiveFFT(Complex[] a)
        {
            int n = a.Length;
            int n2 = n / 2;

            if (n == 1)
                return a;

            Complex z = new Complex(0.0, 2.0 * Math.PI / n);
            Complex omegaN = Complex.Exp(z);
            Complex omega = new Complex(1.0, 0.0);
            Complex[] a0 = new Complex[n2];
            Complex[] a1 = new Complex[n2];
            Complex[] y0 = new Complex[n2];
            Complex[] y1 = new Complex[n2];
            Complex[] y = new Complex[n];

            for (int i = 0; i < n2; i++)
            {
                a0[i] = new Complex(0.0, 0.0);
                a0[i] = a[2 * i];
                a1[i] = new Complex(0.0, 0.0);
                a1[i] = a[2 * i + 1];
            }

            y0 = RecursiveFFT(a0);
            y1 = RecursiveFFT(a1);

            for (int k = 0; k < n2; k++)
            {
                //y[k] = new Complex(0.0, 0.0);
                //y[k] = y0[k].Add(y1[k].Mul(omega));
                //y[k + n2] = new Complex(0.0, 0.0);
                //y[k + n2] = y0[k].Sub(y1[k].Mul(omega));
                //omega = omega.Mul(omegaN);
                y[k] = new Complex(0.0, 0.0);
                y[k] = y0[k] + ( y1[k] * omega);
                y[k + n2] = new Complex(0.0, 0.0);
                y[k + n2] = y0[k] - ( y1[k] * omega );
                omega *= omegaN;
            }

            return y;
        }

        public static Complex[] DFT(double[] x)
        {
            double pi2oN = 2.0 * Math.PI / x.Length;
            int k, n;
            Complex[] X = new Complex[x.Length];

            for (k = 0; k < x.Length; k++)
            {
                X[k] = new Complex(0.0, 0.0);

                for (n = 0; n < x.Length; n++)
                {
                    X[k].real += x[n] * Math.Cos(pi2oN * k * n);
                    X[k].image -= x[n] * Math.Sin(pi2oN * k * n);
                }

                X[k].real /= x.Length;
                X[k].image /= x.Length;
            }
            return X;
        }



        public static double[] InverseDFT(Complex[] X)
        {
            double[] x = new double[X.Length];
            double imag, pi2oN = 2.0 * Math.PI / X.Length;

            for (int n = 0; n < X.Length; n++)
            {
                imag = x[n] = 0.0;

                for (int k = 0; k < X.Length; k++)
                {
                    x[n] += X[k].real * Math.Cos(pi2oN * k * n)
                          - X[k].image * Math.Sin(pi2oN * k * n);
                    imag += X[k].real * Math.Sin(pi2oN * k * n)
                          + X[k].image * Math.Cos(pi2oN * k * n);
                }
            }
            return x;
        }

        // This computes an in-place complex-to-complex FFT  
        // x and y are the real and imaginary arrays of 2^m points. 
        // dir =  1 gives forward transform 
        // dir = -1 gives reverse transform  
        // see http://astronomy.swin.edu.au/~pbourke/analysis/dft/ 

        public static void FFT(short dir, int m, double[] x, double[] y)
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tx, ty, t1, t2, u1, u2, z;

            // Calculate the number of points 
            n = 1;
            for (i = 0; i < m; i++)
                n *= 2;

            // Do the bit reversal 
            i2 = n >> 1;
            j = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    tx = x[i];
                    ty = y[i];
                    x[i] = x[j];
                    y[i] = y[j];
                    x[j] = tx;
                    y[j] = ty;
                }
                k = i2;
                while (k <= j)
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

            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0;
                u2 = 0.0;

                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < n; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * x[i1] - u2 * y[i1];
                        t2 = u1 * y[i1] + u2 * x[i1];
                        x[i1] = x[i] - t1;
                        y[i1] = y[i] - t2;
                        x[i] += t1;
                        y[i] += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = Math.Sqrt((1.0 - c1) / 2.0);
                if (dir == 1)
                    c2 = -c2;
                c1 = Math.Sqrt((1.0 + c1) / 2.0);
            }

            // Scaling for forward transform 
            if (dir == 1)
            {
                for (i = 0; i < n; i++)
                {
                    x[i] /= n;
                    y[i] /= n;
                }
            }
        }
    }
}
