using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021HWK03
{
    public class ColorImage
    {
        Bitmap displayedBitmap;
        int[,,] pixels;
        double[,] histograms;

        #region HELPING FUNCTIONS

        void SetPixelsFromImage()
        {
            if (displayedBitmap == null) return;

            histograms = new double[3, 256];
            for (int d = 0; d < 3; d++)
                for (int i = 0; i < 256; i++) histograms[d, i] = 0;

            pixels = new int[3, displayedBitmap.Height, displayedBitmap.Width];
            for (int r = 0; r < displayedBitmap.Height; r++)
                for (int c = 0; c < displayedBitmap.Width; c++)
                {
                    Color clr = displayedBitmap.GetPixel(c, r);
                    pixels[0, r, c] = clr.R;
                    pixels[1, r, c] = clr.G;
                    pixels[2, r, c] = clr.B;
                    histograms[0, clr.R] += 1;
                    histograms[1, clr.G] += 1;
                    histograms[2, clr.B] += 1;
                }
            int total = displayedBitmap.Height * displayedBitmap.Width;
            for (int d = 0; d < 3; d++)
                for (int i = 0; i < 256; i++) histograms[d, i] /= total;
        }

        void SetImageFromPixels( )
        {
            if (pixels == null ) return;

            int w = pixels.GetLength(2);
            int h = pixels.GetLength(1);
            if (displayedBitmap == null || displayedBitmap.Width != w ||
                displayedBitmap.Height != h || pixels.GetLength(0) != 3)
                displayedBitmap = new Bitmap(w, h);
            if (histograms == null)
                histograms = new double[3, 256];

            for (int r = 0; r < displayedBitmap.Height; r++)
                for (int c = 0; c < displayedBitmap.Width; c++)
                {
                    Color clr = Color.FromArgb(pixels[0, r, c], pixels[1, r, c], pixels[2, r, c]);
                    displayedBitmap.SetPixel(c, r, clr);
                    histograms[0, clr.R] += 1;
                    histograms[1, clr.G] += 1;
                    histograms[2, clr.B] += 1;
                }
        }

        #endregion


        #region CONSTRUCTORS


        /// <summary>
        ///  Create a color image form a given bitmap.
        /// </summary>
        /// <param name="originalImage"></param>
        public ColorImage( Bitmap originalImage )
        {
            displayedBitmap = originalImage;
            SetPixelsFromImage();
        }


        /// <summary>
        ///  Create a color image from given pixel data
        /// </summary>
        /// <param name="data"></param>
        public ColorImage(int[,,] data )
        {
            pixels = data;
            SetImageFromPixels();
        }

        #endregion
    }
}
