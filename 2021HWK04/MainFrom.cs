
using FCYangImageLibray;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace _2021HWK04
{
    public partial class MainFrom : Form
    {
        public MainFrom( )
        {
            InitializeComponent( );
        }

        private void btnGetImageForFFT_Click(object sender, EventArgs e)
        {
            labOne.Text = "Original Image";
            labTwo.Text = "Spectrum Image";
            labThree.Text = "Phase Angle Image";
            labFour.Text = "Forward and Inverse DFTed";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = null;

            dlgOpen.FileName = "*.*";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            MonoImage spectrum, phaseAngle;
            Bitmap bmp = new Bitmap(dlgOpen.FileName);
            MonoImage original = new MonoImage(bmp);
            pcbOne.Image = original.displayedBitmap;

            tlpMain.Refresh( );
            DateTime startTime = DateTime.Now;
            Cursor = Cursors.WaitCursor;
            spectrum = original.ExtractSpecturmAndPhaseAngleImages(out phaseAngle, ckbLogMap.Checked);
             
            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep( );
            pcbTwo.Image = spectrum.displayedBitmap;
            pcbThree.Image = phaseAngle.displayedBitmap;
             
        }

        private void btnIdealButterworthAndGaussianFiltering_Click(object sender, EventArgs e)
        {
            labOne.Text = "Original Image";
            labTwo.Text = "Ideal Filtering Result";
            labThree.Text = "Butterworth Filtering Result";
            labFour.Text = "Gaussian Filtering Result";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = null;
            tlpMain.Refresh();
        }

        private void btnBlurAndRecover_Click(object sender, EventArgs e)
        {
            labOne.Text = "Inverse Filter Recovered";
            labTwo.Text = "Wiener Filter Recovered";
            labThree.Text = "Inverse Image Difference";
            labFour.Text = "Wiener Image Difference";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = null;
            tlpMain.Refresh();
        }

        private void btnAddNoiseAndRecover_Click(object sender, EventArgs e)
        {

        }

        int counter = 1;
        private void btnHomorphicFiltering_Click(object sender, EventArgs e)
        {
            labOne.Text = "Original Image";
            labTwo.Text = "Homomorphic Filtering";
            labThree.Text = "";
            labFour.Text = "";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = null;
            tlpMain.Refresh();

        }
    }
}
