using DigitalImageProcessing;
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
        }

        private void btnSine_Click(object sender, EventArgs e)
        {
            Series sine = new Series("Sine");
            sine.ChartType = SeriesChartType.Line;
            sine.Color = Color.Red;
            chart1.Series.Add(sine);

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
                z = Complex.DiscreteFourierTransform(y);
            }
            else
            {
                Complex[] y = new Complex[300];
                for (int c = 0; c < 300; c++)
                {
                    y[c] = new Complex();
                    y[c].real = Math.Sin(c / 3.0);
                    y[c].image = 0;
                    sine.Points.AddXY(c, y[c].real);
                }
                // z = Complex.DiscreteFourierTransform(y);
                z = Complex.RecursiveFFT(y);
            }
 

            Series fourier = new Series("Fourier");
            fourier.ChartType = SeriesChartType.Line;
            fourier.YAxisType = AxisType.Secondary;
            fourier.Color = Color.Blue;
            chart1.Series.Add(fourier);


            for (int c = 0; c < 300; c++)
            {
                fourier.Points.AddXY(c, z[c].real);
            }


        }
    }
}
