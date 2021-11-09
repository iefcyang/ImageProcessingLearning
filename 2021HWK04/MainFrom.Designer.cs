
namespace _2021HWK04
{
    partial class MainFrom
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagProblem1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pcbForwardInversed = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFour = new System.Windows.Forms.Panel();
            this.pnlThree = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pcbPhaseAngle = new System.Windows.Forms.PictureBox();
            this.pnlOne = new System.Windows.Forms.Panel();
            this.pcbOriginal = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTwo = new System.Windows.Forms.Panel();
            this.pcbSpectrum = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetImageForFFT = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pagProblem1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbForwardInversed)).BeginInit();
            this.pnlFour.SuspendLayout();
            this.pnlThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPhaseAngle)).BeginInit();
            this.pnlOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbOriginal)).BeginInit();
            this.pnlTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSpectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1108, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 648);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1108, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagProblem1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(455, 624);
            this.tabMain.TabIndex = 2;
            // 
            // pagProblem1
            // 
            this.pagProblem1.Controls.Add(this.rtbOutput);
            this.pagProblem1.Controls.Add(this.btnGetImageForFFT);
            this.pagProblem1.Location = new System.Drawing.Point(4, 25);
            this.pagProblem1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagProblem1.Name = "pagProblem1";
            this.pagProblem1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagProblem1.Size = new System.Drawing.Size(447, 595);
            this.pagProblem1.TabIndex = 0;
            this.pagProblem1.Text = "(1) Fourier Transform";
            this.pagProblem1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(727, 598);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(727, 598);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(727, 598);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 624);
            this.splitContainer1.SplitterDistance = 649;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlThree, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlTwo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlOne, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlFour, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 624);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pcbForwardInversed
            // 
            this.pcbForwardInversed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pcbForwardInversed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbForwardInversed.Location = new System.Drawing.Point(0, 29);
            this.pcbForwardInversed.Name = "pcbForwardInversed";
            this.pcbForwardInversed.Size = new System.Drawing.Size(319, 277);
            this.pcbForwardInversed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbForwardInversed.TabIndex = 0;
            this.pcbForwardInversed.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Forward then Inversed Fourier Transformed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFour
            // 
            this.pnlFour.Controls.Add(this.pcbForwardInversed);
            this.pnlFour.Controls.Add(this.label1);
            this.pnlFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFour.Location = new System.Drawing.Point(327, 315);
            this.pnlFour.Name = "pnlFour";
            this.pnlFour.Size = new System.Drawing.Size(319, 306);
            this.pnlFour.TabIndex = 2;
            // 
            // pnlThree
            // 
            this.pnlThree.Controls.Add(this.pcbPhaseAngle);
            this.pnlThree.Controls.Add(this.label2);
            this.pnlThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThree.Location = new System.Drawing.Point(3, 315);
            this.pnlThree.Name = "pnlThree";
            this.pnlThree.Size = new System.Drawing.Size(318, 306);
            this.pnlThree.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fourier Transformed Phase Angle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcbPhaseAngle
            // 
            this.pcbPhaseAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pcbPhaseAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbPhaseAngle.Location = new System.Drawing.Point(0, 29);
            this.pcbPhaseAngle.Name = "pcbPhaseAngle";
            this.pcbPhaseAngle.Size = new System.Drawing.Size(318, 277);
            this.pcbPhaseAngle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPhaseAngle.TabIndex = 3;
            this.pcbPhaseAngle.TabStop = false;
            // 
            // pnlOne
            // 
            this.pnlOne.Controls.Add(this.pcbOriginal);
            this.pnlOne.Controls.Add(this.label3);
            this.pnlOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOne.Location = new System.Drawing.Point(3, 3);
            this.pnlOne.Name = "pnlOne";
            this.pnlOne.Size = new System.Drawing.Size(318, 306);
            this.pnlOne.TabIndex = 1;
            // 
            // pcbOriginal
            // 
            this.pcbOriginal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pcbOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbOriginal.Location = new System.Drawing.Point(0, 29);
            this.pcbOriginal.Name = "pcbOriginal";
            this.pcbOriginal.Size = new System.Drawing.Size(318, 277);
            this.pcbOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbOriginal.TabIndex = 3;
            this.pcbOriginal.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Maroon;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Original Image";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTwo
            // 
            this.pnlTwo.Controls.Add(this.pcbSpectrum);
            this.pnlTwo.Controls.Add(this.label4);
            this.pnlTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTwo.Location = new System.Drawing.Point(327, 3);
            this.pnlTwo.Name = "pnlTwo";
            this.pnlTwo.Size = new System.Drawing.Size(319, 306);
            this.pnlTwo.TabIndex = 1;
            // 
            // pcbSpectrum
            // 
            this.pcbSpectrum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pcbSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbSpectrum.Location = new System.Drawing.Point(0, 29);
            this.pcbSpectrum.Name = "pcbSpectrum";
            this.pcbSpectrum.Size = new System.Drawing.Size(319, 277);
            this.pcbSpectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbSpectrum.TabIndex = 3;
            this.pcbSpectrum.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fourier Transformed Spectrum (Mapped)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetImageForFFT
            // 
            this.btnGetImageForFFT.Location = new System.Drawing.Point(6, 7);
            this.btnGetImageForFFT.Name = "btnGetImageForFFT";
            this.btnGetImageForFFT.Size = new System.Drawing.Size(277, 38);
            this.btnGetImageForFFT.TabIndex = 0;
            this.btnGetImageForFFT.Text = "Get Image and Do Fourier Transform";
            this.btnGetImageForFFT.UseVisualStyleBackColor = true;
            this.btnGetImageForFFT.Click += new System.EventHandler(this.btnGetImageForFFT_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.Location = new System.Drawing.Point(6, 51);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(430, 211);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // labMessage
            // 
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(1091, 17);
            this.labMessage.Spring = true;
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            this.dlgOpen.Filter = "Image File|jpg|Image File|png";
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 670);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing HWK04";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pagProblem1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbForwardInversed)).EndInit();
            this.pnlFour.ResumeLayout(false);
            this.pnlThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPhaseAngle)).EndInit();
            this.pnlOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbOriginal)).EndInit();
            this.pnlTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbSpectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pagProblem1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlThree;
        private System.Windows.Forms.PictureBox pcbPhaseAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTwo;
        private System.Windows.Forms.PictureBox pcbSpectrum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlOne;
        private System.Windows.Forms.PictureBox pcbOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFour;
        private System.Windows.Forms.PictureBox pcbForwardInversed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnGetImageForFFT;
        private System.Windows.Forms.ToolStripStatusLabel labMessage;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

