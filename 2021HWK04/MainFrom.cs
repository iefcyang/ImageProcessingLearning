
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
            labThree.Text = "Centered Spectrum";
            labFour.Text = "Log Transformed Spectrum";
            labFive.Text = "Phase Angle";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;

            dlgOpen.FileName = "*.*";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            MonoImage spectrum, phaseAngle, centeredSpectrum, LogTransformedSpectrum;
            Bitmap bmp = new Bitmap(dlgOpen.FileName);
            MonoImage original = new MonoImage(bmp);
            pcbOne.Image = original.displayedBitmap;

            tlpMain.Refresh( );
            labMessage.Text = "";
            statusStrip1.Refresh( );

            DateTime startTime = DateTime.Now;
            Cursor = Cursors.WaitCursor;
            spectrum = MonoImage.ExtractSpecturmAndPhaseAngleImages(original, out phaseAngle, out centeredSpectrum, out LogTransformedSpectrum );
             
            Cursor = Cursors.Default;
            rtbOutput.Text = MonoImage.TextMessage.ToString( );

            Console.Beep( );
            pcbTwo.Image = spectrum.displayedBitmap;
            pcbThree.Image = centeredSpectrum.displayedBitmap;
            pcbFour.Image = LogTransformedSpectrum.displayedBitmap;
            pcbFive.Image = phaseAngle.displayedBitmap;
             
        }

        private void btnIdealButterworthAndGaussianFiltering_Click(object sender, EventArgs e)
        {
            labOne.Text = "Original Image";
            labTwo.Text = "Ideal Filtering Result";
            labThree.Text = "Butterworth Filtering Result";
            labFour.Text = "Gaussian Filtering Result";
            labFive.Text = "";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;
            tlpMain.Refresh();
        }

        private void btnBlurAndRecover_Click(object sender, EventArgs e)
        {
            labOne.Text = "Inverse Filter Recovered";
            labTwo.Text = "Wiener Filter Recovered";
            labThree.Text = "Inverse Image Difference";
            labFour.Text = "Wiener Image Difference";
            labFive.Text = "";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;
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
            labFive.Text = "";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;
            tlpMain.Refresh();

        }
    }
}
