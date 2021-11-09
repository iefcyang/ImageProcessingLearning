﻿using DigitalImageProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                z = Fourier.DiscreteFourierTransform(y);
            }
            else
            {
                Complex[] y = new Complex[300];
                for (int c = 0; c < 300; c++)
                {
                    y[c].real = Math.Sin(c / 3.0);
                    y[c].image = 0;
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

            if( power <= 10) rtbOutput.AppendText( Complex.ArrayText( C ) );

            rtbOutput.AppendText( "\n\nDiscrete FT : \n" );
            start = DateTime.Now;
            Complex[ ] X = Fourier.DiscreteFourierTransform( C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= 10 ) rtbOutput.AppendText(Complex.ArrayText(X) );

            rtbOutput.AppendText( "\n\nRecursive FFT : \n" );
            start = DateTime.Now;
            X = Fourier.RecursiveFFT( C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= 10 ) rtbOutput.AppendText( Complex.ArrayText( X ) );


            Complex[ ] CP = new Complex[ C.Length ];
            for( int i = 0 ; i < CP.Length ; i++ )
            {
                CP[ i ].real = C[ i ].real;
                CP[ i ].image = C[ i ].image;
            }


            rtbOutput.AppendText( "\n\nIn-Place Fast FT : \n" );
            start = DateTime.Now;
            Fourier.FastFourierTransform( true,  C );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= 10 ) rtbOutput.AppendText( Complex.ArrayText( C ) );


            rtbOutput.AppendText( "\n\nIn-Place Recursive FFT : \n" );
            start = DateTime.Now;
            Fourier.InPlaceRecursiveFFT( CP );
            rtbOutput.AppendText( $"\nTime Used: {DateTime.Now - start}\n" );
            if( power <= 10 ) rtbOutput.AppendText( Complex.ArrayText( CP ) );
            Cursor = Cursors.Default;
        }

        private void nudPower_ValueChanged( object sender, EventArgs e )
        {
            label1.Text = $"n = 2 Power of {nudPower.Value} = {(int) Math.Pow( 2, (int) nudPower.Value )}";
        }
    }
}
