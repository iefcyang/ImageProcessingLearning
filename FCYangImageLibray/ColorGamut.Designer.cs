
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorGamut));
            this.chtGamut = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labMap = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labChromaticity = new System.Windows.Forms.Label();
            this.pcbColorMap = new System.Windows.Forms.PictureBox();
            this.pcbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chtGamut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).BeginInit();
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
            chartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea1.Name = "ChartArea1";
            this.chtGamut.ChartAreas.Add(chartArea1);
            this.chtGamut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtGamut.Location = new System.Drawing.Point(0, 31);
            this.chtGamut.Name = "chtGamut";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Black;
            series1.Name = "Series3";
            dataPoint1.Color = System.Drawing.Color.Black;
            dataPoint1.MarkerSize = 10;
            dataPoint1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint2.Color = System.Drawing.Color.Black;
            dataPoint2.MarkerSize = 10;
            dataPoint2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint3.Color = System.Drawing.Color.Black;
            dataPoint3.MarkerSize = 10;
            dataPoint3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint4.Color = System.Drawing.Color.Black;
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
            this.chtGamut.Size = new System.Drawing.Size(403, 266);
            this.chtGamut.TabIndex = 0;
            this.chtGamut.Text = "chart1";
            this.chtGamut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chtGamut_MouseClick);
            // 
            // labMap
            // 
            this.labMap.BackColor = System.Drawing.Color.Maroon;
            this.labMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.labMap.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMap.ForeColor = System.Drawing.Color.White;
            this.labMap.Location = new System.Drawing.Point(0, 0);
            this.labMap.Name = "labMap";
            this.labMap.Size = new System.Drawing.Size(403, 31);
            this.labMap.TabIndex = 1;
            this.labMap.Text = "Custom Color Map";
            this.labMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chtGamut);
            this.splitContainer1.Panel1.Controls.Add(this.labChromaticity);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pcbImage);
            this.splitContainer1.Panel2.Controls.Add(this.pcbColorMap);
            this.splitContainer1.Panel2.Controls.Add(this.labMap);
            this.splitContainer1.Size = new System.Drawing.Size(403, 579);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 2;
            // 
            // labChromaticity
            // 
            this.labChromaticity.BackColor = System.Drawing.Color.Purple;
            this.labChromaticity.Dock = System.Windows.Forms.DockStyle.Top;
            this.labChromaticity.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labChromaticity.ForeColor = System.Drawing.Color.White;
            this.labChromaticity.Location = new System.Drawing.Point(0, 0);
            this.labChromaticity.Name = "labChromaticity";
            this.labChromaticity.Size = new System.Drawing.Size(403, 31);
            this.labChromaticity.TabIndex = 3;
            this.labChromaticity.Text = "CIE Chromaticity Diagram";
            this.labChromaticity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcbColorMap
            // 
            this.pcbColorMap.BackColor = System.Drawing.Color.Black;
            this.pcbColorMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbColorMap.Location = new System.Drawing.Point(0, 31);
            this.pcbColorMap.Name = "pcbColorMap";
            this.pcbColorMap.Size = new System.Drawing.Size(403, 247);
            this.pcbColorMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbColorMap.TabIndex = 2;
            this.pcbColorMap.TabStop = false;
            // 
            // pcbImage
            // 
            this.pcbImage.Image = ((System.Drawing.Image)(resources.GetObject("pcbImage.Image")));
            this.pcbImage.Location = new System.Drawing.Point(202, 69);
            this.pcbImage.Name = "pcbImage";
            this.pcbImage.Size = new System.Drawing.Size(121, 96);
            this.pcbImage.TabIndex = 3;
            this.pcbImage.TabStop = false;
            this.pcbImage.Visible = false;
            // 
            // ColorGamut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "ColorGamut";
            this.Size = new System.Drawing.Size(403, 579);
            ((System.ComponentModel.ISupportInitialize)(this.chtGamut)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtGamut;
        private System.Windows.Forms.Label labMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labChromaticity;
        private System.Windows.Forms.PictureBox pcbColorMap;
        private System.Windows.Forms.PictureBox pcbImage;
    }
}
