
namespace _2021HWK05
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.pagColorImage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnEndColor = new System.Windows.Forms.Button();
            this.btnStartColor = new System.Windows.Forms.Button();
            this.pcbPallete = new System.Windows.Forms.PictureBox();
            this.pagGroupColor = new System.Windows.Forms.TabPage();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnGetCMYPlaneImages = new System.Windows.Forms.Button();
            this.btnGetXYZ = new System.Windows.Forms.Button();
            this.btnGetHSIImage = new System.Windows.Forms.Button();
            this.btnGetYUVImages = new System.Windows.Forms.Button();
            this.btnGetLABImages = new System.Windows.Forms.Button();
            this.colorGamut1 = new FCYangImageLibray.ColorGamut();
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
            this.pagColorImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPallete)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menOpen});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1203, 25);
            this.menuStrip1.TabIndex = 0;
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
            this.openToolStripMenuItem.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 741);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1203, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labMessage
            // 
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(1186, 17);
            this.labMessage.Spring = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(1203, 691);
            this.splitContainer1.SplitterDistance = 884;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 691);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlFour
            // 
            this.pnlFour.Controls.Add(this.pcbFour);
            this.pnlFour.Controls.Add(this.labFour);
            this.pnlFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFour.Location = new System.Drawing.Point(445, 348);
            this.pnlFour.Name = "pnlFour";
            this.pnlFour.Size = new System.Drawing.Size(436, 340);
            this.pnlFour.TabIndex = 4;
            // 
            // pcbFour
            // 
            this.pcbFour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbFour.Location = new System.Drawing.Point(0, 28);
            this.pcbFour.Name = "pcbFour";
            this.pcbFour.Size = new System.Drawing.Size(436, 312);
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
            this.labFour.Size = new System.Drawing.Size(436, 28);
            this.labFour.TabIndex = 0;
            this.labFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlThree
            // 
            this.pnlThree.Controls.Add(this.pcbThree);
            this.pnlThree.Controls.Add(this.labThree);
            this.pnlThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThree.Location = new System.Drawing.Point(3, 348);
            this.pnlThree.Name = "pnlThree";
            this.pnlThree.Size = new System.Drawing.Size(436, 340);
            this.pnlThree.TabIndex = 3;
            // 
            // pcbThree
            // 
            this.pcbThree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pcbThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbThree.Location = new System.Drawing.Point(0, 28);
            this.pcbThree.Name = "pcbThree";
            this.pcbThree.Size = new System.Drawing.Size(436, 312);
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
            this.labThree.Size = new System.Drawing.Size(436, 28);
            this.labThree.TabIndex = 0;
            this.labThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOne
            // 
            this.pnlOne.Controls.Add(this.pcbOne);
            this.pnlOne.Controls.Add(this.labOne);
            this.pnlOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOne.Location = new System.Drawing.Point(3, 3);
            this.pnlOne.Name = "pnlOne";
            this.pnlOne.Size = new System.Drawing.Size(436, 339);
            this.pnlOne.TabIndex = 2;
            // 
            // pcbOne
            // 
            this.pcbOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pcbOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbOne.Location = new System.Drawing.Point(0, 28);
            this.pcbOne.Name = "pcbOne";
            this.pcbOne.Size = new System.Drawing.Size(436, 311);
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
            this.labOne.Size = new System.Drawing.Size(436, 28);
            this.labOne.TabIndex = 0;
            this.labOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTwo
            // 
            this.pnlTwo.Controls.Add(this.pcbTwo);
            this.pnlTwo.Controls.Add(this.labTwo);
            this.pnlTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTwo.Location = new System.Drawing.Point(445, 3);
            this.pnlTwo.Name = "pnlTwo";
            this.pnlTwo.Size = new System.Drawing.Size(436, 339);
            this.pnlTwo.TabIndex = 1;
            // 
            // pcbTwo
            // 
            this.pcbTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbTwo.Location = new System.Drawing.Point(0, 28);
            this.pcbTwo.Name = "pcbTwo";
            this.pcbTwo.Size = new System.Drawing.Size(436, 311);
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
            this.labTwo.Size = new System.Drawing.Size(436, 28);
            this.labTwo.TabIndex = 0;
            this.labTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagFormatTransform);
            this.tabMain.Controls.Add(this.pagColorImage);
            this.tabMain.Controls.Add(this.pagGroupColor);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(314, 691);
            this.tabMain.TabIndex = 0;
            // 
            // pagFormatTransform
            // 
            this.pagFormatTransform.Controls.Add(this.btnGetYUVImages);
            this.pagFormatTransform.Controls.Add(this.btnGetLABImages);
            this.pagFormatTransform.Controls.Add(this.btnGetXYZ);
            this.pagFormatTransform.Controls.Add(this.btnGetHSIImage);
            this.pagFormatTransform.Controls.Add(this.btnGetCMYPlaneImages);
            this.pagFormatTransform.Controls.Add(this.btnGetRGBPlanes);
            this.pagFormatTransform.Location = new System.Drawing.Point(4, 25);
            this.pagFormatTransform.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagFormatTransform.Name = "pagFormatTransform";
            this.pagFormatTransform.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagFormatTransform.Size = new System.Drawing.Size(306, 662);
            this.pagFormatTransform.TabIndex = 1;
            this.pagFormatTransform.Text = "(1) Color Model Transform";
            this.pagFormatTransform.UseVisualStyleBackColor = true;
            // 
            // btnGetRGBPlanes
            // 
            this.btnGetRGBPlanes.Location = new System.Drawing.Point(6, 7);
            this.btnGetRGBPlanes.Name = "btnGetRGBPlanes";
            this.btnGetRGBPlanes.Size = new System.Drawing.Size(249, 33);
            this.btnGetRGBPlanes.TabIndex = 0;
            this.btnGetRGBPlanes.Text = "Get RGB Plane Images";
            this.btnGetRGBPlanes.UseVisualStyleBackColor = true;
            this.btnGetRGBPlanes.Click += new System.EventHandler(this.btnGetRGBPlanes_Click);
            // 
            // pagColorImage
            // 
            this.pagColorImage.Controls.Add(this.splitContainer2);
            this.pagColorImage.Location = new System.Drawing.Point(4, 25);
            this.pagColorImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagColorImage.Name = "pagColorImage";
            this.pagColorImage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagColorImage.Size = new System.Drawing.Size(428, 662);
            this.pagColorImage.TabIndex = 0;
            this.pagColorImage.Text = "(2) Color Image";
            this.pagColorImage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnEndColor);
            this.splitContainer2.Panel1.Controls.Add(this.btnStartColor);
            this.splitContainer2.Panel1.Controls.Add(this.pcbPallete);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.colorGamut1);
            this.splitContainer2.Panel2.Click += new System.EventHandler(this.EditColorWatch);
            this.splitContainer2.Size = new System.Drawing.Size(422, 657);
            this.splitContainer2.SplitterDistance = 86;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnEndColor
            // 
            this.btnEndColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndColor.BackColor = System.Drawing.Color.Blue;
            this.btnEndColor.Location = new System.Drawing.Point(399, 61);
            this.btnEndColor.Name = "btnEndColor";
            this.btnEndColor.Size = new System.Drawing.Size(22, 23);
            this.btnEndColor.TabIndex = 2;
            this.btnEndColor.UseVisualStyleBackColor = false;
            this.btnEndColor.Click += new System.EventHandler(this.EditColorWatch);
            // 
            // btnStartColor
            // 
            this.btnStartColor.BackColor = System.Drawing.Color.Red;
            this.btnStartColor.Location = new System.Drawing.Point(0, 0);
            this.btnStartColor.Name = "btnStartColor";
            this.btnStartColor.Size = new System.Drawing.Size(22, 23);
            this.btnStartColor.TabIndex = 3;
            this.btnStartColor.UseVisualStyleBackColor = false;
            this.btnStartColor.Click += new System.EventHandler(this.EditColorWatch);
            // 
            // pcbPallete
            // 
            this.pcbPallete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbPallete.BackColor = System.Drawing.Color.Black;
            this.pcbPallete.Location = new System.Drawing.Point(12, 14);
            this.pcbPallete.Name = "pcbPallete";
            this.pcbPallete.Size = new System.Drawing.Size(396, 57);
            this.pcbPallete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPallete.TabIndex = 0;
            this.pcbPallete.TabStop = false;
            // 
            // pagGroupColor
            // 
            this.pagGroupColor.Location = new System.Drawing.Point(4, 25);
            this.pagGroupColor.Name = "pagGroupColor";
            this.pagGroupColor.Size = new System.Drawing.Size(428, 662);
            this.pagGroupColor.TabIndex = 2;
            this.pagGroupColor.Text = "(3) Color Clustering";
            this.pagGroupColor.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1203, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(71, 22);
            this.btnOpen.Text = "Open ...";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnGetCMYPlaneImages
            // 
            this.btnGetCMYPlaneImages.Location = new System.Drawing.Point(6, 46);
            this.btnGetCMYPlaneImages.Name = "btnGetCMYPlaneImages";
            this.btnGetCMYPlaneImages.Size = new System.Drawing.Size(249, 33);
            this.btnGetCMYPlaneImages.TabIndex = 1;
            this.btnGetCMYPlaneImages.Text = "Get CMY Plane Images";
            this.btnGetCMYPlaneImages.UseVisualStyleBackColor = true;
            this.btnGetCMYPlaneImages.Click += new System.EventHandler(this.btnGetCMYPlaneImages_Click);
            // 
            // btnGetXYZ
            // 
            this.btnGetXYZ.Location = new System.Drawing.Point(6, 124);
            this.btnGetXYZ.Name = "btnGetXYZ";
            this.btnGetXYZ.Size = new System.Drawing.Size(249, 33);
            this.btnGetXYZ.TabIndex = 3;
            this.btnGetXYZ.Text = "Get XYZ Plane Images";
            this.btnGetXYZ.UseVisualStyleBackColor = true;
            this.btnGetXYZ.Click += new System.EventHandler(this.btnGetXYZ_Click);
            // 
            // btnGetHSIImage
            // 
            this.btnGetHSIImage.Location = new System.Drawing.Point(6, 85);
            this.btnGetHSIImage.Name = "btnGetHSIImage";
            this.btnGetHSIImage.Size = new System.Drawing.Size(249, 33);
            this.btnGetHSIImage.TabIndex = 2;
            this.btnGetHSIImage.Text = "Get HSI  Plane Images";
            this.btnGetHSIImage.UseVisualStyleBackColor = true;
            this.btnGetHSIImage.Click += new System.EventHandler(this.btnGetHSIImage_Click);
            // 
            // btnGetYUVImages
            // 
            this.btnGetYUVImages.Location = new System.Drawing.Point(6, 202);
            this.btnGetYUVImages.Name = "btnGetYUVImages";
            this.btnGetYUVImages.Size = new System.Drawing.Size(249, 33);
            this.btnGetYUVImages.TabIndex = 5;
            this.btnGetYUVImages.Text = "Get YUV  Plane Images";
            this.btnGetYUVImages.UseVisualStyleBackColor = true;
            this.btnGetYUVImages.Click += new System.EventHandler(this.btnGetYUVImages_Click);
            // 
            // btnGetLABImages
            // 
            this.btnGetLABImages.Location = new System.Drawing.Point(6, 163);
            this.btnGetLABImages.Name = "btnGetLABImages";
            this.btnGetLABImages.Size = new System.Drawing.Size(249, 33);
            this.btnGetLABImages.TabIndex = 4;
            this.btnGetLABImages.Text = "Get L*a*b* Plane Images";
            this.btnGetLABImages.UseVisualStyleBackColor = true;
            this.btnGetLABImages.Click += new System.EventHandler(this.btnGetLABImages_Click);
            // 
            // colorGamut1
            // 
            this.colorGamut1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.colorGamut1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGamut1.Location = new System.Drawing.Point(0, 0);
            this.colorGamut1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorGamut1.Name = "colorGamut1";
            this.colorGamut1.Size = new System.Drawing.Size(422, 567);
            this.colorGamut1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 763);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HWK 05";
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
            this.pagColorImage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPallete)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TabPage pagColorImage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnStartColor;
        private System.Windows.Forms.Button btnEndColor;
        private System.Windows.Forms.TabPage pagFormatTransform;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.PictureBox pcbPallete;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private FCYangImageLibray.ColorGamut colorGamut1;
        private System.Windows.Forms.TabPage pagGroupColor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.Button btnGetRGBPlanes;
        private System.Windows.Forms.Button btnGetCMYPlaneImages;
        private System.Windows.Forms.Button btnGetYUVImages;
        private System.Windows.Forms.Button btnGetLABImages;
        private System.Windows.Forms.Button btnGetXYZ;
        private System.Windows.Forms.Button btnGetHSIImage;
    }
}

