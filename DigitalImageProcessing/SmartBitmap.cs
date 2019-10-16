using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalImageProcessing
{
    unsafe public class SmartBitmap
    {
        public static void GrayConversion( Bitmap bmp )
        {
            bmp =  GrayConversionToNewBitmap(bmp);
        }


        public static Bitmap GrayConversionToNewBitmap(Bitmap sourceBmp)
        {
            Rectangle rect = new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height);
            Bitmap grayBmp = new Bitmap(sourceBmp.Width, sourceBmp.Height, PixelFormat.Format8bppIndexed);

            // 必須轉到另一個區域變數透過他設定新顏色，再指定回去，顏色才能變更
            ColorPalette pallete = grayBmp.Palette;
            for (int i = 0; i < grayBmp.Palette.Entries.Length; i++)
            {
                pallete.Entries[i] = Color.FromArgb(i, i, i);
            }
            grayBmp.Palette = pallete;


            BitmapData sourceData = sourceBmp.LockBits(rect, ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
            BitmapData grayData = grayBmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            byte* grayPtr = (byte*)grayData.Scan0.ToPointer();
            byte* sourcePtr = (byte*)sourceData.Scan0.ToPointer();

            int numberOfBytes = sourceData.Stride / sourceData.Width;
            for (int r = 0; r < sourceData.Height; r++)
            {
                for (int c = 0; c < sourceData.Width; c++)
                {
                    byte blue = *sourcePtr++;
                    byte green = *sourcePtr++;
                    byte red = *sourcePtr++;
                    *grayPtr = (byte)(0.11 * blue + 0.59 * green + 0.3 * red);
                    grayPtr++;
                }
            }
            sourceBmp.UnlockBits(sourceData);
            grayBmp.UnlockBits(grayData);
            return grayBmp;
        }

        public static Bitmap BWConversionBitWiseToNewBitmap(Bitmap sourceBmp, int bit )
        {
            if (bit < 0 || bit > 7) return null;

            Rectangle rect = new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height);
            Bitmap bwBmp = new Bitmap(sourceBmp.Width, sourceBmp.Height, PixelFormat.Format1bppIndexed);

            // 必須轉到另一個區域變數透過他設定新顏色，再指定回去，顏色才能變更
            ColorPalette pallete = bwBmp.Palette;

            pallete.Entries[0] = Color.FromArgb(0, 0, 0);
            pallete.Entries[1] = Color.FromArgb(255, 255, 255);

            bwBmp.Palette = pallete;


            BitmapData sourceData = sourceBmp.LockBits(rect, ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
            BitmapData bwData = bwBmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            byte* bwPtr = (byte*)bwData.Scan0.ToPointer();
            byte* sourcePtr = (byte*)sourceData.Scan0.ToPointer();

            int numberOfBytes = sourceData.Stride / sourceData.Width;
            int mask = 1 << bit;
            for (int r = 0; r < sourceData.Height; r++)
            {
                for (int c = 0; c < sourceData.Width; c++)
                {
                    byte blue = *sourcePtr++;
                    byte green = *sourcePtr++;
                    byte red = *sourcePtr++;
                    byte v = (byte)(0.11 * blue + 0.59 * green + 0.3 * red);
                    if ((v & mask) > 0) *bwPtr = 1;
                    else *bwPtr = 0;
                    bwPtr++;
                }
            }
            sourceBmp.UnlockBits(sourceData);
            bwBmp.UnlockBits(bwData);
            return bwBmp;
        }


        public static Bitmap BWConversionToNewBitmap(Bitmap sourceBmp)
        {
            Rectangle rect = new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height);
            Bitmap grayBmp = new Bitmap(sourceBmp.Width, sourceBmp.Height, PixelFormat.Format1bppIndexed);

            // 必須轉到另一個區域變數透過他設定新顏色，再指定回去，顏色才能變更
            ColorPalette pallete = grayBmp.Palette;

            pallete.Entries[0] = Color.FromArgb(0, 0, 0);
            pallete.Entries[1] = Color.FromArgb(255, 255, 255);

            grayBmp.Palette = pallete;


            BitmapData sourceData = sourceBmp.LockBits(rect, ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
            BitmapData grayData = grayBmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            byte* grayPtr = (byte*)grayData.Scan0.ToPointer();
            byte* sourcePtr = (byte*)sourceData.Scan0.ToPointer();

            int numberOfBytes = sourceData.Stride / sourceData.Width;
            for (int r = 0; r < sourceData.Height; r++)
            {
                for (int c = 0; c < sourceData.Width; c++)
                {
                    int total =  *sourcePtr++;
                    total += *sourcePtr++;
                    total += *sourcePtr++;
                    *grayPtr = (byte)( total > 384 ? 1 : 0 );
                    grayPtr++;
                }
            }
            sourceBmp.UnlockBits(sourceData);
            grayBmp.UnlockBits(grayData);
            return grayBmp;
        }

        public static void ShiftPixelValue( Bitmap bmp, int shift)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data =bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* start = (byte*)data.Scan0.ToPointer();
            int numberOfBytes = data.Stride / data.Width;
            for ( int r = 0; r < data.Height; r++ )
            {
                for( int c = 0; c < data.Width; c++ )
                {
                    for( int n = 0; n < numberOfBytes; n++)
                    {
                        *start = (byte)(*start + shift);
                        start++;
                    }
                }
            }
            bmp.UnlockBits(data);
        }

        public static Bitmap ShiftPixelValueToNewBitmap(Bitmap sourceBmp, int shift)
        {
            Bitmap targetBmp = (Bitmap) sourceBmp.Clone();
            ShiftPixelValue(targetBmp, shift);
            return targetBmp;
        }

        public static void LogarithmicPixelValue( Bitmap bmp )
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* start = (byte*)data.Scan0.ToPointer();
            int numberOfBytes = data.Stride / data.Width;
            for (int r = 0; r < data.Height; r++)
            {
                for (int c = 0; c < data.Width; c++)
                {
                    for (int n = 0; n < numberOfBytes; n++)
                    {
                        *start = (byte)( 45.99 * Math.Log(1+*start) );
                        start++;
                    }
                }
            }
            bmp.UnlockBits(data);
        }

        public static Bitmap LogarithmicPixelValueToNewBitmap(Bitmap sourceBmp)
        {
            Bitmap targetBmp = (Bitmap)sourceBmp.Clone();
            LogarithmicPixelValue(targetBmp);
            return targetBmp;
        }

        public static void ExponentialPixelValue(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* start = (byte*)data.Scan0.ToPointer();
            int numberOfBytes = data.Stride / data.Width;
            for (int r = 0; r < data.Height; r++)
            {
                for (int c = 0; c < data.Width; c++)
                {
                    for (int n = 0; n < numberOfBytes; n++)
                    {
                        *start = (byte)( Math.Exp(  *start / 45.99 ) - 1);
                        start++;
                    }
                }
            }
            bmp.UnlockBits(data);
        }

        public static Bitmap ExponentialPixelValueToNewBitmap(Bitmap sourceBmp)
        {
            Bitmap targetBmp = (Bitmap)sourceBmp.Clone();
            ExponentialPixelValue(targetBmp);
            return targetBmp;
        }

        public static int[,] GetPixelValueHistogram( Bitmap bmp )
        {
            int[,] histograms;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* start = (byte*)data.Scan0.ToPointer();
            int numberOfBytes = data.Stride / data.Width;
            histograms = new int[numberOfBytes, 256];

            for (int r = 0; r < data.Height; r++)
            {
                for (int c = 0; c < data.Width; c++)
                {
                    for (int n = 0; n < numberOfBytes; n++)
                    {
                        int v = *start;
                        histograms[n, v]++;
                        start++;
                    }
                }
            }
            bmp.UnlockBits(data);
            return histograms;
        }

    }
}
