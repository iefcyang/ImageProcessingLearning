using FCYangImageLibray;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021HWK05
{
    public partial class MainForm : Form
    {
        Bitmap paletteBitmap;
        Color[] cols = new Color[256];
        public MainForm()
        {
            InitializeComponent();
            paletteBitmap = new Bitmap( 512, 512 );

            //cols =   ColorGamut.GetLinearInterpolatedColors( 256, 0.6, 0.3, 0.3, 0.6 );
            UpdateQuadCustomColorMap( );
          //  XYZ, L* a*b *, YUV
        }

        private void UpdateQuadColorPaletteBitmap( )
        {
            // Prepare bitmap

            double w = paletteBitmap.Width / 16.0;
            double h = paletteBitmap.Height / 16.0;
            Graphics g = Graphics.FromImage( paletteBitmap );
            RectangleF rect = new RectangleF( 0, 0, (float) w, (float) h );

            int cnt = 0;
            SolidBrush b = new SolidBrush( Color.Red );
            for( int r = 0 ; r < 16 ; r++ )
            {
                rect.Y = (float) ( r * h );
                for( int c = 0 ; c < 16 ; c++ )
                {
                    rect.X = (float) ( c * w );
                    b.Color = cols[ cnt++ ];
                    g.FillRectangle( b, rect );
                    g.DrawRectangle( Pens.DarkGray, Rectangle.Round( rect ) );
                }
            }
            pcbPallete.Image = paletteBitmap;
            // Show corner color buttons
            //btnLeftTop.BackColor = cols[0];
            //btnRightTop.BackColor = cols[15];
            //btnLeftBottom.BackColor = cols[240];
            //btnRightBottom.BackColor = cols[255];
        }

        void UpdateLinearGradientColorPallete( Color Start, Color End )
        {
            double w = paletteBitmap.Width / 16.0;
            double h = paletteBitmap.Height / 16.0;
            Graphics g = Graphics.FromImage( paletteBitmap );

            RectangleF rect = new RectangleF( 0, 0, (float) w, (float) h );
            double minR, rangeR, minG, rangeG, minB, rangeB;
            minR = Start.R; minG = Start.G; minB = Start.B;
            rangeR = End.R - Start.R; rangeG = End.G - Start.G; rangeB = End.B - Start.B;
            int cnt = 0;
            SolidBrush b = new SolidBrush( Color.Red );
            for( int r = 0 ; r < 16 ; r++ )
            {
                rect.Y = (float) ( r * h );
                for( int c = 0 ; c < 16 ; c++ )
                {
                    rect.X = (float) ( c * w );
                    b.Color = Color.FromArgb( (int) ( minR + cnt * rangeR / 255.0 ), (int) ( minG + cnt * rangeG / 255.0 ), (int) ( minB + cnt * rangeB / 255.0 ) );
                    g.FillRectangle( b, rect );
                    g.DrawRectangle( Pens.DarkGray, Rectangle.Round( rect ) );
                    cnt++;
                }
            }
            pcbPallete.Image = paletteBitmap;
        }

        private void EditColorSwatch(object sender, EventArgs e)
        {
            if( dlgColor.ShowDialog( ) != DialogResult.OK ) return;
            Button btn = sender as Button;
            btn.BackColor = dlgColor.Color;
            UpdateQuadCustomColorMap( );
        }

        private void UpdateQuadCustomColorMap()
        {
              double minR, rangeR, minG, rangeG, minB, rangeB;
            // First column
            minR = btnLeftTop.BackColor.R; rangeR = btnLeftBottom.BackColor.R - minR;
            minG = btnLeftTop.BackColor.G; rangeG = btnLeftBottom.BackColor.G - minG;
            minB = btnLeftTop.BackColor.B; rangeB = btnLeftBottom.BackColor.B - minB;
            for ( int delta = 0, mid = 0; delta < 16; delta ++, mid+=16)
            {
                cols[mid] = Color.FromArgb((int)(minR + delta * rangeR / 16.0), (int)(minG + delta * rangeG / 16.0), (int)(minB + delta * rangeB / 16.0));
            }
            // Last column
            minR = btnRightTop.BackColor.R; rangeR = btnRightBottom.BackColor.R - minR;
            minG = btnRightTop.BackColor.G; rangeG = btnRightBottom.BackColor.G - minG;
            minB = btnRightTop.BackColor.B; rangeB = btnRightBottom.BackColor.B - minB;
            for (int delta = 0, mid = 15; delta < 16; delta++, mid += 16)
            {
                cols[mid] = Color.FromArgb((int)(minR + delta * rangeR / 16.0), (int)(minG + delta * rangeG / 16.0), (int)(minB + delta * rangeB / 16.0));
            }
            // All Rows
            for( int r = 0, s = 0 ; r < 16; r++, s+=16 )
            {
                minR = cols[s].R; rangeR = cols[s+15].R - minR;
                minG = cols[s].G; rangeG = cols[s+15].G - minG;
                minB = cols[s].B; rangeB = cols[s + 15].B - minB;
                for ( int delta = 1; delta < 15; delta++ )
                {
                    cols[s+delta] = Color.FromArgb((int)(minR + delta * rangeR / 16.0), (int)(minG + delta * rangeG / 16.0), (int)(minB + delta * rangeB / 16.0));
                }
            }

            UpdateQuadColorPaletteBitmap();
        }

        //PointF[ ] corners = { new PointF(0, 0), new PointF(255, 0), new PointF(0, 255), new PointF(255, 255) };
        //double[] dis = new double[4];

        private void btnApplyPseudoColorButton_Click(object sender, EventArgs e)
        {
            // Get MonoImage
            targetImage = originalImage.CreateAverageMonoImage();
            labTwo.Text = "Gray-scale Target Image";
            pcbTwo.Image = targetImage.displayedBitmap;
 
            ColorImage pseudoImage1 = targetImage.CreatePseudoColorImage(cols);
            labThree.Text = "Pseudo Image with Quad Custom ColorMap";
            pcbThree.Image = pseudoImage1.displayedBitmap;
            ColorImage pseudoImage2 = targetImage.CreatePseudoColorImage(gamutMap.MapColors);
            labFour.Text = "Pseudo Image with Gumat Linear ColorMap";
            pcbFour.Image = pseudoImage2.displayedBitmap;
        }

        MonoImage targetImage; 
        private void btnApplyGamutColorMap_Click(object sender, EventArgs e)
        {
            
        }


        ColorImage originalImage;

        private void btnOpen_Click( object sender, EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog( );
            if( dlg.ShowDialog( ) != DialogResult.OK ) return;
            originalImage = new ColorImage( dlg.FileName );
            labOne.Text = "Original Image";
            pcbOne.Image = originalImage.displayedBitmap;

            pcbThree.Image = pcbTwo.Image = pcbFour.Image = null;
            labTwo.Text = labThree.Text = labFour.Text = "";

            tabMain.Enabled = true;
        }

        #region Buttons for (1)

        private void btnGetRGBPlanes_Click( object sender, EventArgs e )
        {
            MonoImage[] rgb =  originalImage.GetRGBPlaneImages( );
            labTwo.Text = "Red Plane";
            pcbTwo.Image = rgb[ 0 ].displayedBitmap;
            labThree.Text = "Green Plane";
            pcbThree.Image = rgb[ 1 ].displayedBitmap;
            labFour.Text = "Blue Plane";
            pcbFour.Image = rgb[ 2 ].displayedBitmap;

        }

        private void btnGetCMYPlaneImages_Click( object sender, EventArgs e )
        {
            MonoImage[ ] cmy = originalImage.GetCMYPlaneImages( );
            labTwo.Text = "Cyan Plane";
            pcbTwo.Image = cmy[ 0 ].displayedBitmap;
            labThree.Text = "Magenta Plane";
            pcbThree.Image = cmy[ 1 ].displayedBitmap;
            labFour.Text = "Yellow Plane";
            pcbFour.Image = cmy[ 2 ].displayedBitmap;
        }

        private void btnGetHSIImage_Click( object sender, EventArgs e )
        {
            MonoImage[ ] hsi = originalImage.GetHSIPlaneImages( );
            labTwo.Text = "Heu Plane";
            pcbTwo.Image = hsi[ 0 ].displayedBitmap;
            labThree.Text = "Saturation Plane";
            pcbThree.Image = hsi[ 1 ].displayedBitmap;
            labFour.Text = "Intensity Plane";
            pcbFour.Image = hsi[ 2 ].displayedBitmap;
        }

        private void btnGetXYZ_Click( object sender, EventArgs e )
        {

        }

        private void btnGetLABImages_Click( object sender, EventArgs e )
        {

        }

        private void btnGetYUVImages_Click( object sender, EventArgs e )
        {

        }



        #endregion

        private void btnGetThreeSegmentations_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int k1 = (int)nudK1.Value;
            int k2 = (int)nudK2.Value;
            int k3 = (int)nudK3.Value;
            labTwo.Text = $"{k1}-Segmentation Image";
            labThree.Text = $"{k2}-Segmentation Image";
            labFour.Text = $"{k3}-Segmentation Image";
            ColorImage img1 = originalImage.CreateRGBSegmentationImage(k1);
            pcbTwo.Image = img1.displayedBitmap;
            ColorImage img2 = originalImage.CreateRGBSegmentationImage(k2);
            pcbThree.Image = img2.displayedBitmap;
            ColorImage img3 = originalImage.CreateRGBSegmentationImage(k3);
            pcbFour.Image = img3.displayedBitmap;
            Cursor = Cursors.Default;
        }

        private void btnTwoOnDifferentData_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            labTwo.Text = $"2-RGB-Segmentation Image";
            ColorImage img1 = originalImage.CreateRGBSegmentationImage(2);
            pcbTwo.Image = img1.displayedBitmap;
            ColorImage img2 = originalImage.CreateHSISegmentationImage(2);
            pcbThree.Image = img2.displayedBitmap;
            //ColorImage img3 = originalImage.CreateLABSegmentationImage(2);
            //pcbFour.Image = img3.displayedBitmap;
            Cursor = Cursors.Default;
        }
    }
}
