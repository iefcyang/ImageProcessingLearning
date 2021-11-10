
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
            dlgOpen.FileName = "*.*";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            MonoImage spectrum, phaseAngle;
            Bitmap bmp = new Bitmap(dlgOpen.FileName);
            MonoImage original = new MonoImage(bmp);
            pcbOriginal.Image = original.displayedBitmap;
            pcbSpectrum.Image = pcbPhaseAngle.Image = pcbForwardInversed.Image =  null;
            //pcbOriginal.Refresh( );
            tlpMain.Refresh( );
            DateTime startTime = DateTime.Now;
            Cursor = Cursors.WaitCursor;
            spectrum = original.ExtractSpecturmAndPhaseAngleImages(out phaseAngle, ckbLogMap.Checked);

            // 
            
             
            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep( );
            pcbSpectrum.Image = spectrum.displayedBitmap;
            pcbPhaseAngle.Image = phaseAngle.displayedBitmap;
             
        }
    }
}
