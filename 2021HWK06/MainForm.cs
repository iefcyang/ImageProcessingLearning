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

namespace _2021HWK06
{
    public partial class MainForm : Form
    {
        public MainForm( )
        {
            InitializeComponent( );
        }

        private void EditColorSwatch( object sender, EventArgs e )
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

        private void btnGetRGBPlanes_Click( object sender, EventArgs e )
        {
            ColorImage circularImage =  originalImage.EllipseTransform( );
            labTwo.Text = "Elliptic Transform";
            pcbTwo.Image = circularImage.displayedBitmap;

            ColorImage trapizoidalImage = originalImage.TrapezoidalTransform( (double)nudVerticalScale.Value, (double)nudHorizontalScale.Value );
            labThree.Text = "Trapezoidal Transform";
            pcbThree.Image = trapizoidalImage.displayedBitmap;
        }

        private void label6_Click( object sender, EventArgs e )
        {

        }
    }
}
