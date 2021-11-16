
using FCYangImageLibray;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FourierTransformationTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            nudPower_ValueChanged( null, null );
        }

        private void btnSine_Click(object sender, EventArgs e)
        {
            Series sine = new Series("Sine");
            sine.ChartType = SeriesChartType.Line;
            sine.Color = Color.Red;
            chtMain.Series.Add(sine);

            bool realInput = false;// true;
            Complex[] z;
            if (realInput)
            {
                double[] y = new double[300];
                for (int c = 0; c < 300; c++)
                {
                    y[c] = Math.Sin(c / 3.0);
                    sine.Points.AddXY(c, y[c]);
                }
                z = Fourier.Discrete1DTransform(y);
            }
            else
            {
                Complex[] y = new Complex[300];
                for (int c = 0; c < 300; c++)
                {
                    y[c].real = Math.Sin(c / 3.0);
                    y[c].imaginary = 0;
                    sine.Points.AddXY(c, y[c].real);
                }
                // z = Complex.DiscreteFourierTransform(y);
                z = Fourier.RecursiveFFT(y);
            }
 

            Series fourier = new Series("Fourier");
            fourier.ChartType = SeriesChartType.Line;
            fourier.YAxisType = AxisType.Secondary;
            fourier.Color = Color.Blue;
            chtMain.Series.Add(fourier);


            for (int c = 0; c < 300; c++)
            {
                fourier.Points.AddXY(c, z[c].real);
            }


        }

        private void btnConstant_Click(object sender, EventArgs e)
        {
            chtMain.Series.Clear();
            Series s = new Series("Ranged Constant Transform");
            s.ChartType = SeriesChartType.Line;
            double A = 1.0, W = 2.0;
            double temp = A / Math.PI;
            for( double mu = -10.0; mu <= 10.0; mu += 0.05)
            {
                double y = temp * Math.Sin(Math.PI * mu * W) / mu;
                s.Points.AddXY(mu, y);
            }
            chtMain.Series.Add(s);
        }

        private void btnFourierTest_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            rtbOutput.Clear( );

            DateTime start;
            int power = (int) nudPower.Value; // 11;
            Complex[ ] C = Complex.GetArray(200, power );
            rtbOutput.AppendText( "Original C: \n" );

            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.ArrayText( C ) );

            rtbOutput.AppendText( "\n\nDiscrete FT : \n" );
            start = DateTime.Now;
            Complex[ ] X = Fourier.Discrete1DTransform( C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText(Complex.ArrayText(X) );

            rtbOutput.AppendText( "\n\nRecursive FFT : \n" );
            start = DateTime.Now;
            X = Fourier.RecursiveFFT( C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.ArrayText( X ) );


            Complex[ ] CP = new Complex[ C.Length ];
            for( int i = 0 ; i < CP.Length ; i++ )
            {
                CP[ i ].real = C[ i ].real;
                CP[ i ].imaginary = C[ i ].imaginary;
            }


            rtbOutput.AppendText( "\n\nIn-Place Fast FT : \n" );
            start = DateTime.Now;
            Fourier.FastFourierTransform(  C, true );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.ArrayText( C ) );


            rtbOutput.AppendText( "\n\nIn-Place Recursive FFT : \n" );
            start = DateTime.Now;
            Fourier.InPlaceRecursiveFFT( CP );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.ArrayText( CP ) );
            Cursor = Cursors.Default;
        }

        private void nudPower_ValueChanged( object sender, EventArgs e )
        {
            label1.Text = $"n = 2 Power of {nudPower.Value} = {(int) Math.Pow( 2, (int) nudPower.Value )}";
        }

        int displayPowerLimit = 6;
        private void btn2DFFTTest_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            rtbOutput.Clear( );

            DateTime start;
            int power = (int) nudPower.Value; // 11;
            Complex[, ] C = Complex.Get2DMatrix( 200, power, ckbNoImageary.Checked );
            rtbOutput.AppendText( "Original C: \n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.MatrixText( C ) );

            int height = C.GetLength(0), width = C.GetLength(1);
            bool positive = true;
            if (ckbShiftCenter.Checked)
            {
                for (int r = 0; r < height; r++)
                {
                    positive = r % 2 == 0;
                    for (int c = 0; c < width; c++)
                    {
                        if (!positive)
                        {
                            C[r, c].real = -C[r, c].real;
                            C[r, c].imaginary = -C[r, c].imaginary;
                        }
                        positive = !positive;
                    }
                }
                    rtbOutput.AppendText("\n\nAfter Shift to Center C: \n");
                    if (power <= displayPowerLimit ) rtbOutput.AppendText(Complex.MatrixText(C));
            }

            rtbOutput.AppendText( "\n\nDiscrete Forward FT : \n" );
            start = DateTime.Now;
            Complex[, ] X = Fourier.Discrete2DTransform( C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.MatrixText( X ) );


            rtbOutput.AppendText( "\n\nDiscrete FAST Forward FT : \n" );
            start = DateTime.Now;
            Complex[ , ] XX = Fourier.Discrete2DTransform( C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.MatrixText( XX ) );



            rtbOutput.AppendText( "\n\n+ Inverse FFT : \n" );
            start = DateTime.Now;
            C = Fourier.Discrete2DInverseTransform( X );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.MatrixText( C ) );


            rtbOutput.AppendText( "\n\n+ FAST Inverse FFT : \n" );
            start = DateTime.Now;
            Complex[,]  CC = Fourier.Discrete2DInverseTransform( XX );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= displayPowerLimit ) rtbOutput.AppendText( Complex.MatrixText( CC ) );




            if (ckbShiftCenter.Checked)
            {
                for (int r = 0; r < height; r++)
                {
                    positive = r % 2 == 0;
                    for (int c = 0; c < width; c++)
                    {
                        if (!positive)
                        {
                            C[r, c].real = -C[r, c].real;
                            C[r, c].imaginary = -C[r, c].imaginary;
                        }
                        positive = !positive;
                    }
                }
                    rtbOutput.AppendText("\n\nAfter Shift back to Original C: \n");
                    if (power <= displayPowerLimit ) rtbOutput.AppendText(Complex.MatrixText(C));
            }

            Cursor = Cursors.Default;
        }
    }
}
