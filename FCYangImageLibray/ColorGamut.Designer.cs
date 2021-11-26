
namespace FCYangImageLibray
{
    partial class ColorGamut
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.7D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.25D, 0.7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.18D, 0.03D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.7D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.6D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.3D, 0.6D);
            this.chtGamut = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chtGamut)).BeginInit();
            this.SuspendLayout();
            // 
            // chtGamut
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.Interval = 0.1D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.Maximum = 0.8D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "x-axis";
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.Interval = 0.1D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Maximum = 0.9D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "y-axis";
            chartArea1.BackImage = "F:\\iefcyangDesktop\\00000000\\DigitalImageProcessingLearng\\FCYangImageLibray\\NakedC" +
    "olorGamut.png";
            chartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea1.Name = "ChartArea1";
            this.chtGamut.ChartAreas.Add(chartArea1);
            this.chtGamut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtGamut.Location = new System.Drawing.Point(0, 27);
            this.chtGamut.Name = "chtGamut";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series3";
            dataPoint1.Color = System.Drawing.Color.Red;
            dataPoint1.MarkerSize = 10;
            dataPoint1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint2.Color = System.Drawing.Color.Lime;
            dataPoint2.MarkerSize = 10;
            dataPoint2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint3.Color = System.Drawing.Color.Blue;
            dataPoint3.MarkerSize = 10;
            dataPoint3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint4.Color = System.Drawing.Color.Red;
            dataPoint4.MarkerSize = 10;
            dataPoint4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series4";
            dataPoint5.Color = System.Drawing.Color.Black;
            dataPoint5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            dataPoint6.Color = System.Drawing.Color.Black;
            dataPoint6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            this.chtGamut.Series.Add(series1);
            this.chtGamut.Series.Add(series2);
            this.chtGamut.Size = new System.Drawing.Size(384, 338);
            this.chtGamut.TabIndex = 0;
            this.chtGamut.Text = "chart1";
            this.chtGamut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chtGamut_MouseClick);
            // 
            // labTitle
            // 
            this.labTitle.BackColor = System.Drawing.Color.Purple;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTitle.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labTitle.ForeColor = System.Drawing.Color.White;
            this.labTitle.Location = new System.Drawing.Point(0, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(384, 27);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "CIE Chromaticity Diagram";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorGamut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chtGamut);
            this.Controls.Add(this.labTitle);
            this.Name = "ColorGamut";
            this.Size = new System.Drawing.Size(384, 365);
            ((System.ComponentModel.ISupportInitialize)(this.chtGamut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtGamut;
        private System.Windows.Forms.Label labTitle;
    }
}
