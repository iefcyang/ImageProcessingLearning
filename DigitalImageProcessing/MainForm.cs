using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalImageProcessing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            cbxSizeMode.DataSource = Enum.GetValues(typeof(PictureBoxSizeMode));
            pcbMain.SizeMode = PictureBoxSizeMode.Zoom;
            cbxSizeMode.SelectedItem = pcbMain.SizeMode;
            cbxRGB.SelectedIndex = 0;
            cbxFilter.SelectedIndex = 0;
        }
         
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "JPG|*.jpg|JEPG|*.jepg|png|*.png", FilterIndex = 1 })
            {
                if( dlg.ShowDialog() == DialogResult.OK)
                {
                    pcbMain.Image = Bitmap.FromFile(dlg.FileName);
                    PropertyGrid.SelectedObject = pcbMain.Image;
                }
            }
        }

        private void cbxSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcbMain.SizeMode = (PictureBoxSizeMode)cbxSizeMode.SelectedItem;
            pcbMain.Refresh();
            pcbSecond.SizeMode = (PictureBoxSizeMode)cbxSizeMode.SelectedItem;
            pcbSecond.Refresh();
        }
        private void btnAddPixelValue_Click(object sender, EventArgs e)
        {
            pcbSecond.Image = SmartBitmap.ShiftPixelValueToNewBitmap((Bitmap)pcbMain.Image, (int)nudShift.Value);
            PropertyGrid.SelectedObject = pcbSecond.Image;
        }
        PictureBox[] pcbs = null;
        GroupBox[] gps = null;
        private void btnGenerateGray_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (ckbSmart.Checked) labMessage.Text = "Lock/Unlock Pixel Method: ";
            else labMessage.Text = "Get/Set Pixel Method: ";

            flpMultiple.Visible = true;
            spcThird.Visible = false;
            flpMultiple.Dock = DockStyle.Fill;
            //PictureBox[] pcbs = null;
            //GroupBox[] gps = null;
            int w = (int)( flpMultiple.Width / 3.2);
            int h = w;
            if (flpMultiple.Controls.Count == 0)
            {
                // create 9 picturebox
                pcbs = new PictureBox[10];
                gps = new GroupBox[10];
                for (int i = 0; i < pcbs.Length; i++)
                { // PictureBox pb in pcbs)
                    gps[i] = new GroupBox();
                    gps[i].Width = w;
                    gps[i].Height = h;
                    gps[i].BackColor = Color.LightCyan;
                    flpMultiple.Controls.Add(gps[i]);
                    pcbs[i] = new PictureBox();
                    pcbs[i].Dock = DockStyle.Fill;
                    gps[i].Controls.Add(pcbs[i]);
                    gps[i].Text = $"{9 - i}-bit image";
                    pcbs[i].SizeMode = (PictureBoxSizeMode)cbxSizeMode.SelectedItem;
                    pcbs[i].Click += PictureBoxClicked;
                }
            }
            gps[0].Text = $"original gray image";
            gps[1].Text = $"half B/W image";

            DateTime startTime = DateTime.Now;

            if (ckbSmart.Checked)
            {
                pcbs[0].Image = SmartBitmap.GrayConversionToNewBitmap((Bitmap)pcbMain.Image);
                pcbs[1].Image = SmartBitmap.BWConversionToNewBitmap((Bitmap)pcbMain.Image);
                for (int i = 2; i < 10; i++)
                {
                    pcbs[i].Image = SmartBitmap.BWConversionBitWiseToNewBitmap((Bitmap)pcbMain.Image, 9 - i);
                }
            }
            else
            {
                Bitmap bp = (Bitmap)pcbMain.Image.Clone();

                for (int r = 0; r < bp.Height; r++)
                {
                    for (int c = 0; c < bp.Width; c++)
                    {
                        int v = bp.GetPixel(c, r).R;
                        bp.SetPixel(c, r, Color.FromArgb(v, v, v));
                    }
                }
                pcbs[0].Image = bp;
                for (int i = 2; i < 10; i++)
                {
                    barProgress.Value = Math.Min( 100, (int)((i + 1) * 100.0 / 9));
                    statusStrip1.Refresh();

                    bp = (Bitmap)pcbs[0].Image.Clone();
                    int mask = 1 << (9 - i);
                    for (int r = 0; r < bp.Height; r++)
                    {
                        for (int c = 0; c < bp.Width; c++)
                        {
                            int v = bp.GetPixel(c, r).R;

                            if ((mask & v) != 0)
                            {
                                if (rdbBW.Checked)
                                    bp.SetPixel(c, r, Color.White);
                                else
                                    bp.SetPixel(c, r, Color.FromArgb(mask, mask, mask));
                            }
                            else bp.SetPixel(c, r, Color.Black);
                        }
                    }
                    pcbs[i].Image = bp;
                }
            }

            //PixelFormat pf = PixelFormat.Format1bppIndexed;
            PropertyGrid.SelectedObject = pcbs[0];
            labMessage.Text += $" Time Used: {DateTime.Now-startTime}";
            Cursor = Cursors.Default;
        }

        ColorPalette GetGrayScalePalette()
        {
            Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);

            ColorPalette monoPalette = bmp.Palette;

            Color[] entries = monoPalette.Entries;

            for (int i = 0; i < 256; i++)
            {
                entries[i] = Color.FromArgb(i, i, i);
            }

            return monoPalette;
        }

        private void TabMain_TabIndexChanged(object sender, EventArgs e)
        {
            if( tabMain.SelectedTab == pagTTransform )
            {
                flpMultiple.Visible = false;
                spcThird.Visible = true;
            }
            else
            {
                flpMultiple.Visible = true;
                spcThird.Visible = false;
            }
        }

        private void btnLogExp_Click(object sender, EventArgs e)
        {
            Bitmap second;
            if (sender == btnLog)
                second = SmartBitmap.LogarithmicPixelValueToNewBitmap((Bitmap)pcbMain.Image);
            else
                second = SmartBitmap.ExponentialPixelValueToNewBitmap((Bitmap)pcbMain.Image);
            pcbSecond.Image = second;
            PropertyGrid.SelectedObject = pcbSecond.Image;
        }

        void ShowLogarithmicAndExponentialTransformationCurves()
        {
 
            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            chtHistogram.Series.Add(s);
            for (int i = 0; i < 255; i++)
            {
                double y = (byte)(45.99 * Math.Log(1 + i));
                s.Points.AddXY(i, y);
            }
            s = new Series();
            s.ChartType = SeriesChartType.Line;
            chtHistogram.Series.Add(s);
            for (int y = 0; y < 255; y++)
            {
                double x = (byte)(Math.Exp(y / 45.99) - 1);
                s.Points.AddXY(y, x);
            }
 
        }

        int[,] histograms;
        private void btnHistogram_Click(object sender, EventArgs e)
        {
            histograms = SmartBitmap.GetPixelValueHistogram((Bitmap)pcbMain.Image);
            int layers = histograms.GetLength(0);
            cbxRGB.Items.Clear();

            for (int i = 0; i < layers; i++) cbxRGB.Items.Add($"Layer{i}");
            switch( layers)
            {
                case 1:
                    cbxRGB.Items[0] = "Gray";
                    break;
                case 3:
                    cbxRGB.Items[0] = "Blue";
                    cbxRGB.Items[1] = "Green";
                    cbxRGB.Items[2] = "Red";
                    break;
                case 4:
                    cbxRGB.Items[0] = "Alpha";
                    cbxRGB.Items[1] = "Blue";
                    cbxRGB.Items[2] = "Green";
                    cbxRGB.Items[3] = "Red";
                    break;
            }
            cbxRGB.SelectedIndex = 0;
 
            cbxRGB_SelectedIndexChanged(null, null);

        }

        private void LockUnlockBitsExample(PaintEventArgs e)
        {

            // Create a new bitmap.
            Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
                bmp.LockBits(rect, ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int numberOfbytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[numberOfbytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, numberOfbytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int counter = 2; counter < rgbValues.Length; counter += 3)
                rgbValues[counter] = 255;

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numberOfbytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            e.Graphics.DrawImage(bmp, 0, 150);

        }

        public static Bitmap RGB2Gray(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);

            //將srcBitmap鎖定到系統內的記憶體的某個區塊中，並將這個結果交給BitmapData類別的srcBimap
            BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);

            //將CreateGrayscaleImage灰階影像，並將這個結果交給Bitmap類別的dstBimap
            Bitmap dstBitmap = CreateGrayscaleImage(wide, height);//這個函數在後面有定義

            //將dstBitmap鎖定到系統內的記憶體的某個區塊中，並將這個結果交給BitmapData類別的dstBimap
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite,
            PixelFormat.Format8bppIndexed);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr、dstPtr，為srcBmData、dstBmData的掃描行的開始位置
            System.IntPtr srcPtr = srcBmData.Scan0;
            System.IntPtr dstPtr = dstBmData.Scan0;

            //將Bitmap對象的訊息存放到byte中
            int src_bytes = srcBmData.Stride * height;
            byte[] srcValues​​ = new byte[src_bytes];

            int dst_bytes = dstBmData.Stride * height;
            byte[] dstValues​​ = new byte[dst_bytes];

            //複製GRB信息到byte中
            System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcValues​​, 0, src_bytes);
            System.Runtime.InteropServices.Marshal.Copy(dstPtr, dstValues​​, 0, dst_bytes);

            //根據Y=0.299*R+0.114*G+0.587B,Y為亮度
            for (int i = 0; i < height; i++)
                for (int j = 0; j < wide; j++)
                {
                    //只處理每行中圖像像素數據,捨棄未用空間
                    //注意位圖結構中RGB按BGR的順序存儲
                    int k = 3 * j;
                    byte temp = (byte)
                   (srcValues​​[i * srcBmData.Stride + k + 2] * .299 +
                    srcValues​​[i * srcBmData.Stride + k + 1] * .587 +
                    srcValues​​[i * srcBmData.Stride + k] * .114);
                    dstValues​​[i * dstBmData.Stride + j] = temp;
                }
            System.Runtime.InteropServices.Marshal.Copy(dstValues​​, 0, dstPtr, dst_bytes);

            //解鎖位圖
            srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);
            return dstBitmap;
        }

        private static Bitmap CreateGrayscaleImage(int wide, int height)
        {
            throw new NotImplementedException();
        }



        private void cbxRGB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch( cbxRGB.Items[ cbxRGB.SelectedIndex] )
            {
                case "Red"://red
                    chtHistogram.Series[0].Color = Color.Pink;
                    break;
                case "Gray"://Gray
                    chtHistogram.Series[0].Color = Color.Gray;
                    break;
                case "Green":// green
                    chtHistogram.Series[0].Color = Color.LightGreen;
                    break;
                case "Blue": // blue
                    chtHistogram.Series[0].Color = Color.LightBlue;
                    break;
                default:
                    chtHistogram.Series[0].Color = Color.Olive;
                    break;
            }
            if (histograms != null)
            {
 
                if (chtHistogram.Series[0].Points.Count < 256)
                    for (int i = 0; i < 256; i++)
                        chtHistogram.Series[0].Points.AddXY(i, histograms[cbxRGB.SelectedIndex, i]);
                else
                    for (int i = 0; i < 256; i++)
                        chtHistogram.Series[0].Points[i].YValues[0] = histograms[cbxRGB.SelectedIndex, i];
                chtHistogram.ChartAreas[0].RecalculateAxesScale();
                chtHistogram.ChartAreas[0].AxisX.Minimum = 0;
                chtHistogram.ChartAreas[0].AxisX.Maximum = 255;
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            pcbSecond.Image = SmartBitmap.GrayConversionToNewBitmap((Bitmap)pcbMain.Image );
        }

        private void PictureBoxClicked(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Image != null)
                PropertyGrid.SelectedObject = ((PictureBox)sender).Image;
        }

        private void flpMultiple_SizeChanged(object sender, EventArgs e)
        {
            int w = (int)( flpMultiple.Width/ 3.2 );
            for(int i = 0; i < flpMultiple.Controls.Count; i++)
            {
                flpMultiple.Controls[i].Width = flpMultiple.Controls[i].Height = w;
            }
        }

        private void btnMedianFilter_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(cbxFilter.SelectedItem.ToString());
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;
            pcbSecond.Image = SmartBitmap.MedianFilterToNewBitmap((Bitmap)pcbMain.Image, size);
            labMessage.Text = $"Median Filter Applied: {DateTime.Now - start}";
            Cursor = Cursors.Default;
        }

        private void btnHVLaplacian_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;
            double[,] filter = new double[3, 3];
            filter[0, 1] = filter[1, 0] = filter[1, 2] = filter[2, 1] = 1.0;
            filter[1, 1] = -4.0;
            pcbSecond.Image = SmartBitmap.MaskFilterToNewBitmap((Bitmap)pcbMain.Image,  filter );
            labMessage.Text = $"H/V Laplacian Filter Applied: {DateTime.Now - start}";
            Cursor = Cursors.Default;
        }

        private void btnDiagLaplacian_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;
            double[,] filter = new double[3, 3];
            filter[0, 0] = filter[2, 2] = filter[0, 2] = filter[2, 0] = 1.0;
            filter[1, 1] = -4.0;
            pcbSecond.Image = SmartBitmap.MaskFilterToNewBitmap((Bitmap)pcbMain.Image, filter);
            labMessage.Text = $"Diagonal Laplacian Filter Applied: {DateTime.Now - start}";
            Cursor = Cursors.Default;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            pcbMain.Image = pcbSecond.Image;
        }
    }
}
