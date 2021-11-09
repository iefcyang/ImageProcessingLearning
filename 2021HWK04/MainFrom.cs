
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
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            Bitmap bmp = new Bitmap(dlgOpen.FileName);
            pcbOriginal.Image = bmp;
            MonoImage original = new MonoImage(bmp);
            Complex[,] map =  Fourier.DiscreteFourierTransform(original);
            MonoImage spectrum, phaseAngle;
            spectrum = MonoImage.ExtractSpecturmAndPhaseAngleImages(map, out phaseAngle, true);
            pcbSpectrum.Image = spectrum.displayedBitmap;
            pcbPhaseAngle.Image = phaseAngle.displayedBitmap;
             
        }
    }
}
