
namespace _2021HWK06
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnApplyQuadMap = new System.Windows.Forms.Button();
            this.btnApplyGamutColorMap = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudLevels = new System.Windows.Forms.NumericUpDown();
            this.btnTwoOnDifferentData = new System.Windows.Forms.Button();
            this.btnGetThreeSegmentations = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudK3 = new System.Windows.Forms.NumericUpDown();
            this.nudK2 = new System.Windows.Forms.NumericUpDown();
            this.nudK1 = new System.Windows.Forms.NumericUpDown();
            this.pagGroupColor = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFour = new System.Windows.Forms.Panel();
            this.pcbFour = new System.Windows.Forms.PictureBox();
            this.labFour = new System.Windows.Forms.Label();
            this.pnlThree = new System.Windows.Forms.Panel();
            this.pcbThree = new System.Windows.Forms.PictureBox();
            this.labThree = new System.Windows.Forms.Label();
            this.pnlOne = new System.Windows.Forms.Panel();
            this.pcbOne = new System.Windows.Forms.PictureBox();
            this.labOne = new System.Windows.Forms.Label();
            this.pnlTwo = new System.Windows.Forms.Panel();
            this.pcbTwo = new System.Windows.Forms.PictureBox();
            this.labTwo = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagFormatTransform = new System.Windows.Forms.TabPage();
            this.btnGetRGBPlanes = new System.Windows.Forms.Button();
            this.pagWavelet = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudVerticalScale = new System.Windows.Forms.NumericUpDown();
            this.nudHorizontalScale = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK1)).BeginInit();
            this.pagGroupColor.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlFour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFour)).BeginInit();
            this.pnlThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbThree)).BeginInit();
            this.pnlOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbOne)).BeginInit();
            this.pnlTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTwo)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pagFormatTransform.SuspendLayout();
            this.pagWavelet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontalScale)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1169, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(87, 36);
            this.btnOpen.Text = "Open ...";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnApplyQuadMap
            // 
            this.btnApplyQuadMap.Location = new System.Drawing.Point(6, 39);
            this.btnApplyQuadMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApplyQuadMap.Name = "btnApplyQuadMap";
            this.btnApplyQuadMap.Size = new System.Drawing.Size(254, 33);
            this.btnApplyQuadMap.TabIndex = 4;
            this.btnApplyQuadMap.Text = "Apply Pseudo Color";
            this.btnApplyQuadMap.UseVisualStyleBackColor = true;
            // 
            // btnApplyGamutColorMap
            // 
            this.btnApplyGamutColorMap.Location = new System.Drawing.Point(6, 80);
            this.btnApplyGamutColorMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApplyGamutColorMap.Name = "btnApplyGamutColorMap";
            this.btnApplyGamutColorMap.Size = new System.Drawing.Size(254, 30);
            this.btnApplyGamutColorMap.TabIndex = 7;
            this.btnApplyGamutColorMap.Text = "Apply Pseudo Color";
            this.btnApplyGamutColorMap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 629);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Segments";
            // 
            // nudLevels
            // 
            this.nudLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudLevels.Location = new System.Drawing.Point(107, 626);
            this.nudLevels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudLevels.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLevels.Name = "nudLevels";
            this.nudLevels.Size = new System.Drawing.Size(85, 23);
            this.nudLevels.TabIndex = 8;
            this.nudLevels.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnTwoOnDifferentData
            // 
            this.btnTwoOnDifferentData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwoOnDifferentData.Location = new System.Drawing.Point(14, 665);
            this.btnTwoOnDifferentData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTwoOnDifferentData.Name = "btnTwoOnDifferentData";
            this.btnTwoOnDifferentData.Size = new System.Drawing.Size(282, 56);
            this.btnTwoOnDifferentData.TabIndex = 7;
            this.btnTwoOnDifferentData.Text = "Compare 2-segmentaion Models";
            this.btnTwoOnDifferentData.UseVisualStyleBackColor = true;
            // 
            // btnGetThreeSegmentations
            // 
            this.btnGetThreeSegmentations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetThreeSegmentations.Location = new System.Drawing.Point(7, 148);
            this.btnGetThreeSegmentations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetThreeSegmentations.Name = "btnGetThreeSegmentations";
            this.btnGetThreeSegmentations.Size = new System.Drawing.Size(282, 52);
            this.btnGetThreeSegmentations.TabIndex = 6;
            this.btnGetThreeSegmentations.Text = "Get Three Segmentations";
            this.btnGetThreeSegmentations.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segmentation Size 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Segmentation Size 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Segmentation Size 1";
            // 
            // nudK3
            // 
            this.nudK3.Location = new System.Drawing.Point(189, 108);
            this.nudK3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudK3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudK3.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudK3.Name = "nudK3";
            this.nudK3.Size = new System.Drawing.Size(85, 23);
            this.nudK3.TabIndex = 2;
            this.nudK3.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nudK2
            // 
            this.nudK2.Location = new System.Drawing.Point(189, 69);
            this.nudK2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudK2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudK2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudK2.Name = "nudK2";
            this.nudK2.Size = new System.Drawing.Size(85, 23);
            this.nudK2.TabIndex = 1;
            this.nudK2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudK1
            // 
            this.nudK1.Location = new System.Drawing.Point(189, 32);
            this.nudK1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudK1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudK1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudK1.Name = "nudK1";
            this.nudK1.Size = new System.Drawing.Size(85, 23);
            this.nudK1.TabIndex = 0;
            this.nudK1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // pagGroupColor
            // 
            this.pagGroupColor.Controls.Add(this.label4);
            this.pagGroupColor.Controls.Add(this.nudLevels);
            this.pagGroupColor.Controls.Add(this.btnTwoOnDifferentData);
            this.pagGroupColor.Controls.Add(this.btnGetThreeSegmentations);
            this.pagGroupColor.Controls.Add(this.label3);
            this.pagGroupColor.Controls.Add(this.label2);
            this.pagGroupColor.Controls.Add(this.label1);
            this.pagGroupColor.Controls.Add(this.nudK3);
            this.pagGroupColor.Controls.Add(this.nudK2);
            this.pagGroupColor.Controls.Add(this.nudK1);
            this.pagGroupColor.Location = new System.Drawing.Point(4, 25);
            this.pagGroupColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagGroupColor.Name = "pagGroupColor";
            this.pagGroupColor.Size = new System.Drawing.Size(297, 591);
            this.pagGroupColor.TabIndex = 2;
            this.pagGroupColor.Text = "(3) Heough Transform";
            this.pagGroupColor.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menOpen});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1169, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menOpen
            // 
            this.menOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menOpen.Name = "menOpen";
            this.menOpen.Size = new System.Drawing.Size(38, 19);
            this.menOpen.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.openToolStripMenuItem.Text = "Open ...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 686);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1169, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labMessage
            // 
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(1149, 17);
            this.labMessage.Spring = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(1169, 620);
            this.splitContainer1.SplitterDistance = 858;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlFour, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlThree, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlOne, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTwo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 620);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlFour
            // 
            this.pnlFour.Controls.Add(this.pcbFour);
            this.pnlFour.Controls.Add(this.labFour);
            this.pnlFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFour.Location = new System.Drawing.Point(432, 314);
            this.pnlFour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFour.Name = "pnlFour";
            this.pnlFour.Size = new System.Drawing.Size(423, 302);
            this.pnlFour.TabIndex = 4;
            // 
            // pcbFour
            // 
            this.pcbFour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbFour.Location = new System.Drawing.Point(0, 37);
            this.pcbFour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbFour.Name = "pcbFour";
            this.pcbFour.Size = new System.Drawing.Size(423, 265);
            this.pcbFour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbFour.TabIndex = 1;
            this.pcbFour.TabStop = false;
            // 
            // labFour
            // 
            this.labFour.BackColor = System.Drawing.Color.Olive;
            this.labFour.Dock = System.Windows.Forms.DockStyle.Top;
            this.labFour.ForeColor = System.Drawing.Color.White;
            this.labFour.Location = new System.Drawing.Point(0, 0);
            this.labFour.Name = "labFour";
            this.labFour.Size = new System.Drawing.Size(423, 37);
            this.labFour.TabIndex = 0;
            this.labFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlThree
            // 
            this.pnlThree.Controls.Add(this.pcbThree);
            this.pnlThree.Controls.Add(this.labThree);
            this.pnlThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThree.Location = new System.Drawing.Point(3, 314);
            this.pnlThree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlThree.Name = "pnlThree";
            this.pnlThree.Size = new System.Drawing.Size(423, 302);
            this.pnlThree.TabIndex = 3;
            // 
            // pcbThree
            // 
            this.pcbThree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pcbThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbThree.Location = new System.Drawing.Point(0, 37);
            this.pcbThree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbThree.Name = "pcbThree";
            this.pcbThree.Size = new System.Drawing.Size(423, 265);
            this.pcbThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbThree.TabIndex = 1;
            this.pcbThree.TabStop = false;
            // 
            // labThree
            // 
            this.labThree.BackColor = System.Drawing.Color.Navy;
            this.labThree.Dock = System.Windows.Forms.DockStyle.Top;
            this.labThree.ForeColor = System.Drawing.Color.White;
            this.labThree.Location = new System.Drawing.Point(0, 0);
            this.labThree.Name = "labThree";
            this.labThree.Size = new System.Drawing.Size(423, 37);
            this.labThree.TabIndex = 0;
            this.labThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOne
            // 
            this.pnlOne.Controls.Add(this.pcbOne);
            this.pnlOne.Controls.Add(this.labOne);
            this.pnlOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOne.Location = new System.Drawing.Point(3, 4);
            this.pnlOne.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOne.Name = "pnlOne";
            this.pnlOne.Size = new System.Drawing.Size(423, 302);
            this.pnlOne.TabIndex = 2;
            // 
            // pcbOne
            // 
            this.pcbOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pcbOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbOne.Location = new System.Drawing.Point(0, 37);
            this.pcbOne.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbOne.Name = "pcbOne";
            this.pcbOne.Size = new System.Drawing.Size(423, 265);
            this.pcbOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbOne.TabIndex = 1;
            this.pcbOne.TabStop = false;
            // 
            // labOne
            // 
            this.labOne.BackColor = System.Drawing.Color.Maroon;
            this.labOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.labOne.ForeColor = System.Drawing.Color.White;
            this.labOne.Location = new System.Drawing.Point(0, 0);
            this.labOne.Name = "labOne";
            this.labOne.Size = new System.Drawing.Size(423, 37);
            this.labOne.TabIndex = 0;
            this.labOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTwo
            // 
            this.pnlTwo.Controls.Add(this.pcbTwo);
            this.pnlTwo.Controls.Add(this.labTwo);
            this.pnlTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTwo.Location = new System.Drawing.Point(432, 4);
            this.pnlTwo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTwo.Name = "pnlTwo";
            this.pnlTwo.Size = new System.Drawing.Size(423, 302);
            this.pnlTwo.TabIndex = 1;
            // 
            // pcbTwo
            // 
            this.pcbTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbTwo.Location = new System.Drawing.Point(0, 37);
            this.pcbTwo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbTwo.Name = "pcbTwo";
            this.pcbTwo.Size = new System.Drawing.Size(423, 265);
            this.pcbTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbTwo.TabIndex = 1;
            this.pcbTwo.TabStop = false;
            // 
            // labTwo
            // 
            this.labTwo.BackColor = System.Drawing.Color.Green;
            this.labTwo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTwo.ForeColor = System.Drawing.Color.White;
            this.labTwo.Location = new System.Drawing.Point(0, 0);
            this.labTwo.Name = "labTwo";
            this.labTwo.Size = new System.Drawing.Size(423, 37);
            this.labTwo.TabIndex = 0;
            this.labTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagFormatTransform);
            this.tabMain.Controls.Add(this.pagWavelet);
            this.tabMain.Controls.Add(this.pagGroupColor);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Enabled = false;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(305, 620);
            this.tabMain.TabIndex = 0;
            // 
            // pagFormatTransform
            // 
            this.pagFormatTransform.Controls.Add(this.nudHorizontalScale);
            this.pagFormatTransform.Controls.Add(this.nudVerticalScale);
            this.pagFormatTransform.Controls.Add(this.label6);
            this.pagFormatTransform.Controls.Add(this.label5);
            this.pagFormatTransform.Controls.Add(this.btnGetRGBPlanes);
            this.pagFormatTransform.Location = new System.Drawing.Point(4, 25);
            this.pagFormatTransform.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pagFormatTransform.Name = "pagFormatTransform";
            this.pagFormatTransform.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pagFormatTransform.Size = new System.Drawing.Size(297, 591);
            this.pagFormatTransform.TabIndex = 1;
            this.pagFormatTransform.Text = "(1) Geometric Transform";
            this.pagFormatTransform.UseVisualStyleBackColor = true;
            // 
            // btnGetRGBPlanes
            // 
            this.btnGetRGBPlanes.Location = new System.Drawing.Point(3, 86);
            this.btnGetRGBPlanes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetRGBPlanes.Name = "btnGetRGBPlanes";
            this.btnGetRGBPlanes.Size = new System.Drawing.Size(290, 44);
            this.btnGetRGBPlanes.TabIndex = 0;
            this.btnGetRGBPlanes.Text = "Get Transformed Images";
            this.btnGetRGBPlanes.UseVisualStyleBackColor = true;
            this.btnGetRGBPlanes.Click += new System.EventHandler(this.btnGetRGBPlanes_Click);
            // 
            // pagWavelet
            // 
            this.pagWavelet.Controls.Add(this.btnApplyGamutColorMap);
            this.pagWavelet.Controls.Add(this.btnApplyQuadMap);
            this.pagWavelet.Location = new System.Drawing.Point(4, 25);
            this.pagWavelet.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pagWavelet.Name = "pagWavelet";
            this.pagWavelet.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pagWavelet.Size = new System.Drawing.Size(297, 591);
            this.pagWavelet.TabIndex = 0;
            this.pagWavelet.Text = "(2) Wavelet Transform";
            this.pagWavelet.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Trapezoidal Vertical Scale";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Horizontal Scale ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // nudVerticalScale
            // 
            this.nudVerticalScale.DecimalPlaces = 2;
            this.nudVerticalScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudVerticalScale.Location = new System.Drawing.Point(174, 27);
            this.nudVerticalScale.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.nudVerticalScale.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nudVerticalScale.Name = "nudVerticalScale";
            this.nudVerticalScale.Size = new System.Drawing.Size(69, 23);
            this.nudVerticalScale.TabIndex = 3;
            this.nudVerticalScale.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // nudHorizontalScale
            // 
            this.nudHorizontalScale.DecimalPlaces = 2;
            this.nudHorizontalScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudHorizontalScale.Location = new System.Drawing.Point(174, 56);
            this.nudHorizontalScale.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.nudHorizontalScale.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nudHorizontalScale.Name = "nudHorizontalScale";
            this.nudHorizontalScale.Size = new System.Drawing.Size(69, 23);
            this.nudHorizontalScale.TabIndex = 4;
            this.nudHorizontalScale.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 708);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Homework 06 Wavelet";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK1)).EndInit();
            this.pagGroupColor.ResumeLayout(false);
            this.pagGroupColor.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlFour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbFour)).EndInit();
            this.pnlThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbThree)).EndInit();
            this.pnlOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbOne)).EndInit();
            this.pnlTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbTwo)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pagFormatTransform.ResumeLayout(false);
            this.pagFormatTransform.PerformLayout();
            this.pagWavelet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontalScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.Button btnApplyQuadMap;
        private System.Windows.Forms.Button btnApplyGamutColorMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudLevels;
        private System.Windows.Forms.Button btnTwoOnDifferentData;
        private System.Windows.Forms.Button btnGetThreeSegmentations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudK3;
        private System.Windows.Forms.NumericUpDown nudK2;
        private System.Windows.Forms.NumericUpDown nudK1;
        private System.Windows.Forms.TabPage pagGroupColor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menOpen;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labMessage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlFour;
        private System.Windows.Forms.PictureBox pcbFour;
        private System.Windows.Forms.Label labFour;
        private System.Windows.Forms.Panel pnlThree;
        private System.Windows.Forms.PictureBox pcbThree;
        private System.Windows.Forms.Label labThree;
        private System.Windows.Forms.Panel pnlOne;
        private System.Windows.Forms.PictureBox pcbOne;
        private System.Windows.Forms.Label labOne;
        private System.Windows.Forms.Panel pnlTwo;
        private System.Windows.Forms.PictureBox pcbTwo;
        private System.Windows.Forms.Label labTwo;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pagFormatTransform;
        private System.Windows.Forms.Button btnGetRGBPlanes;
        private System.Windows.Forms.TabPage pagWavelet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudHorizontalScale;
        private System.Windows.Forms.NumericUpDown nudVerticalScale;
    }
}

