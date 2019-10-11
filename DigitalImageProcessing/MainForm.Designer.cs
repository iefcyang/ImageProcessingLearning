namespace DigitalImageProcessing
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.flpMultiple = new System.Windows.Forms.FlowLayoutPanel();
            this.spcThird = new System.Windows.Forms.SplitContainer();
            this.pcbMain = new System.Windows.Forms.PictureBox();
            this.pcbSecond = new System.Windows.Forms.PictureBox();
            this.spcSecond = new System.Windows.Forms.SplitContainer();
            this.cbxSizeMode = new System.Windows.Forms.ComboBox();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagTTransform = new System.Windows.Forms.TabPage();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnAddPixelValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudShift = new System.Windows.Forms.NumericUpDown();
            this.pagGray = new System.Windows.Forms.TabPage();
            this.rdbGray = new System.Windows.Forms.RadioButton();
            this.rdbBW = new System.Windows.Forms.RadioButton();
            this.btnGenerateGray = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.barProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.chtHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbxRGB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcThird)).BeginInit();
            this.spcThird.Panel1.SuspendLayout();
            this.spcThird.Panel2.SuspendLayout();
            this.spcThird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcSecond)).BeginInit();
            this.spcSecond.Panel1.SuspendLayout();
            this.spcSecond.Panel2.SuspendLayout();
            this.spcSecond.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pagTTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShift)).BeginInit();
            this.pagGray.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.BackColor = System.Drawing.Color.Black;
            this.spcMain.Panel1.Controls.Add(this.flpMultiple);
            this.spcMain.Panel1.Controls.Add(this.spcThird);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcSecond);
            this.spcMain.Size = new System.Drawing.Size(1058, 526);
            this.spcMain.SplitterDistance = 766;
            this.spcMain.SplitterWidth = 5;
            this.spcMain.TabIndex = 0;
            // 
            // flpMultiple
            // 
            this.flpMultiple.Location = new System.Drawing.Point(28, 84);
            this.flpMultiple.Name = "flpMultiple";
            this.flpMultiple.Size = new System.Drawing.Size(707, 418);
            this.flpMultiple.TabIndex = 2;
            this.flpMultiple.Visible = false;
            // 
            // spcThird
            // 
            this.spcThird.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcThird.Location = new System.Drawing.Point(7, 6);
            this.spcThird.Name = "spcThird";
            // 
            // spcThird.Panel1
            // 
            this.spcThird.Panel1.Controls.Add(this.pcbMain);
            // 
            // spcThird.Panel2
            // 
            this.spcThird.Panel2.Controls.Add(this.pcbSecond);
            this.spcThird.Size = new System.Drawing.Size(751, 510);
            this.spcThird.SplitterDistance = 371;
            this.spcThird.TabIndex = 1;
            // 
            // pcbMain
            // 
            this.pcbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pcbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbMain.Location = new System.Drawing.Point(0, 0);
            this.pcbMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbMain.Name = "pcbMain";
            this.pcbMain.Size = new System.Drawing.Size(371, 510);
            this.pcbMain.TabIndex = 0;
            this.pcbMain.TabStop = false;
            // 
            // pcbSecond
            // 
            this.pcbSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pcbSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbSecond.Location = new System.Drawing.Point(0, 0);
            this.pcbSecond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbSecond.Name = "pcbSecond";
            this.pcbSecond.Size = new System.Drawing.Size(376, 510);
            this.pcbSecond.TabIndex = 1;
            this.pcbSecond.TabStop = false;
            // 
            // spcSecond
            // 
            this.spcSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSecond.Location = new System.Drawing.Point(0, 0);
            this.spcSecond.Name = "spcSecond";
            this.spcSecond.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcSecond.Panel1
            // 
            this.spcSecond.Panel1.Controls.Add(this.cbxSizeMode);
            this.spcSecond.Panel1.Controls.Add(this.btnResume);
            this.spcSecond.Panel1.Controls.Add(this.btnOpen);
            // 
            // spcSecond.Panel2
            // 
            this.spcSecond.Panel2.Controls.Add(this.tabMain);
            this.spcSecond.Size = new System.Drawing.Size(287, 526);
            this.spcSecond.SplitterDistance = 172;
            this.spcSecond.TabIndex = 1;
            // 
            // cbxSizeMode
            // 
            this.cbxSizeMode.FormattingEnabled = true;
            this.cbxSizeMode.Location = new System.Drawing.Point(14, 111);
            this.cbxSizeMode.Name = "cbxSizeMode";
            this.cbxSizeMode.Size = new System.Drawing.Size(121, 24);
            this.cbxSizeMode.TabIndex = 2;
            this.cbxSizeMode.SelectedIndexChanged += new System.EventHandler(this.cbxSizeMode_SelectedIndexChanged);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(14, 42);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 1;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(14, 13);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagTTransform);
            this.tabMain.Controls.Add(this.pagGray);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(287, 350);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.TabMain_TabIndexChanged);
            // 
            // pagTTransform
            // 
            this.pagTTransform.Controls.Add(this.cbxRGB);
            this.pagTTransform.Controls.Add(this.chtHistogram);
            this.pagTTransform.Controls.Add(this.btnLog);
            this.pagTTransform.Controls.Add(this.btnHistogram);
            this.pagTTransform.Controls.Add(this.btnAddPixelValue);
            this.pagTTransform.Controls.Add(this.label1);
            this.pagTTransform.Controls.Add(this.nudShift);
            this.pagTTransform.Location = new System.Drawing.Point(4, 25);
            this.pagTTransform.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagTTransform.Name = "pagTTransform";
            this.pagTTransform.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagTTransform.Size = new System.Drawing.Size(279, 321);
            this.pagTTransform.TabIndex = 0;
            this.pagTTransform.Text = "Sapce Transformation";
            this.pagTTransform.UseVisualStyleBackColor = true;
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(10, 96);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(171, 27);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "Log Transformation";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(188, 63);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(85, 27);
            this.btnHistogram.TabIndex = 3;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnAddPixelValue
            // 
            this.btnAddPixelValue.Location = new System.Drawing.Point(9, 63);
            this.btnAddPixelValue.Name = "btnAddPixelValue";
            this.btnAddPixelValue.Size = new System.Drawing.Size(171, 27);
            this.btnAddPixelValue.TabIndex = 2;
            this.btnAddPixelValue.Text = "Value Shifted";
            this.btnAddPixelValue.UseVisualStyleBackColor = true;
            this.btnAddPixelValue.Click += new System.EventHandler(this.btnAddPixelValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pixel Value Added";
            // 
            // nudShift
            // 
            this.nudShift.Location = new System.Drawing.Point(9, 34);
            this.nudShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudShift.Name = "nudShift";
            this.nudShift.Size = new System.Drawing.Size(61, 23);
            this.nudShift.TabIndex = 0;
            this.nudShift.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // pagGray
            // 
            this.pagGray.Controls.Add(this.rdbGray);
            this.pagGray.Controls.Add(this.rdbBW);
            this.pagGray.Controls.Add(this.btnGenerateGray);
            this.pagGray.Location = new System.Drawing.Point(4, 22);
            this.pagGray.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagGray.Name = "pagGray";
            this.pagGray.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagGray.Size = new System.Drawing.Size(279, 324);
            this.pagGray.TabIndex = 1;
            this.pagGray.Text = "Gray Image and Significent Digits";
            this.pagGray.UseVisualStyleBackColor = true;
            // 
            // rdbGray
            // 
            this.rdbGray.AutoSize = true;
            this.rdbGray.Checked = true;
            this.rdbGray.Location = new System.Drawing.Point(10, 22);
            this.rdbGray.Name = "rdbGray";
            this.rdbGray.Size = new System.Drawing.Size(136, 20);
            this.rdbGray.TabIndex = 5;
            this.rdbGray.TabStop = true;
            this.rdbGray.Text = "Component in Gray";
            this.rdbGray.UseVisualStyleBackColor = true;
            // 
            // rdbBW
            // 
            this.rdbBW.AutoSize = true;
            this.rdbBW.Location = new System.Drawing.Point(12, 48);
            this.rdbBW.Name = "rdbBW";
            this.rdbBW.Size = new System.Drawing.Size(134, 20);
            this.rdbBW.TabIndex = 4;
            this.rdbBW.Text = "Component in B/W";
            this.rdbBW.UseVisualStyleBackColor = true;
            // 
            // btnGenerateGray
            // 
            this.btnGenerateGray.Location = new System.Drawing.Point(10, 74);
            this.btnGenerateGray.Name = "btnGenerateGray";
            this.btnGenerateGray.Size = new System.Drawing.Size(261, 33);
            this.btnGenerateGray.TabIndex = 3;
            this.btnGenerateGray.Text = "Generate Gray Image and bit B/W";
            this.btnGenerateGray.UseVisualStyleBackColor = true;
            this.btnGenerateGray.Click += new System.EventHandler(this.btnGenerateGray_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barProgress,
            this.labMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1058, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // barProgress
            // 
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // labMessage
            // 
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(841, 17);
            this.labMessage.Spring = true;
            // 
            // chtHistogram
            // 
            this.chtHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chtHistogram.ChartAreas.Add(chartArea1);
            this.chtHistogram.Location = new System.Drawing.Point(6, 135);
            this.chtHistogram.Name = "chtHistogram";
            this.chtHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chtHistogram.Series.Add(series1);
            this.chtHistogram.Size = new System.Drawing.Size(265, 179);
            this.chtHistogram.TabIndex = 4;
            this.chtHistogram.Text = "chart1";
            // 
            // cbxRGB
            // 
            this.cbxRGB.FormattingEnabled = true;
            this.cbxRGB.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.cbxRGB.Location = new System.Drawing.Point(188, 96);
            this.cbxRGB.Name = "cbxRGB";
            this.cbxRGB.Size = new System.Drawing.Size(83, 24);
            this.cbxRGB.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 548);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Digital Image Processing Learning";
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcThird.Panel1.ResumeLayout(false);
            this.spcThird.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcThird)).EndInit();
            this.spcThird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSecond)).EndInit();
            this.spcSecond.Panel1.ResumeLayout(false);
            this.spcSecond.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSecond)).EndInit();
            this.spcSecond.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pagTTransform.ResumeLayout(false);
            this.pagTTransform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShift)).EndInit();
            this.pagGray.ResumeLayout(false);
            this.pagGray.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.PictureBox pcbMain;
        private System.Windows.Forms.SplitContainer spcSecond;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pagTTransform;
        private System.Windows.Forms.Button btnAddPixelValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudShift;
        private System.Windows.Forms.ComboBox cbxSizeMode;
        private System.Windows.Forms.SplitContainer spcThird;
        private System.Windows.Forms.PictureBox pcbSecond;
        private System.Windows.Forms.FlowLayoutPanel flpMultiple;
        private System.Windows.Forms.TabPage pagGray;
        private System.Windows.Forms.RadioButton rdbGray;
        private System.Windows.Forms.RadioButton rdbBW;
        private System.Windows.Forms.Button btnGenerateGray;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar barProgress;
        private System.Windows.Forms.ToolStripStatusLabel labMessage;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.ComboBox cbxRGB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtHistogram;
    }
}

