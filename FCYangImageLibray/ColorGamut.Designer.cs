
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.7D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.25D, 0.7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.18D, 0.03D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.7D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.6D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.3D, 0.6D);
            this.chtGamut = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labMap = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labChromaticity = new System.Windows.Forms.Label();
            this.pcbColorMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chtGamut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorMap)).BeginInit();
            this.SuspendLayout();
            // 
            // chtGamut
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.Interval = 0.1D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.Maximum = 0.8D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "x-axis";
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY.Interval = 0.1D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.Maximum = 0.9D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "y-axis";
            chartArea2.BackImage = "D:\\2021 C Sharp Work\\2021 GitHubProjects\\Digital Image Processing\\FCYangImageLibr" +
    "ay\\NakedColorGamut.png";
            chartArea2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea2.Name = "ChartArea1";
            this.chtGamut.ChartAreas.Add(chartArea2);
            this.chtGamut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtGamut.Location = new System.Drawing.Point(0, 31);
            this.chtGamut.Name = "chtGamut";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Black;
            series3.Name = "Series3";
            dataPoint7.Color = System.Drawing.Color.Black;
            dataPoint7.MarkerSize = 10;
            dataPoint7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint8.Color = System.Drawing.Color.Black;
            dataPoint8.MarkerSize = 10;
            dataPoint8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint9.Color = System.Drawing.Color.Black;
            dataPoint9.MarkerSize = 10;
            dataPoint9.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            dataPoint10.Color = System.Drawing.Color.Black;
            dataPoint10.MarkerSize = 10;
            dataPoint10.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series3.Points.Add(dataPoint7);
            series3.Points.Add(dataPoint8);
            series3.Points.Add(dataPoint9);
            series3.Points.Add(dataPoint10);
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series4";
            dataPoint11.Color = System.Drawing.Color.Black;
            dataPoint11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            dataPoint12.Color = System.Drawing.Color.Black;
            dataPoint12.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Points.Add(dataPoint11);
            series4.Points.Add(dataPoint12);
            this.chtGamut.Series.Add(series3);
            this.chtGamut.Series.Add(series4);
            this.chtGamut.Size = new System.Drawing.Size(403, 266);
            this.chtGamut.TabIndex = 0;
            this.chtGamut.Text = "chart1";
            this.chtGamut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chtGamut_MouseClick);
            // 
            // labMap
            // 
            this.labMap.BackColor = System.Drawing.Color.Maroon;
            this.labMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.labMap.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.labChromaticity.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtGamut;
        private System.Windows.Forms.Label labMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labChromaticity;
        private System.Windows.Forms.PictureBox pcbColorMap;
    }
}
