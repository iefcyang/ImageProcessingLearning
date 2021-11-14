﻿namespace FourierTransformationTest
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chtMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSine = new System.Windows.Forms.Button();
            this.btnConstant = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn2DFFTTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPower = new System.Windows.Forms.NumericUpDown();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnFourierTest = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ckbNoImageary = new System.Windows.Forms.CheckBox();
            this.ckbShiftCenter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chtMain
            // 
            this.chtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chtMain.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtMain.Legends.Add(legend1);
            this.chtMain.Location = new System.Drawing.Point(156, 50);
            this.chtMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chtMain.Name = "chtMain";
            this.chtMain.Size = new System.Drawing.Size(745, 488);
            this.chtMain.TabIndex = 0;
            this.chtMain.Text = "chart1";
            // 
            // btnSine
            // 
            this.btnSine.Location = new System.Drawing.Point(907, 65);
            this.btnSine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSine.Name = "btnSine";
            this.btnSine.Size = new System.Drawing.Size(90, 32);
            this.btnSine.TabIndex = 1;
            this.btnSine.Text = "Sine";
            this.btnSine.UseVisualStyleBackColor = true;
            this.btnSine.Click += new System.EventHandler(this.btnSine_Click);
            // 
            // btnConstant
            // 
            this.btnConstant.Location = new System.Drawing.Point(910, 133);
            this.btnConstant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConstant.Name = "btnConstant";
            this.btnConstant.Size = new System.Drawing.Size(87, 58);
            this.btnConstant.TabIndex = 2;
            this.btnConstant.Text = "Ranged Constant FT";
            this.btnConstant.UseVisualStyleBackColor = true;
            this.btnConstant.Click += new System.EventHandler(this.btnConstant_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1141, 685);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ckbShiftCenter);
            this.tabPage1.Controls.Add(this.ckbNoImageary);
            this.tabPage1.Controls.Add(this.btn2DFFTTest);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nudPower);
            this.tabPage1.Controls.Add(this.rtbOutput);
            this.tabPage1.Controls.Add(this.btnFourierTest);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1133, 656);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn2DFFTTest
            // 
            this.btn2DFFTTest.Location = new System.Drawing.Point(368, 24);
            this.btn2DFFTTest.Name = "btn2DFFTTest";
            this.btn2DFFTTest.Size = new System.Drawing.Size(98, 54);
            this.btn2DFFTTest.TabIndex = 4;
            this.btn2DFFTTest.Text = "2D FFT Test";
            this.btn2DFFTTest.UseVisualStyleBackColor = true;
            this.btn2DFFTTest.Click += new System.EventHandler(this.btn2DFFTTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Power of 2";
            // 
            // nudPower
            // 
            this.nudPower.Location = new System.Drawing.Point(273, 24);
            this.nudPower.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPower.Name = "nudPower";
            this.nudPower.Size = new System.Drawing.Size(63, 23);
            this.nudPower.TabIndex = 2;
            this.nudPower.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPower.ValueChanged += new System.EventHandler(this.nudPower_ValueChanged);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.Location = new System.Drawing.Point(25, 93);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(1080, 541);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // btnFourierTest
            // 
            this.btnFourierTest.Location = new System.Drawing.Point(24, 24);
            this.btnFourierTest.Name = "btnFourierTest";
            this.btnFourierTest.Size = new System.Drawing.Size(98, 54);
            this.btnFourierTest.TabIndex = 0;
            this.btnFourierTest.Text = "Fourier Test";
            this.btnFourierTest.UseVisualStyleBackColor = true;
            this.btnFourierTest.Click += new System.EventHandler(this.btnFourierTest_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnConstant);
            this.tabPage2.Controls.Add(this.chtMain);
            this.tabPage2.Controls.Add(this.btnSine);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1133, 656);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ckbNoImageary
            // 
            this.ckbNoImageary.AutoSize = true;
            this.ckbNoImageary.Checked = true;
            this.ckbNoImageary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNoImageary.Location = new System.Drawing.Point(131, 58);
            this.ckbNoImageary.Name = "ckbNoImageary";
            this.ckbNoImageary.Size = new System.Drawing.Size(104, 20);
            this.ckbNoImageary.TabIndex = 5;
            this.ckbNoImageary.Text = "No Imaginary";
            this.ckbNoImageary.UseVisualStyleBackColor = true;
            // 
            // ckbShiftCenter
            // 
            this.ckbShiftCenter.AutoSize = true;
            this.ckbShiftCenter.Checked = true;
            this.ckbShiftCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShiftCenter.Location = new System.Drawing.Point(252, 58);
            this.ckbShiftCenter.Name = "ckbShiftCenter";
            this.ckbShiftCenter.Size = new System.Drawing.Size(110, 20);
            this.ckbShiftCenter.TabIndex = 6;
            this.ckbShiftCenter.Text = "Shift To Center";
            this.ckbShiftCenter.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 685);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtMain;
        private System.Windows.Forms.Button btnSine;
        private System.Windows.Forms.Button btnConstant;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnFourierTest;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown nudPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn2DFFTTest;
        private System.Windows.Forms.CheckBox ckbNoImageary;
        private System.Windows.Forms.CheckBox ckbShiftCenter;
    }
}

