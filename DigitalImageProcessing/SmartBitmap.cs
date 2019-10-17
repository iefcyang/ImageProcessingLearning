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
        public static void MaskFilter( Bitmap sourceBmp, double[,] filter )
        {
            sourceBmp = MaskFilterToNewBitmap(sourceBmp, filter);
        }

        public static Bitmap MaskFilterToNewBitmap(Bitmap sourceBmp, double[,] filter )
        {
            int xoff = filter.GetLength(1) / 2; // mask = (1+ 2 off)x(1+2 off)
            int xn = 1 + xoff + xoff;
            int yoff = filter.GetLength(0) / 2;
            int yn = 1 + yoff + yoff;
             

            Rectangle rect = new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height);
            Bitmap targetBmp = new Bitmap(sourceBmp.Width, sourceBmp.Height, sourceBmp.PixelFormat);

            BitmapData sourceData = sourceBmp.LockBits(rect, ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
            BitmapData targetData = targetBmp.LockBits(rect, ImageLockMode.WriteOnly, targetBmp.PixelFormat);

            byte* targetStart = (byte*)targetData.Scan0.ToPointer();
            byte* sourceStart = (byte*)sourceData.Scan0.ToPointer();

            int channels = sourceData.Stride / sourceData.Width;

            byte* sourcePtr;
            byte* targetPtr;
            int xNum = 0, yNum = 0;
            int diff;
            byte* rowPtr;
            byte centerValue;
            for (int h = 0; h < channels; h++)
            {
                for (int r = 0; r < sourceData.Height; r++)
                {
                    // set start address of each row
                   
                    targetPtr = targetStart + r * targetData.Stride + h;

                    if (r < yoff)
                    {
                        diff = yoff - r;
                        yNum = yn - diff;
                    }
                    else if (r > sourceData.Height - 1 - yoff)
                    {
                        diff = r - sourceData.Height + 1 + yoff;
                        yNum = yn - diff;
                    }
                    else yNum = yn;

                    if (r < yoff) sourcePtr = sourceStart + h;
                    else sourcePtr = sourceStart + (r - yoff) * sourceData.Stride + h;

                    
                    for (int c = 0; c < sourceData.Width; c++)
                    {
                       centerValue = *( sourceStart + r * sourceData.Stride + h + c* channels );

                        if (c < xoff)
                        {
                            diff = xoff - c;
                            xNum = xn - diff;
                        }
                        else if (c > sourceData.Width - 1 - xoff)
                        {
                            diff = c - sourceData.Width + 1 + xoff;
                            xNum = xn - diff;
                        }
                        else xNum = xn;

                        if (c < xoff) rowPtr = sourcePtr + c * channels;
                        else rowPtr = sourcePtr + (c - xoff) * channels;

                        byte* ptr;

                        double total = 0;
                        // filter element times pixel value
                        int yo = yn - yNum;
                        int xo = xn - xNum;
                        for (int j = 0; j < yNum; j++)
                        {
                            //*sourcePtr
                            ptr = rowPtr + j * sourceData.Stride;
                            for (int i = 0; i < xNum; i++)
                            {
                                byte v = *ptr;
                                total += v * filter[yo+j, xo+i];
                                ptr += channels;
                            }
                        }
                        // find middle value
                        *targetPtr =(byte)( centerValue + total );
                        targetPtr += channels;
                    }
                }
            }
            sourceBmp.UnlockBits(sourceData);
            targetBmp.UnlockBits(targetData);
            return targetBmp;
        }

        public static void MedianFilter( Bitmap sourceBmp, int maskSize )
        {
            sourceBmp = MedianFilterToNewBitmap(sourceBmp, maskSize);
        }



        public static Bitmap MedianFilterToNewBitmap(Bitmap sourceBmp,int maskSize)
        {
            int off = maskSize / 2 ; // mask = (1+ 2 off)x(1+2 off)
            int n = 1 + off + off;
            byte[] maskedValues = new byte[n * n];

            Rectangle rect = new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height);
            Bitmap targetBmp = new Bitmap(sourceBmp.Width, sourceBmp.Height,sourceBmp.PixelFormat);

            BitmapData sourceData = sourceBmp.LockBits(rect, ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
            BitmapData targetData = targetBmp.LockBits(rect, ImageLockMode.WriteOnly, targetBmp.PixelFormat);

            byte* targetStart = (byte*)targetData.Scan0.ToPointer();
            byte* sourceStart = (byte*)sourceData.Scan0.ToPointer();

            int channels = sourceData.Stride / sourceData.Width;

            byte* sourcePtr;
            byte* targetPtr;
            int xNum = 0, yNum = 0;
            int diff;
            byte* xptr;

            for (int h = 0; h < channels; h++)
            {
                for (int r = 0; r < sourceData.Height; r++)
                {
                    // set start address of each row
                    targetPtr = targetStart + r * targetData.Stride + h;

                    if (r < off)
                    {
                        diff = off - r;
                        yNum = n - diff;
                    }
                    else if (r > sourceData.Height - 1 - off)
                    {
                        diff = r - sourceData.Height + 1 + off;
                        yNum = n - diff;
                    }
                    else yNum = n;

                    if( r < off ) sourcePtr = sourceStart + h;
                    else  sourcePtr = sourceStart + (r - off ) * sourceData.Stride + h;
  
                    for (int c = 0; c < sourceData.Width; c++)
                    {
                        for (int i = 0; i < maskedValues.Length; i++) maskedValues[i] = 255;

                       
                        if (c < off)
                        {
                            diff = off - c;
                            xNum = n - diff;
                        }
                        else if (c > sourceData.Width - 1 - off)
                        {
                            diff = c - sourceData.Width + 1 + off;
                            xNum = n - diff;
                        }
                        else xNum = n;

                        if( c < off ) xptr = sourcePtr + c * channels;
                        else  xptr = sourcePtr + (c - off) * channels;


                        int bound = xNum * yNum;
                        byte* ptr;

                        for ( int j =  0; j < yNum; j++ )
                        {
                            //*sourcePtr
                            ptr = xptr + j * sourceData.Stride;
                            for ( int i = 0; i < xNum; i++ )
                            {
                                byte v = *ptr;
                                for( int k = 0; k < maskedValues.Length; k++)
                                {
                                    if( v <= maskedValues[k] )
                                    {
                                        for (int z = k + 1; z < bound; z++)
                                            maskedValues[z] = maskedValues[z-1];
                                        maskedValues[k] = v;
                                        break;
                                    }
                                }
                                ptr += channels;
                            }
                        }
                        // find middle value
                        *targetPtr = (byte) maskedValues[bound/ 2];
                        targetPtr += channels;
                    }
                }
            }
            sourceBmp.UnlockBits(sourceData);
            targetBmp.UnlockBits(targetData);
            return targetBmp;
        }

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
