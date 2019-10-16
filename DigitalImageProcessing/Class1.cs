using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DigitalImageProcessing
{
    class Form1 : Form
    {

        //        C#影像處理入門(-bitmap類和圖像像素值獲取方法)
        //出處：http://blog.csdn.net/ma_jiang/article/details/7725458

        //一．Bitmap類別
        //Bitmap對象封裝了ＧＤＩ+中的一個位元圖，此位元圖由圖形圖像及其屬性的像素數據組成.
        //見維基百科：http://zh.wikipedia.org/wiki/BMP
        //即對每一個單一像素在一個位元圖上的處理。

        //因此Bitmap是用於處理由像素數據定義的圖像的對象.該類的主要方法和屬性如下：

        //1. GetPixel方法和SetPixel方法：和設置一個圖像的指定像素的顏色.
        //2. PixelFormat屬性：返回圖像的像素格式.
        //3. Palette屬性：獲取和設置圖像所使用的顏色調色板.
        //4. Height Width屬性：返回圖像的高度和寬度.
        //5. LockBits方法和UnlockBits方法：分別鎖定和解鎖系統內存中的位圖像素.

        //在基於像素點的圖像處理方法中使用LockBits和UnlockBits是一個很好的方式，
        //這兩種方法可以使我們指定像素的範圍來控制位圖的任意一部分，
        //從而消除了通過循環對位圖的像素逐個進行處理，每用LockBits之後都應該調用一次UnlockBits.

        //二．BitmapData類別
        //BitmapData對象指定了位元圖的屬性，指定點陣圖影像的屬性(Attribute)。 BitmapData 類別是由 Bitmap 類別的 LockBits 和 UnlockBits 方法所使用。 無法被繼承。

        //1. Height屬性：被鎖定位圖的高度.
        //2. Width屬性：被鎖定位圖的高度.
        //3. PixelFormat屬性：數據的實際像素格式.
        //4. Scan0屬性：被鎖定數組的首字節地址，如果整個圖像被鎖定，則是圖像的第一個字節地址.
        //5. Stride屬性：步幅，也稱為掃描寬度.



        //如上圖所示,數組的長度並不一定等於圖像像素數組的長度,還有一部分未用區域,
        //這涉及到位圖的本身結構,系統要保證每行的字節數必須為4的倍數.
        //否則上圖右側灰色區域的未使用空間(offset) 就是一排中非4的倍數中的畸零地

        //三．Graphics類別
        //Graphics對像是ＧＤＩ+的關鍵所在，許多對像都是由Graphics類表示的，該類別定義了繪製和填充圖形對象的方法和屬性，一個應用程序只要需要進行繪製或著色，它就必須使用Graphics對象.
        //就是在一張圖上要做些甚麼繪製的動作時，就是使用這個類別

        //四．Image類別
        //這個類提供了位元圖和位元文件操作的函數.
        //Image類被聲明為abstract, 也就是說Image類不能實例化對象, 而只能做為一個基本類

        //1.FromFile方法：從指定的檔案建立 Image 物件。
        //它根據輸入的文件名產生一個Image對象, 它有兩種函數形式:
        ////public static Image FromFile(string filename);
        //從指定的檔案建立 Image 物件。
        ////  public static Image FromFile(string filename, bool useEmbeddedColorManagement);
        //使用指定之檔案中的內嵌色彩管理資訊，從該檔案建立 Image

        //2.FromHBitmap方法：從 Windows 控制代碼建立 Bitmap。
        //它從一個windows句柄​​處創建一個bitmap對象,它也包括兩種函數形式:
        ////public static bitmap fromhbitmap(intptr hbitmap);
        //從 GDI 點陣圖控制代碼建立 Bitmap。
        ////public static bitmap fromhbitmap(intptr hbitmap, intptr hpalette);
        //從 GDI 點陣圖控制代碼和 GDI 調色盤控制代碼建立 Bitmap

        //3. FromStream方法：從指定的資料流建立 Image。
        //從一個數據流中創建一個image對象,它包含三種函數形式:
        ////public static image fromstream(stream stream);
        //從指定的資料流建立 Image。
        //// public static image fromstream(stream stream, bool useembeddedcolormanagement);
        ////選擇性地使用指定之資料流中的內嵌色彩管理資訊，從該資料流建立 Image。
        //fromstream(stream stream, bool useembeddedcolormanagement, bool validateimagedata);
        ////選擇性地使用内嵌色彩管理資訊並驗證影像資料，從指定的資料流建立 Image。

        //有了上面了理解，在看下面的部分

        //一.開檔、存檔、讀檔、寫檔


        //開檔、存檔、讀檔、寫檔 分別有其代表之意義。


        //開檔：是打開檔案顯示在銀幕上

        //存檔：是將做好的檔案儲存在電腦的資料夾

        //讀檔：是將檔案中的資料讀成Byte或Bit的檔案，讓電腦看得懂

        //寫檔：是將檔案讀出來之後，使用者才做更改、修正

        //所以在檔案處理的順序來說，應該是要

        //開檔-->讀檔-->寫檔-->存檔

        private Bitmap srcBitmap = null;//原始的Bitmap
        private Bitmap showBitmap = null;//顯示用的Bitmap


        //打開文件
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = @"Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合適文件
  (*.bmp,*.jpg)|*.bmp;*.jpg ";
            ofd.FilterIndex = 3;
            ofd.RestoreDirectory = true;

            if (DialogResult.OK == ofd.ShowDialog())
            {
                srcBitmap = (Bitmap)Bitmap.FromFile(ofd.FileName, false);
                showBitmap = srcBitmap;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(showBitmap.Width),
                (int)(showBitmap.Height));
                this.Invalidate();
            }
        }

        //保存圖像文件
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (showBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = @"Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合適文件
      (*.bmp,*.jpg)|*.bmp;*.jpg";

                sfd.FilterIndex = 3;
                sfd.RestoreDirectory = true;
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    ImageFormat format = ImageFormat.Jpeg;
                    switch (Path.GetExtension(sfd.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            MessageBox.Show("Unsupported image format was specified", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    try
                    {
                        showBitmap.Save(sfd.FileName, format);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed writing image file", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        void a1()
        {
            //        c#中將bitmap或者image保存為清晰的gif

            //在c#中默認可以講bitmap保存為gif等格式,但是這種保存方法保存的gif會嚴重失真，正常情況下的代碼:

            System.Drawing.Bitmap b = new System.Drawing.Bitmap("c://original_image.gif");
            Image thmbnail = b.GetThumbnailImage(100, 75, null, new IntPtr());
            thmbnail.Save("c://thumnail.gif", System.Drawing.Imaging.ImageFormat.Gif);
        }
        //一個批量處理圖片的軟件,包括各種處理方式,處理效果,但是在保存為gif的時候出現了問題,在網上查了很久也沒有發現一個可用的改善gif圖片質量的方法,找到了一個解決辦法,保存出來的gif容量大減,但是效果基本符合常規這中方法就是就是"Octree" 算法。
        //"Octree" 算法允許我們插入自己的算法來量子化我們的圖像。
        //一個好的"顏色量子化”算法應該考慮在兩個像素顆粒之間填充與這兩個像素顏色相近的過渡顏色，提供更多可視顏色空間。

        //Morgan Skinner提供了很好的"Octree" 算法代碼，大家可以下載參考使用。

        void a2()
        {
            //使用OctreeQuantizer很方便：
            System.Drawing.Bitmap b = new System.Drawing.Bitmap("c://original_image.gif");
            System.Drawing.Image thmbnail = b.GetThumbnailImage(100, 75, null, new IntPtr());
            OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
            using (Bitmap quantized = quantizer.Quantize(thmbnail))
            {
                quantized.Save("c://thumnail.gif", System.Drawing.Imaging.ImageFormat.Gif);

            }
            OctreeQuantizer grayquantizer = new GrayscaleQuantizer();
            using (Bitmap quantized = grayquantizer.Quantize(thmbnail))
            {
                quantized.Save("c://thumnail.gif", System.Drawing.Imaging.ImageFormat.Gif);
            }
            //你可以點擊這裡下載類的文件(項目文件 ),根據我的試用,只需要兩個類文件(OctreeQuantizer.cs, Quantizer.cs)即可運行,將這兩個類文件的namespace改成
            //你項目的名稱就行, 還有, 需要在不安全編譯的方式下編譯, 右擊項目名稱, 在生成選項卡里選擇"允許不安全代碼"即可
        }

        //窗口重繪,在窗體上顯示圖像,重載Paint
        private void frmMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (showBitmap != null)
            {
                Graphics g = e.Graphics;
                g.DrawImage(showBitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y,
                (int)(showBitmap.Width), (int)(showBitmap.Height)));
            }
        }
        //灰度化
        private void menu2Gray_Click(object sender, EventArgs e)
        {
            if (showBitmap == null) return;
            showBitmap = RGB2Gray(showBitmap);//下面都以RGB2Gray為例
            //this.Invalidate();
        }
        //二.提取像素法(超級無敵慢)
        //即用C#中的getPixel和setPixel 來做取得和設定像素。
        //這種方法簡單易懂,但相當耗時,完全不可取.

        public static Bitmap RGB2Gray(Bitmap srcBitmap)
        {
            Color srcColor;
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < wide; x++)
                {
                    //獲取像素的ＲＧＢ顏色值
                    srcColor = srcBitmap.GetPixel(x, y);
                    byte temp = (byte)(srcColor.R * .299 + srcColor.G * .587 + srcColor.B * .114);
                    //設置像素的ＲＧＢ顏色值
                    srcBitmap.SetPixel(x, y, Color.FromArgb(temp, temp, temp));
                }
            return srcBitmap;
        }
        //三.內存法(速度較快)
        //這是比較常用的方法，即http://softwarebydefault.com/2013/05/18/image-median-filter/所用之法
        //大概的步驟如下：
        //   先建立一個rect，這是用來放圖的框框

        public static Bitmap aRGB2Gray(Bitmap srcBitmap)
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

        //四 指標法(速度最快)
        //C/C++的習慣,不是C#的特點，但是效率奇高

        public unsafe static Bitmap bRGB2Gray(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);

            //將srcBitmap鎖定到系統內的記憶體的某個區塊中，並將這個結果交給BitmapData類別的srcBimap
            BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);

            //將CreateGrayscaleImage灰階影像，並將這個結果交給Bitmap類別的dstBimap
            Bitmap dstBitmap = CreateGrayscaleImage(wide, height);

            //將dstBitmap鎖定到系統內的記憶體的某個區塊中，並將這個結果交給BitmapData類別的dstBimap
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite,
            PixelFormat.Format8bppIndexed);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr、dstPtr，為srcBmData、dstBmData的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;
            System.IntPtr dstScan = dstBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                byte* dstP = (byte*)(void*)dstScan;
                int srcOffset = srcBmData.Stride - wide * 3;
                int dstOffset = dstBmData.Stride - wide;
                byte red, green, blue;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < wide; x++, srcP += 3, dstP++)
                    {
                        blue = srcP[0];
                        green = srcP[1];
                        red = srcP[2];
                        *dstP = (byte)(.299 * red + .587 * green + .114 * blue);
                    }
                    srcP += srcOffset;
                    dstP += dstOffset;
                }
            }
            srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);
            return dstBitmap;
        }
        Bitmap curBitmap = null;
        byte[] RGB;
        unsafe void ff1()
        {
            //五.矩陣法
            //並不是什麼新方法, 只是將圖像數據分做R, G,B三個矩陣(二維數組)存儲,類似MATLAB的習慣.
            //  參閱出處連結


            //  C# 數字圖像處理的3 種典型方法( 精簡版)
            //C#數字圖像處理有3種典型方法：提取像素法、內存法、指標法。
            //其中提取像素法使用的是GDI+中的Bitmap.GetPixel和Bitmap.SetPixel方法；
            //內存法是通過LockBits方法來獲取位圖的首位址，從而把圖像數據直接複製到內存中進行處理；
            //指標法與內存法相似，但該方法直接應用指標對應位置圖進行操作，由於在默認情況下，C#不支持指標運算，所以該方法只能在unsafe關鍵字所標記的代碼塊中使用。

            //以一幅真彩色圖像的灰度化為例，下面代碼分別展現了這3種方法的使用，
            //方便學習圖像處理的基本技巧。
            //(1) 像素提取法
            if (curBitmap != null)
            {
                Color curColor;
                int gray;
                for (int i = 0; i < curBitmap.Width; i++)
                {
                    for (int j = 0; j < curBitmap.Height; j++)
                    {
                        curColor = curBitmap.GetPixel(i, j);
                        gray = (int)(0.3 * curColor.R + 0.59 * curColor.G * 0.11 * curColor.B);
                        curBitmap.SetPixel(i, j, curColor);
                    }
                }
            }
            //(2) 內存法
            if (curBitmap != null)
            {
                int width = curBitmap.Width;
                int height = curBitmap.Height;
                int len​​gth = height * 3 * width;
                RGB = new byte[length];
                BitmapData data = curBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                System.IntPtr Scan0 = data.Scan0;
                Marshal.Copy(Scan0, RGB, 0, length);
               // Marshal.Copy(Scan0, ​​RGB, 0, length);
                double gray = 0;
                for (int i = 0; i < RGB.Length; i = i + 3)
                {
                    gray = RGB[i + 2] * 0.3 + RGB[i + 1] * 0.59 + RGB[i] * 0.11;
                    RGB[i + 2] = RGB[i + 1] = RGB[i] = (byte)gray;
                }
                Marshal.Copy(RGB, 0, Scan0, length);
                //System.Runtime.InteropServices.Marshal.Copy(RGB, 0, Scan0, ​​length);
                curBitmap.UnlockBits(data);
            }
            //(3) 指標法
            if (curBitmap != null)
            {
                int width = curBitmap.Width;
                int height = curBitmap.Height;
                BitmapData data = curBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                System.IntPtr Scan0 = data.Scan0;
                int stride = data.Stride;
                Marshal.Copy(Scan0,RGB, 0, length);
                unsafe
                {
                    byte* p = (byte*)Scan0;
                    int offset = stride - width * 3;
                    double gray = 0;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            gray = 0.3 * p[2] + 0.59 * p[1] + 0.11 * p[0];
                            p[2] = p[1] = p[0] = (byte)gray;
                            p += 3;
                        }
                        p += offset;
                    }
                }
                curBitmap.UnlockBits(data);
            }

            //在以上3種方法中：
            //提取像素法能直觀的展示圖像處理過程，可讀性很好，但效率最低，並不適合做圖像處理方面的工程應用；
            //內存法把圖像直接複製到內存中，直接對內存中的數據進行處理，速度明顯提高，程式難度也不大；
            //指標法直接應用指標對圖像進行處理，所以速度最快。

            //三．小結：

            //本文通過一個簡單的實例向大家展現了用Visual C#以及GDI+完成數字圖像處理的基本方法，

            //通過實例，我們不難發現合理運用新技術不僅可以大大簡化我們的編程工作，

            //還可以提高編程的效率。

            //不過我們在運用新技術的同時也得明白掌握基本的編程思想才是最主要的，

            //不同的語言、不同的機制只是實現的具體方式不同而已，其內在的思想還是相通的。

            //對於上面的例子，掌握了編寫圖像處理函數的算法，用其他的方式實現也應該是可行的。

            //同時，在上面的基礎上，讀者不妨試著舉一反三，編寫出更多的圖像處理的函數來，

            //以充實並完善這個簡單的實例。

            //image與byte數組的轉換
        }

        void g()
        {
            PictureBox pictureBox1 = null;
            //image to byte[] MemoryStream ms=new MemoryStream();

            byte[] imagedata = null;
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

            imagedata = ms.GetBuffer();
            //  byte[] to image ms = New IO.MemoryStream(by) img = Drawing.Image.FromStream(ms)
        }
    }
}