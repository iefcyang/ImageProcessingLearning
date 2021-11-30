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


        #region Functions for (2)

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

        //void UpdateLinearGradientColorPallete( Color Start, Color End )
        //{
        //    double w = paletteBitmap.Width / 16.0;
        //    double h = paletteBitmap.Height / 16.0;
        //    Graphics g = Graphics.FromImage( paletteBitmap );

        //    RectangleF rect = new RectangleF( 0, 0, (float) w, (float) h );
        //    double minR, rangeR, minG, rangeG, minB, rangeB;
        //    minR = Start.R; minG = Start.G; minB = Start.B;
        //    rangeR = End.R - Start.R; rangeG = End.G - Start.G; rangeB = End.B - Start.B;
        //    int cnt = 0;
        //    SolidBrush b = new SolidBrush( Color.Red );
        //    for( int r = 0 ; r < 16 ; r++ )
        //    {
        //        rect.Y = (float) ( r * h );
        //        for( int c = 0 ; c < 16 ; c++ )
        //        {
        //            rect.X = (float) ( c * w );
        //            b.Color = Color.FromArgb( (int) ( minR + cnt * rangeR / 255.0 ), (int) ( minG + cnt * rangeG / 255.0 ), (int) ( minB + cnt * rangeB / 255.0 ) );
        //            g.FillRectangle( b, rect );
        //            g.DrawRectangle( Pens.DarkGray, Rectangle.Round( rect ) );
        //            cnt++;
        //        }
        //    }
        //    pcbPallete.Image = paletteBitmap;
        //}

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
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            // Get MonoImage
            targetImage = originalImage.CreateAverageMonoImage();
            labTwo.Text = "Gray-scale Target Image";
            pcbTwo.Image = targetImage.displayedBitmap;
            ColorImage pseudoImage1;

            if( tabSecond.SelectedTab == pagSlicing )
            {
                Color[ ] maps = new Color[ lsvSlices.Items.Count ];
                int[ ] levels = new int[ lsvSlices.Items.Count ];
                for( int i = 0 ; i < lsvSlices.Items.Count ; i++ )
                {
                    maps[ i ] = lsvSlices.Items[ i ].BackColor;
                    levels[ i ] = int.Parse( lsvSlices.Items[ i ].Text);
                }
                pseudoImage1 = targetImage.CreatePseudoColorImage( maps, levels );
                labThree.Text = "Pseudo Image with Slicing";
            }
            else
            {
                pseudoImage1 = targetImage.CreatePseudoColorImage( cols );
                labThree.Text = "Pseudo Image with Quad Custom ColorMap";
            }
                pcbThree.Image = pseudoImage1.displayedBitmap;



            ColorImage pseudoImage2 = targetImage.CreatePseudoColorImage(gamutMap.MapColors);
            labFour.Text = "Pseudo Image with Gumat Linear ColorMap";
            pcbFour.Image = pseudoImage2.displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        #endregion

        MonoImage targetImage; 
        ColorImage originalImage;

        //private void btnApplyGamutColorMap_Click(object sender, EventArgs e)
        //{
            
        //}




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
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            MonoImage[] rgb = originalImage.GetPlaneImages(ColorModel.RGB);
            labTwo.Text = "Red Plane";
            pcbTwo.Image = rgb[ 0 ].displayedBitmap;
            labThree.Text = "Green Plane";
            pcbThree.Image = rgb[ 1 ].displayedBitmap;
            labFour.Text = "Blue Plane";
            pcbFour.Image = rgb[ 2 ].displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();

        }

        private void btnGetCMYPlaneImages_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            MonoImage[ ] cmy = originalImage.GetPlaneImages(ColorModel.CMY);
            labTwo.Text = "Cyan Plane";
            pcbTwo.Image = cmy[ 0 ].displayedBitmap;
            labThree.Text = "Magenta Plane";
            pcbThree.Image = cmy[ 1 ].displayedBitmap;
            labFour.Text = "Yellow Plane";
            pcbFour.Image = cmy[ 2 ].displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        private void btnGetHSIImage_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            MonoImage[ ] hsi = originalImage.GetPlaneImages(ColorModel.HSI);
            labTwo.Text = "Hue Plane";
            pcbTwo.Image = hsi[ 0 ].displayedBitmap;
            labThree.Text = "Saturation Plane";
            pcbThree.Image = hsi[ 1 ].displayedBitmap;
            labFour.Text = "Intensity Plane";
            pcbFour.Image = hsi[ 2 ].displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        private void btnGetXYZImages_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            //MonoImage[] xyz = originalImage.GetXYZPlaneImages();
            MonoImage[] xyz = originalImage.GetPlaneImages(ColorModel.XYZ);
            labTwo.Text = "X Plane";
            pcbTwo.Image = xyz[0].displayedBitmap;
            labThree.Text = "Y Plane";
            pcbThree.Image = xyz[1].displayedBitmap;
            labFour.Text = "Z Plane";
            pcbFour.Image = xyz[2].displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        private void btnGetLABImages_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            // MonoImage[] lab = originalImage.GetLstartAstartBstartPlaneImages();
            MonoImage[] lab = originalImage.GetPlaneImages(ColorModel.LAB);

            labTwo.Text = "L* Plane";
            pcbTwo.Image = lab[0].displayedBitmap;
            labThree.Text = "a* Plane";
            pcbThree.Image = lab[1].displayedBitmap;
            labFour.Text = "b* Plane";
            pcbFour.Image = lab[2].displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        private void btnGetYUVImages_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            MonoImage[] planes = originalImage.GetPlaneImages(ColorModel.YUV);
            labTwo.Text = "Y Plane";
            pcbTwo.Image = planes[0].displayedBitmap;
            labThree.Text = "U Plane";
            pcbThree.Image = planes[1].displayedBitmap;
            labFour.Text = "V Plane";
            pcbFour.Image = planes[2].displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }



        #endregion

        #region Functions for (3)

        private void btnGetThreeSegmentations_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

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

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        private void btnTwoOnDifferentData_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DateTime start = DateTime.Now;

            int level = (int)nudLevels.Value;

            labTwo.Text = $"2-RGB-Segmentation Image";
            ColorImage img1 = originalImage.CreateRGBSegmentationImage(level);
            pcbTwo.Image = img1.displayedBitmap;

            labThree.Text = $"2-HSI-Segmentation Image";
            ColorImage img2 = originalImage.CreateHSISegmentationImage(level);
            pcbThree.Image = img2.displayedBitmap;

            labFour.Text = $"2-L*a*b*-Segmentation Image";
            ColorImage img3 = originalImage.CreateLABSegmentationImage(level);
            pcbFour.Image = img3.displayedBitmap;

            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
            Console.Beep();
        }

        #endregion

        private void tkbLevel_ValueChanged( object sender, EventArgs e )
        {
            labLevel.Text = tkbLevel.Value.ToString( );
        }

        Random rnd = new Random( );
        private void btnAdd_Click( object sender, EventArgs e )
        {
            // check loc 
            int pos = lsvSlices.Items.Count;
            int level = tkbLevel.Value;
            for( int i = 0 ; i < lsvSlices.Items.Count ; i++ )
            {
                int val = int.Parse( lsvSlices.Items[ i ].Text );
                if( level > val)
                {
                    pos = i;
                    break;
                }
            }
            ListViewItem lvi = new ListViewItem( level.ToString( ) );
            lvi.BackColor = Color.FromArgb( rnd.Next( 256 ), rnd.Next( 256 ), rnd.Next( 256 ) );
            lsvSlices.Items.Insert( pos, lvi );
        }

        private void btnRemove_Click( object sender, EventArgs e )
        {

        }

        private void lsvSlices_MouseClick( object sender, MouseEventArgs e )
        {
             ListViewHitTestInfo info = lsvSlices.HitTest( e.Location );
            dlgColor.Color = info.Item.BackColor;
            if( dlgColor.ShowDialog( ) == DialogResult.OK )
                info.Item.BackColor = dlgColor.Color;
        }
    }
}
