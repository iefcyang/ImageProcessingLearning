
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnStartColor = new System.Windows.Forms.Button();
            this.btnEndColor = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.pcbPallete = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPallete)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1203, 25);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1203, 716);
            this.splitContainer1.SplitterDistance = 762;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 716);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlFour
            // 
            this.pnlFour.Controls.Add(this.pcbFour);
            this.pnlFour.Controls.Add(this.labFour);
            this.pnlFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFour.Location = new System.Drawing.Point(384, 361);
            this.pnlFour.Name = "pnlFour";
            this.pnlFour.Size = new System.Drawing.Size(375, 352);
            this.pnlFour.TabIndex = 4;
            // 
            // pcbFour
            // 
            this.pcbFour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbFour.Location = new System.Drawing.Point(0, 40);
            this.pcbFour.Name = "pcbFour";
            this.pcbFour.Size = new System.Drawing.Size(375, 312);
            this.pcbFour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbFour.TabIndex = 1;
            this.pcbFour.TabStop = false;
            // 
            // labFour
            // 
            this.labFour.BackColor = System.Drawing.Color.Olive;
            this.labFour.Dock = System.Windows.Forms.DockStyle.Top;
            this.labFour.Enabled = false;
            this.labFour.ForeColor = System.Drawing.Color.White;
            this.labFour.Location = new System.Drawing.Point(0, 0);
            this.labFour.Name = "labFour";
            this.labFour.Size = new System.Drawing.Size(375, 40);
            this.labFour.TabIndex = 0;
            this.labFour.Text = "Original Image";
            this.labFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlThree
            // 
            this.pnlThree.Controls.Add(this.pcbThree);
            this.pnlThree.Controls.Add(this.labThree);
            this.pnlThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThree.Location = new System.Drawing.Point(3, 361);
            this.pnlThree.Name = "pnlThree";
            this.pnlThree.Size = new System.Drawing.Size(375, 352);
            this.pnlThree.TabIndex = 3;
            // 
            // pcbThree
            // 
            this.pcbThree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pcbThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbThree.Location = new System.Drawing.Point(0, 40);
            this.pcbThree.Name = "pcbThree";
            this.pcbThree.Size = new System.Drawing.Size(375, 312);
            this.pcbThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbThree.TabIndex = 1;
            this.pcbThree.TabStop = false;
            // 
            // labThree
            // 
            this.labThree.BackColor = System.Drawing.Color.Navy;
            this.labThree.Dock = System.Windows.Forms.DockStyle.Top;
            this.labThree.Enabled = false;
            this.labThree.ForeColor = System.Drawing.Color.White;
            this.labThree.Location = new System.Drawing.Point(0, 0);
            this.labThree.Name = "labThree";
            this.labThree.Size = new System.Drawing.Size(375, 40);
            this.labThree.TabIndex = 0;
            this.labThree.Text = "Original Image";
            this.labThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOne
            // 
            this.pnlOne.Controls.Add(this.pcbOne);
            this.pnlOne.Controls.Add(this.labOne);
            this.pnlOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOne.Location = new System.Drawing.Point(3, 3);
            this.pnlOne.Name = "pnlOne";
            this.pnlOne.Size = new System.Drawing.Size(375, 352);
            this.pnlOne.TabIndex = 2;
            // 
            // pcbOne
            // 
            this.pcbOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pcbOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbOne.Location = new System.Drawing.Point(0, 40);
            this.pcbOne.Name = "pcbOne";
            this.pcbOne.Size = new System.Drawing.Size(375, 312);
            this.pcbOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbOne.TabIndex = 1;
            this.pcbOne.TabStop = false;
            // 
            // labOne
            // 
            this.labOne.BackColor = System.Drawing.Color.Maroon;
            this.labOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.labOne.Enabled = false;
            this.labOne.ForeColor = System.Drawing.Color.White;
            this.labOne.Location = new System.Drawing.Point(0, 0);
            this.labOne.Name = "labOne";
            this.labOne.Size = new System.Drawing.Size(375, 40);
            this.labOne.TabIndex = 0;
            this.labOne.Text = "Original Image";
            this.labOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTwo
            // 
            this.pnlTwo.Controls.Add(this.pcbTwo);
            this.pnlTwo.Controls.Add(this.labTwo);
            this.pnlTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTwo.Location = new System.Drawing.Point(384, 3);
            this.pnlTwo.Name = "pnlTwo";
            this.pnlTwo.Size = new System.Drawing.Size(375, 352);
            this.pnlTwo.TabIndex = 1;
            // 
            // pcbTwo
            // 
            this.pcbTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbTwo.Location = new System.Drawing.Point(0, 40);
            this.pcbTwo.Name = "pcbTwo";
            this.pcbTwo.Size = new System.Drawing.Size(375, 312);
            this.pcbTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbTwo.TabIndex = 1;
            this.pcbTwo.TabStop = false;
            // 
            // labTwo
            // 
            this.labTwo.BackColor = System.Drawing.Color.Green;
            this.labTwo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTwo.Enabled = false;
            this.labTwo.ForeColor = System.Drawing.Color.White;
            this.labTwo.Location = new System.Drawing.Point(0, 0);
            this.labTwo.Name = "labTwo";
            this.labTwo.Size = new System.Drawing.Size(375, 40);
            this.labTwo.TabIndex = 0;
            this.labTwo.Text = "Original Image";
            this.labTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 716);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(428, 687);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(422, 679);
            this.splitContainer2.SplitterDistance = 267;
            this.splitContainer2.TabIndex = 0;
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
            // btnEndColor
            // 
            this.btnEndColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndColor.BackColor = System.Drawing.Color.Blue;
            this.btnEndColor.Location = new System.Drawing.Point(399, 242);
            this.btnEndColor.Name = "btnEndColor";
            this.btnEndColor.Size = new System.Drawing.Size(22, 23);
            this.btnEndColor.TabIndex = 2;
            this.btnEndColor.UseVisualStyleBackColor = false;
            this.btnEndColor.Click += new System.EventHandler(this.EditColorWatch);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(428, 687);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pcbPallete
            // 
            this.pcbPallete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbPallete.BackColor = System.Drawing.Color.Black;
            this.pcbPallete.Location = new System.Drawing.Point(12, 14);
            this.pcbPallete.Name = "pcbPallete";
            this.pcbPallete.Size = new System.Drawing.Size(396, 238);
            this.pcbPallete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPallete.TabIndex = 0;
            this.pcbPallete.TabStop = false;
            // 
            // colorGamut1
            // 
            this.colorGamut1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGamut1.Location = new System.Drawing.Point(0, 0);
            this.colorGamut1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorGamut1.Name = "colorGamut1";
            this.colorGamut1.Size = new System.Drawing.Size(422, 408);
            this.colorGamut1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 763);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPallete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnStartColor;
        private System.Windows.Forms.Button btnEndColor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.PictureBox pcbPallete;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private FCYangImageLibray.ColorGamut colorGamut1;
    }
}

