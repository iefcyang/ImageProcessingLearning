namespace FourierTransformationTest
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
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).BeginInit();
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
            this.chtMain.Location = new System.Drawing.Point(14, 69);
            this.chtMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chtMain.Name = "chtMain";
            this.chtMain.Size = new System.Drawing.Size(1019, 580);
            this.chtMain.TabIndex = 0;
            this.chtMain.Text = "chart1";
            // 
            // btnSine
            // 
            this.btnSine.Location = new System.Drawing.Point(1020, 58);
            this.btnSine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSine.Name = "btnSine";
            this.btnSine.Size = new System.Drawing.Size(135, 49);
            this.btnSine.TabIndex = 1;
            this.btnSine.Text = "Sine";
            this.btnSine.UseVisualStyleBackColor = true;
            this.btnSine.Click += new System.EventHandler(this.btnSine_Click);
            // 
            // btnConstant
            // 
            this.btnConstant.Location = new System.Drawing.Point(1039, 602);
            this.btnConstant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConstant.Name = "btnConstant";
            this.btnConstant.Size = new System.Drawing.Size(135, 49);
            this.btnConstant.TabIndex = 2;
            this.btnConstant.Text = "Ranged Constant FT";
            this.btnConstant.UseVisualStyleBackColor = true;
            this.btnConstant.Click += new System.EventHandler(this.btnConstant_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 662);
            this.Controls.Add(this.btnConstant);
            this.Controls.Add(this.btnSine);
            this.Controls.Add(this.chtMain);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtMain;
        private System.Windows.Forms.Button btnSine;
        private System.Windows.Forms.Button btnConstant;
    }
}

