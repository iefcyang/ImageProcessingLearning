﻿namespace _2021HWK03
{
    partial class MainFromHWK3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pcbOriginal = new System.Windows.Forms.PictureBox();
            this.labOriginal = new System.Windows.Forms.Label();
            this.pcbResults = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbWeightedGray = new System.Windows.Forms.RadioButton();
            this.rdbAverageGray = new System.Windows.Forms.RadioButton();
            this.rdbColor = new System.Windows.Forms.RadioButton();
            this.ckbTurbo = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFilters = new System.Windows.Forms.ComboBox();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.dgvMask = new System.Windows.Forms.DataGridView();
            this.nudCols = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbPositive = new System.Windows.Forms.RadioButton();
            this.rdbABsolute = new System.Windows.Forms.RadioButton();
            this.rdbMiddleMap = new System.Windows.Forms.RadioButton();
            this.btnLaplacian = new System.Windows.Forms.Button();
            this.txbSTD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMarr = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            this.nudMarrHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMarrWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbResults)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarrHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarrWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1052, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.openToolStripMenuItem.Text = "Open ...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1052, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labMessage
            // 
            this.labMessage.ForeColor = System.Drawing.Color.Purple;
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(1035, 17);
            this.labMessage.Spring = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1052, 602);
            this.splitContainer1.SplitterDistance = 764;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(764, 602);
            this.splitContainer2.SplitterDistance = 500;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pcbOriginal);
            this.splitContainer4.Panel1.Controls.Add(this.labOriginal);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pcbResults);
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Size = new System.Drawing.Size(764, 500);
            this.splitContainer4.SplitterDistance = 379;
            this.splitContainer4.TabIndex = 1;
            // 
            // pcbOriginal
            // 
            this.pcbOriginal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbOriginal.Location = new System.Drawing.Point(0, 29);
            this.pcbOriginal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbOriginal.Name = "pcbOriginal";
            this.pcbOriginal.Size = new System.Drawing.Size(379, 471);
            this.pcbOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbOriginal.TabIndex = 0;
            this.pcbOriginal.TabStop = false;
            // 
            // labOriginal
            // 
            this.labOriginal.BackColor = System.Drawing.Color.Green;
            this.labOriginal.Dock = System.Windows.Forms.DockStyle.Top;
            this.labOriginal.ForeColor = System.Drawing.Color.White;
            this.labOriginal.Location = new System.Drawing.Point(0, 0);
            this.labOriginal.Name = "labOriginal";
            this.labOriginal.Size = new System.Drawing.Size(379, 29);
            this.labOriginal.TabIndex = 1;
            this.labOriginal.Text = "Original";
            this.labOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcbResults
            // 
            this.pcbResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbResults.Location = new System.Drawing.Point(0, 29);
            this.pcbResults.Name = "pcbResults";
            this.pcbResults.Size = new System.Drawing.Size(381, 471);
            this.pcbResults.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbResults.TabIndex = 0;
            this.pcbResults.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Maroon;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filtered";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(283, 602);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ckbTurbo);
            this.tabPage1.Controls.Add(this.btnApply);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbxFilters);
            this.tabPage1.Controls.Add(this.nudRows);
            this.tabPage1.Controls.Add(this.dgvMask);
            this.tabPage1.Controls.Add(this.nudCols);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 573);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "(1) Filtering";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbWeightedGray);
            this.groupBox1.Controls.Add(this.rdbAverageGray);
            this.groupBox1.Controls.Add(this.rdbColor);
            this.groupBox1.Location = new System.Drawing.Point(11, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channels";
            // 
            // rdbWeightedGray
            // 
            this.rdbWeightedGray.AutoSize = true;
            this.rdbWeightedGray.Location = new System.Drawing.Point(18, 74);
            this.rdbWeightedGray.Name = "rdbWeightedGray";
            this.rdbWeightedGray.Size = new System.Drawing.Size(111, 20);
            this.rdbWeightedGray.TabIndex = 2;
            this.rdbWeightedGray.Text = "Weighted Gray";
            this.rdbWeightedGray.UseVisualStyleBackColor = true;
            // 
            // rdbAverageGray
            // 
            this.rdbAverageGray.AutoSize = true;
            this.rdbAverageGray.Location = new System.Drawing.Point(18, 48);
            this.rdbAverageGray.Name = "rdbAverageGray";
            this.rdbAverageGray.Size = new System.Drawing.Size(102, 20);
            this.rdbAverageGray.TabIndex = 1;
            this.rdbAverageGray.Text = "Average Gray";
            this.rdbAverageGray.UseVisualStyleBackColor = true;
            // 
            // rdbColor
            // 
            this.rdbColor.AutoSize = true;
            this.rdbColor.Checked = true;
            this.rdbColor.Location = new System.Drawing.Point(18, 22);
            this.rdbColor.Name = "rdbColor";
            this.rdbColor.Size = new System.Drawing.Size(105, 20);
            this.rdbColor.TabIndex = 0;
            this.rdbColor.TabStop = true;
            this.rdbColor.Text = "Color Original";
            this.rdbColor.UseVisualStyleBackColor = true;
            // 
            // ckbTurbo
            // 
            this.ckbTurbo.AutoSize = true;
            this.ckbTurbo.Location = new System.Drawing.Point(11, 402);
            this.ckbTurbo.Name = "ckbTurbo";
            this.ckbTurbo.Size = new System.Drawing.Size(61, 20);
            this.ckbTurbo.TabIndex = 7;
            this.ckbTurbo.Text = "Turbo";
            this.ckbTurbo.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(11, 428);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(258, 31);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxFilters
            // 
            this.cbxFilters.FormattingEnabled = true;
            this.cbxFilters.Items.AddRange(new object[] {
            "Custom",
            "Box"});
            this.cbxFilters.Location = new System.Drawing.Point(11, 37);
            this.cbxFilters.Name = "cbxFilters";
            this.cbxFilters.Size = new System.Drawing.Size(254, 24);
            this.cbxFilters.TabIndex = 3;
            this.cbxFilters.SelectedIndexChanged += new System.EventHandler(this.cbxFilters_SelectedIndexChanged);
            // 
            // nudRows
            // 
            this.nudRows.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudRows.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRows.Location = new System.Drawing.Point(80, 67);
            this.nudRows.Maximum = new decimal(new int[] {
            299,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(47, 23);
            this.nudRows.TabIndex = 0;
            this.nudRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudRows.ValueChanged += new System.EventHandler(this.nudRows_ValueChanged);
            // 
            // dgvMask
            // 
            this.dgvMask.AllowUserToAddRows = false;
            this.dgvMask.AllowUserToDeleteRows = false;
            this.dgvMask.AllowUserToOrderColumns = true;
            this.dgvMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMask.Location = new System.Drawing.Point(11, 98);
            this.dgvMask.Name = "dgvMask";
            this.dgvMask.RowTemplate.Height = 24;
            this.dgvMask.Size = new System.Drawing.Size(258, 154);
            this.dgvMask.TabIndex = 2;
            // 
            // nudCols
            // 
            this.nudCols.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudCols.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCols.Location = new System.Drawing.Point(192, 67);
            this.nudCols.Maximum = new decimal(new int[] {
            299,
            0,
            0,
            0});
            this.nudCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudCols.Name = "nudCols";
            this.nudCols.Size = new System.Drawing.Size(47, 23);
            this.nudCols.TabIndex = 1;
            this.nudCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudCols.ValueChanged += new System.EventHandler(this.nudCols_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height                            Width";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnLaplacian);
            this.tabPage2.Controls.Add(this.txbSTD);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnMarr);
            this.tabPage2.Controls.Add(this.btnSobel);
            this.tabPage2.Controls.Add(this.nudMarrHeight);
            this.tabPage2.Controls.Add(this.nudMarrWidth);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 573);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "(2) Edge Detection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbPositive);
            this.groupBox2.Controls.Add(this.rdbABsolute);
            this.groupBox2.Controls.Add(this.rdbMiddleMap);
            this.groupBox2.Location = new System.Drawing.Point(18, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display";
            // 
            // rdbPositive
            // 
            this.rdbPositive.AutoSize = true;
            this.rdbPositive.Location = new System.Drawing.Point(18, 74);
            this.rdbPositive.Name = "rdbPositive";
            this.rdbPositive.Size = new System.Drawing.Size(104, 20);
            this.rdbPositive.TabIndex = 2;
            this.rdbPositive.Text = "Positive Value";
            this.rdbPositive.UseVisualStyleBackColor = true;
            // 
            // rdbABsolute
            // 
            this.rdbABsolute.AutoSize = true;
            this.rdbABsolute.Location = new System.Drawing.Point(18, 48);
            this.rdbABsolute.Name = "rdbABsolute";
            this.rdbABsolute.Size = new System.Drawing.Size(111, 20);
            this.rdbABsolute.TabIndex = 1;
            this.rdbABsolute.Text = "Absolute Value";
            this.rdbABsolute.UseVisualStyleBackColor = true;
            // 
            // rdbMiddleMap
            // 
            this.rdbMiddleMap.AutoSize = true;
            this.rdbMiddleMap.Checked = true;
            this.rdbMiddleMap.Location = new System.Drawing.Point(18, 22);
            this.rdbMiddleMap.Name = "rdbMiddleMap";
            this.rdbMiddleMap.Size = new System.Drawing.Size(122, 20);
            this.rdbMiddleMap.TabIndex = 0;
            this.rdbMiddleMap.TabStop = true;
            this.rdbMiddleMap.Text = "Lacpacian Image";
            this.rdbMiddleMap.UseVisualStyleBackColor = true;
            // 
            // btnLaplacian
            // 
            this.btnLaplacian.Location = new System.Drawing.Point(18, 408);
            this.btnLaplacian.Name = "btnLaplacian";
            this.btnLaplacian.Size = new System.Drawing.Size(223, 31);
            this.btnLaplacian.TabIndex = 14;
            this.btnLaplacian.Text = "Laplacian Filtering";
            this.btnLaplacian.UseVisualStyleBackColor = true;
            this.btnLaplacian.Click += new System.EventHandler(this.btnLaplacian_Click);
            // 
            // txbSTD
            // 
            this.txbSTD.Location = new System.Drawing.Point(148, 39);
            this.txbSTD.Name = "txbSTD";
            this.txbSTD.Size = new System.Drawing.Size(94, 23);
            this.txbSTD.TabIndex = 13;
            this.txbSTD.Text = "25";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Standard Deviation";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnMarr
            // 
            this.btnMarr.Location = new System.Drawing.Point(28, 117);
            this.btnMarr.Name = "btnMarr";
            this.btnMarr.Size = new System.Drawing.Size(223, 31);
            this.btnMarr.TabIndex = 11;
            this.btnMarr.Text = "LoG";
            this.btnMarr.UseVisualStyleBackColor = true;
            this.btnMarr.Click += new System.EventHandler(this.btnMarr_Click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(18, 482);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(223, 31);
            this.btnSobel.TabIndex = 9;
            this.btnSobel.Text = "Sobel vertical + horizontal";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);
            // 
            // nudMarrHeight
            // 
            this.nudMarrHeight.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudMarrHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMarrHeight.Location = new System.Drawing.Point(83, 78);
            this.nudMarrHeight.Maximum = new decimal(new int[] {
            299,
            0,
            0,
            0});
            this.nudMarrHeight.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMarrHeight.Name = "nudMarrHeight";
            this.nudMarrHeight.Size = new System.Drawing.Size(47, 23);
            this.nudMarrHeight.TabIndex = 6;
            this.nudMarrHeight.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // nudMarrWidth
            // 
            this.nudMarrWidth.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudMarrWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMarrWidth.Location = new System.Drawing.Point(195, 78);
            this.nudMarrWidth.Maximum = new decimal(new int[] {
            299,
            0,
            0,
            0});
            this.nudMarrWidth.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMarrWidth.Name = "nudMarrWidth";
            this.nudMarrWidth.Size = new System.Drawing.Size(47, 23);
            this.nudMarrWidth.TabIndex = 7;
            this.nudMarrWidth.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Height                            Width";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(275, 576);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "(3) Order-Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainFromHWK3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 649);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFromHWK3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HWK3 ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbResults)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarrHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarrWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pcbOriginal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMask;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pcbResults;
        private System.Windows.Forms.ToolStripStatusLabel labMessage;
        private System.Windows.Forms.CheckBox ckbTurbo;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label labOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCols;
        private System.Windows.Forms.ComboBox cbxFilters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbWeightedGray;
        private System.Windows.Forms.RadioButton rdbAverageGray;
        private System.Windows.Forms.RadioButton rdbColor;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMarr;
        private System.Windows.Forms.NumericUpDown nudMarrHeight;
        private System.Windows.Forms.NumericUpDown nudMarrWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSTD;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbPositive;
        private System.Windows.Forms.RadioButton rdbABsolute;
        private System.Windows.Forms.RadioButton rdbMiddleMap;
        private System.Windows.Forms.Button btnLaplacian;
    }
}

