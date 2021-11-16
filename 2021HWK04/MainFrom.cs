
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
            cbxPad.DataSource = Enum.GetValues(typeof(FCYangImageLibray.ImagePadding));
            cbxPad.SelectedIndex = 0;
            initializeHomomorphicParameters();
        }

        void  initializeHomomorphicParameters()
        {
            dgvParameters.Rows.Add(1.0, 1.0, 50);
            dgvParameters.Rows.Add(1.5, 0.8, 40);
            dgvParameters.Rows.Add(2.3, 0.6, 30);
            dgvParameters.Rows.Add(3.0, 0.4, 20);
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
            labMessage.Text = "";
            Cursor = Cursors.WaitCursor;

            pcbOne.Image = original.displayedBitmap;
            pcbOne.Refresh();
            FCYangImageLibray.ImagePadding pad = (FCYangImageLibray.ImagePadding)cbxPad.SelectedItem;

            DateTime start = DateTime.Now;

            FourierTransformFilter[] filters = new FourierTransformFilter[3];
            // Ideal Filter
            filters[0] = new IdealLowPassFilter((double)nudRadiusIdeal.Value);
            // Butterworth Filter
            filters[1] = new ButterworthLowPassFilter((double)nudRadiusButterworth.Value, (int)nudOrderButterworth.Value);
            // Gaussian Filter
            filters[2] = new GaussianLowPassFilter((double)nudStdGaussian.Value);

            //Ifilter = new IdentityFilter(); // ******** Debug
            MonoImage[] results = MonoImage.FrequencyDomainFiltering(original, filters, pad);

            pcbTwo.Image = results[0].displayedBitmap;
            pcbThree.Image = results[1].displayedBitmap;
            pcbFour.Image = results[2].displayedBitmap;
            Console.Beep();
            labMessage.Text = $"Time Spent: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            Cursor = Cursors.Default;

        }


        private void oribtnIdealButterworthAndGaussianFiltering_Click(object sender, EventArgs e)
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
            labMessage.Text = "";
            Cursor = Cursors.WaitCursor;

            pcbOne.Image = original.displayedBitmap;
            pcbOne.Refresh();
            FCYangImageLibray.ImagePadding pad = (FCYangImageLibray.ImagePadding)cbxPad.SelectedItem;

            DateTime start = DateTime.Now;
            // Ideal Filter
            FourierTransformFilter Ifilter = new IdealLowPassFilter((double)nudRadiusIdeal.Value);
            //Ifilter = new IdentityFilter(); // ******** Debug
            MonoImage resultFromIdealFilter = MonoImage.FrequencyDomainFiltering(original, Ifilter, pad);
            pcbTwo.Image = resultFromIdealFilter.displayedBitmap;
            pcbTwo.Refresh();
            Console.Beep();
            labMessage.Text = $"Ideal Filtering Done: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            start = DateTime.Now;
            // Butterworth Filter
            FourierTransformFilter Bfilter = new ButterworthLowPassFilter((double)nudRadiusButterworth.Value, (int)nudOrderButterworth.Value);
            MonoImage resultFromButterworthFilter = MonoImage.FrequencyDomainFiltering(original, Bfilter, pad);
            pcbThree.Image = resultFromButterworthFilter.displayedBitmap;
            pcbThree.Refresh();
            Console.Beep();
            labMessage.Text += $"ButterWorth Filtering Done: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            start = DateTime.Now;
            // Gaussian Filter
            FourierTransformFilter Gfilter = new GaussianLowPassFilter((double)nudStdGaussian.Value);
            MonoImage resultFromGaussianFIlter = MonoImage.FrequencyDomainFiltering(original, Gfilter, pad);
            pcbFour.Image = resultFromGaussianFIlter.displayedBitmap;
            pcbFour.Refresh();
            Console.Beep();
            labMessage.Text += $"Gaussian Filtering Done: {DateTime.Now - start}   ";
            statusStrip1.Refresh();

            Cursor = Cursors.Default;

        }

        bool AddNoise = false;

        private void btnBlurAndRecover_Click(object sender, EventArgs e)
        {
            labMessage.Text = "";
            Cursor = Cursors.WaitCursor;
            labOne.Text = "Original Image";
            labTwo.Text = "Motion Blurred Image";
            labThree.Text = "Inverse Filter Recovered";
            labFour.Text = "Wiener Filter Recovered";
            labFive.Text = "";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;
            tlpMain.Refresh();

            MonoImage original = ReadInOriginalImage();
            if (original == null) return;


            pcbOne.Image = original.displayedBitmap;
            pcbOne.Refresh();

            DateTime start = DateTime.Now;

            MotionBlurFilter filter = new MotionBlurFilter((double)nudBlurA.Value, (double)nudBlurB.Value, (double)nudBlurT.Value);
            //filter = new ZeroCenterLowPassFilter();
            //filter = new IdealLowPassFilter(90);
            MonoImage motionBlurred = MonoImage.FrequencyDomainFiltering(original, filter);

            if( AddNoise )
            {
                labTwo.Text = "Motion Blurred + Noise Image";
                GaussianNoiseFunction gauss = new GaussianNoiseFunction( 0.0, (double) nudGaussianSTD.Value );
                for( int r = 0 ; r < motionBlurred.height ; r++ )
                    for( int c = 0 ; c < motionBlurred.width ; c++ )
                    {
                        motionBlurred.pixels[ r, c ]  = (int)( motionBlurred.pixels[ r, c ] + gauss.GetValue( ));
                        if( motionBlurred.pixels[ r, c ] < 0 ) motionBlurred.pixels[ r, c ] = 0;
                        else if( motionBlurred.pixels[ r, c ] > 255 ) motionBlurred.pixels[ r, c ] = 255;
                    }
                motionBlurred = new MonoImage( motionBlurred.pixels );
            }

            pcbTwo.Image = motionBlurred.displayedBitmap;
            pcbTwo.Refresh();

            Console.Beep();
            labMessage.Text = $"Blur Completed! Time: {DateTime.Now - start } ";
            statusStrip1.Refresh();

            start = DateTime.Now;

            // (1) Direct Inverse Restoration (must set threshold; or all black)
            filter.Inverse = true;
            filter.WienerInverted = false;
            filter.InverseThreshold = (double) nudInverseThreshold.Value;
            MonoImage InverseRestored = MonoImage.FrequencyDomainFiltering( motionBlurred, filter);

            pcbThree.Image = InverseRestored.displayedBitmap;
            pcbThree.Refresh( );
            labThree.Text += $" Avg Diff={ MonoImage.IntensityAbsoluteDifferenceAverage( original, InverseRestored ):0.00}";
            Console.Beep( );
            labMessage.Text += $"  Direct Inverse Restored! Time: {DateTime.Now - start } ";
            statusStrip1.Refresh( );

            start = DateTime.Now;
            // (2) Wiener Inverse Restoration )
            filter.Inverse = true;
            filter.WienerInverted = true;
            filter.WienerConstant = (double) nudWienerConstant.Value;
            MonoImage WienerRestored = MonoImage.FrequencyDomainFiltering( motionBlurred, filter );

            pcbFour.Image = WienerRestored.displayedBitmap;
            pcbFour.Refresh( );
            labFour.Text += $" Avg Diff={ MonoImage.IntensityAbsoluteDifferenceAverage( original, WienerRestored ):0.00}";
            Console.Beep();
            labMessage.Text += $"  Wiener Restored! Time: {DateTime.Now - start } ";

           Cursor =  Cursors.Default;
 

        }
            // Exact Inverse Filter

        private void btnAddNoiseAndRecover_Click(object sender, EventArgs e)
        {
            AddNoise = true;
            btnBlurAndRecover_Click( null, null );
            AddNoise = false;
 
        }


        private void btnHomorphicFiltering_Click(object sender, EventArgs e)
        {
            labOne.Text = "Original Image";
            labTwo.Text = "Homomorphic Filtering";
            labThree.Text = "";
            labFour.Text = "";
            labFive.Text = "";
            pcbOne.Image = pcbTwo.Image = pcbThree.Image = pcbFour.Image = pcbFive.Image = null;
            tlpMain.Refresh();

            MonoImage original = ReadInOriginalImage();
            if (original == null) return;

            Cursor = Cursors.WaitCursor;
            labMessage.Text = "";
            pcbOne.Image = original.displayedBitmap;
            pcbOne.Refresh();

            DateTime start = DateTime.Now;

            Label[] labels = { labTwo, labThree, labFour, labFive };
            double power = (double)nudHomomorphicOrder.Value;
            double high, low, radius;
            FourierTransformFilter[] homomorphicFilters = new FourierTransformFilter[dgvParameters.RowCount];
            for( int r = 0; r < dgvParameters.RowCount; r++)
            {
                high = (double)dgvParameters.Rows[r].Cells[0].Value;
                low = (double)dgvParameters.Rows[r].Cells[1].Value;
                radius = double.Parse(dgvParameters.Rows[r].Cells[2].Value.ToString());
                homomorphicFilters[r] = new HomomorphicFilter(power, high, low, radius);
                labels[r].Text = $"{ homomorphicFilters[r].ToString()} Transformed";
                labels[r].Refresh();
            }
            MonoImage[] imgs = MonoImage.FrequencyDomainFiltering(original, homomorphicFilters, ImagePadding.None);
            pcbTwo.Image = imgs[0].displayedBitmap;
            pcbThree.Image = imgs[1].displayedBitmap;
            pcbFour.Image = imgs[2].displayedBitmap;
            pcbFive.Image = imgs[3].displayedBitmap;

            Console.Beep();
            labMessage.Text = $"Time Spent: {DateTime.Now - start}";
            Cursor = Cursors.Default;
        }


    }
}
