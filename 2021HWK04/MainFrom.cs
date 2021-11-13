
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

        MonoImage ReadInOriginalImage()
        {
            dlgOpen.FileName = "*.*";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return null;
            return new MonoImage(new Bitmap(dlgOpen.FileName));
        }

        private void btnGetImageForFFT_Click(object sender, EventArgs e)
        {
            labOne.Text = "Original Image";
            labTwo.Text = "Spectrum Image";
            labThree.Text = "Centered Spectrum";
            labFour.Text = "Log Transformed Spectrum";
            labFive.Text = "Phase Angle";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;
 
            MonoImage original = ReadInOriginalImage();
            if (original == null) return;

            MonoImage spectrum, phaseAngle, centeredSpectrum, LogTransformedSpectrum;
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

            MonoImage original = ReadInOriginalImage();
            if (original == null) return;
            Cursor = Cursors.WaitCursor;

            pcbOne.Image = original.displayedBitmap;
            pcbOne.Refresh();

            DateTime start = DateTime.Now;
            // Ideal Filter
            Filter Ifilter = new IdealLowPassFilter((double)nudRadiusIdeal.Value);
            MonoImage resultFromIdealFilter = MonoImage.FrequencyDomainFiltering(original, Ifilter, FCYangImageLibray.Padding.Zero);
            pcbThree.Image = resultFromIdealFilter.displayedBitmap;
            Console.Beep();
            labMessage.Text = $"Ideal Filtering Done: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            start = DateTime.Now;
            // Butterworth Filter
            Filter Bfilter = new ButterworthLowPassFilter((double)nudRadiusButterworth.Value, (int)nudOrderButterworth.Value);
            MonoImage resultFromButterworthFilter = MonoImage.FrequencyDomainFiltering(original, Bfilter, FCYangImageLibray.Padding.Zero);
            pcbThree.Image = resultFromButterworthFilter.displayedBitmap;
            Console.Beep();
            labMessage.Text += $"ButterWorth Filtering Done: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            start = DateTime.Now;
            // Gaussian Filter
            Filter Gfilter = new GaussianLowPassFilter((double)nudStdGaussian.Value);
            MonoImage resultFromGaussianFIlter = MonoImage.FrequencyDomainFiltering(original, Gfilter, FCYangImageLibray.Padding.Zero);
            pcbFour.Image = resultFromGaussianFIlter.displayedBitmap;
            Console.Beep();
            labMessage.Text += $"Gaussian Filtering Done: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            Cursor = Cursors.Default;

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
