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

            byte* grayStart = (byte*)grayData.Scan0.ToPointer();
            byte* sourceStart = (byte*)sourceData.Scan0.ToPointer();

            int numberOfBytes = sourceData.Stride / sourceData.Width;
            if (numberOfBytes < 3) throw new Exception("Only color bitmap can be converted to gray bitmap!");

            byte* sourcePtr;
            byte* grayPtr;
            for (int r = 0; r < sourceData.Height; r++)
            {
                // set start address of each row
                sourcePtr = sourceStart + r * sourceData.Stride;
                grayPtr = grayStart + r * grayData.Stride;
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

            byte* bwStart = (byte*)bwData.Scan0.ToPointer();
            byte* sourceStart = (byte*)sourceData.Scan0.ToPointer();

            int numberOfBytes = sourceData.Stride / sourceData.Width;
            if (numberOfBytes < 3) throw new Exception("Only color bitmap can be converted to gray bitmap!");

            int mask = 1 << bit;
            byte* bwPtr, sourcePtr;
            for (int r = 0; r < sourceData.Height; r++)
            {
                sourcePtr = sourceStart + r * sourceData.Stride;
                bwPtr = bwStart + r * bwData.Stride;

                for (int c = 0; c < sourceData.Width; c++)
                {
                    byte blue = *sourcePtr++;
                    byte green = *sourcePtr++;
                    byte red = *sourcePtr++;
                    byte v = (byte)(0.11 * blue + 0.59 * green + 0.3 * red);
                    if ((v & mask) > 0) *bwPtr++ = 1;
                    else *bwPtr++ = 0;
                }
            }
            sourceBmp.UnlockBits(sourceData);
            bwBmp.UnlockBits(bwData);
            return bwBmp;
        }


        public static Bitmap BWConversionToNewBitmap(Bitmap sourceBmp)
        {
            Rectangle rect = new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height);
            Bitmap bwBmp = new Bitmap(sourceBmp.Width, sourceBmp.Height, PixelFormat.Format1bppIndexed);

            // 必須轉到另一個區域變數透過他設定新顏色，再指定回去，顏色才能變更
            ColorPalette pallete = bwBmp.Palette;

            pallete.Entries[0] = Color.FromArgb(0, 0, 0);
            pallete.Entries[1] = Color.FromArgb(255, 255, 255);

            bwBmp.Palette = pallete;


            BitmapData sourceData = sourceBmp.LockBits(rect, ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
            BitmapData bwData = bwBmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            byte* bwStart = (byte*)bwData.Scan0.ToPointer();
            byte* sourceStart = (byte*)sourceData.Scan0.ToPointer();

            int numberOfBytes = sourceData.Stride / sourceData.Width;
            byte* sourcePtr, bwPtr;

            for (int r = 0; r < sourceData.Height; r++)
            {
                sourcePtr = sourceStart + r * sourceData.Stride;
                bwPtr = bwStart + r * bwData.Stride;

                for (int c = 0; c < sourceData.Width; c++)
                {
                    int total = 0;
                    for (int z = 0; z < numberOfBytes; z++)
                    {
                        total += *sourcePtr++;
                    }
                    *bwPtr++ = (byte)( total >  127 * numberOfBytes  ? 1 : 0 );
                }
            }
            sourceBmp.UnlockBits(sourceData);
            bwBmp.UnlockBits(bwData);
            return bwBmp;
        }

        public static void ShiftPixelValue( Bitmap bmp, int shift)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data =bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* start = (byte*)data.Scan0.ToPointer();
            int numberOfBytes = data.Stride / data.Width;
            byte* ptr;
            for ( int r = 0; r < data.Height; r++ )
            {
                ptr = start + r * data.Stride;
                for( int c = 0; c < data.Width; c++ )
                {
                    for( int n = 0; n < numberOfBytes; n++)
                    {
                        *ptr = (byte)(*ptr + shift);
                        ptr++;
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
            byte* ptr;
            for (int r = 0; r < data.Height; r++)
            {
                ptr = start + r * data.Stride;

                for (int c = 0; c < data.Width; c++)
                {
                    for (int n = 0; n < numberOfBytes; n++)
                    {
                        *ptr = (byte)( 45.99 * Math.Log(1+*ptr) );
                        ptr++;
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
            byte* ptr;

            for (int r = 0; r < data.Height; r++)
            {
                ptr = start + r * data.Stride;

                for (int c = 0; c < data.Width; c++)
                {
                    for (int n = 0; n < numberOfBytes; n++)
                    {
                        *ptr = (byte)( Math.Exp(  *ptr / 45.99 ) - 1);
                        ptr++;
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
            byte* ptr;

            for (int r = 0; r < data.Height; r++)
            {
                ptr = start + r * data.Stride;

                for (int c = 0; c < data.Width; c++)
                {
                    for (int n = 0; n < numberOfBytes; n++)
                    {
                        int v = *ptr;
                        histograms[n, v]++;
                        ptr++;
                    }
                }
            }
            bmp.UnlockBits(data);
            return histograms;
        }

    }
}
