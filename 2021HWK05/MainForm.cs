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
        Bitmap colorPalette;

        public MainForm()
        {
            InitializeComponent();
            colorPalette = new Bitmap( 512, 512 );

            Color[] cols =   ColorGamut.GetLinearInterpolatedColors( 256, 0.6, 0.3, 0.3, 0.6 );
            UpdateGamutColorPallete( cols );
            //UpdateGradientColorPallete( btnStartColor.BackColor, btnEndColor.BackColor );
            //pcbPallete.Image = colorPalette;
          //  XYZ, L* a*b *, YUV
        }

        private void UpdateGamutColorPallete( Color[ ] cols )
        {
            double w = colorPalette.Width / 16.0;
            double h = colorPalette.Height / 16.0;
            Graphics g = Graphics.FromImage( colorPalette );
            RectangleF rect = new RectangleF( 0, 0, (float) w, (float) h );

            int cnt = 0;
            SolidBrush b = new SolidBrush( Color.Red );
            for( int r = 0 ; r < 16 ; r++ )
            {
                rect.Y = (float) ( r * h );
                for( int c = 0 ; c < 16 ; c++ )
                {
                    rect.X = (float) ( c * w );
                    b.Color = cols[ cnt ];
                    g.FillRectangle( b, rect );
                    g.DrawRectangle( Pens.DarkGray, Rectangle.Round( rect ) );
                    cnt++;
                }
            }
            pcbPallete.Image = colorPalette;
        }

        void UpdateGradientColorPallete( Color Start, Color End )
        {
            double w = colorPalette.Width / 16.0;
            double h = colorPalette.Height / 16.0;
            Graphics g = Graphics.FromImage( colorPalette );

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
            pcbPallete.Image = colorPalette;

        }

        private void EditColorWatch(object sender, EventArgs e)
        {
            if( dlgColor.ShowDialog( ) != DialogResult.OK ) return;
            Button btn = sender as Button;
            btn.BackColor = dlgColor.Color;
          UpdateGradientColorPallete( btnStartColor.BackColor, btnEndColor.BackColor );
        }

        PointF[ ] corners = { new PointF(0, 0), new PointF(255, 0), new PointF(0, 255), new PointF(255, 255) };
        double[] dis = new double[4];


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
        }

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
    }
}
