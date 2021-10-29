using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021HWK03
{
    public partial class MainFromHWK3 : Form
    {
        Mask[ ] stockMasks;

        ColorImage originalImage;
        MonoImage averageGrayOriginal;
        MonoImage weightedGrayOriginal;

        ColorImage resultingImage;

        public MainFromHWK3()
        {
            InitializeComponent();

            // Create stocked masks
            stockMasks = new Mask[ 20 ];
            cbxFilters.Items.Clear( );
            double oneO9 = 1.0;
            stockMasks[0] = new Mask( new double[ 3, 3 ] { { oneO9, oneO9, oneO9 }, { oneO9, oneO9, oneO9 }, { oneO9, oneO9, oneO9 } }, "Custom" );
            cbxFilters.Items.Add( stockMasks[ 0 ] );
            stockMasks[ 1 ] = Mask.CreateBoxFilter( 3, 3 );
            cbxFilters.Items.Add( stockMasks[ 1 ] );
            stockMasks[ 2 ] = Mask.CreateBoxFilter(11,11) ;
            cbxFilters.Items.Add( stockMasks[ 2 ] );
            stockMasks[ 3 ] = Mask.CreateBoxFilter( 21, 21 );
            cbxFilters.Items.Add( stockMasks[ 3 ] );
            stockMasks[ 4 ] = Mask.CreateGaussianFilter( 3,3,1,1 );
            cbxFilters.Items.Add( stockMasks[ 4 ] );
            stockMasks[ 5 ] = Mask.CreateGaussianFilter( 11, 11, 1, 1 );
            cbxFilters.Items.Add( stockMasks[ 5 ] );
            stockMasks[ 6 ] = Mask.CreateGaussianFilter( 21, 21, 1, 1 );
            cbxFilters.Items.Add( stockMasks[ 6 ] );
            stockMasks[ 7 ] = Mask.CreateGaussianFilter( 21, 21, 1, 3.5 );
            cbxFilters.Items.Add( stockMasks[ 7 ] );
            stockMasks[ 8 ] = Mask.CreateGaussianFilter( 43, 43, 1, 7 );
            cbxFilters.Items.Add( stockMasks[ 8] );
            stockMasks[ 9] = Mask.CreateGaussianFilter( 85, 85, 1, 7 );
            cbxFilters.Items.Add( stockMasks[ 9 ] );
            stockMasks[ 10 ] = Mask.CreateBoxFilter( 71, 71 );
            cbxFilters.Items.Add( stockMasks[ 10 ] );
            stockMasks[ 11 ] = Mask.CreateGaussianFilter( 151, 151, 1, 25 );
            cbxFilters.Items.Add( stockMasks[ 11 ] );
            stockMasks[12] = Mask.CreateLaplacianOfGaussian(25, 25, 4);
            cbxFilters.Items.Add(stockMasks[12]);
            stockMasks[13] = new Mask(new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } }, "Sobel Horizontal");
            // Sobel is a special filter without normalization; therefore, set its total value to 1;
            stockMasks[ 13].total = 1.0;
            cbxFilters.Items.Add(stockMasks[13]);
            stockMasks[14] = new Mask(new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }, "Sobel Vertical");
            stockMasks[ 14 ].total = 1.0;
            cbxFilters.Items.Add(stockMasks[14]);

            stockMasks[ 15 ] = new Mask( new double[ , ] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } }, "Sobel -Horizontal" );
            // Sobel is a special filter without normalization; therefore, set its total value to 1;
            stockMasks[ 15 ].total = 1.0;
            cbxFilters.Items.Add( stockMasks[ 15 ] );
            stockMasks[ 16 ] = new Mask( new double[ , ] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } }, "Sobel -Vertical" );
            stockMasks[ 16 ].total = 1.0;
            cbxFilters.Items.Add( stockMasks[ 16 ] );

            stockMasks[17] = new Mask(new double[,] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } }, "Laplacian (full)");
            stockMasks[17].total = 1.0;
            cbxFilters.Items.Add(stockMasks[17]);

            stockMasks[18] = new Mask(new double[,] { { 1, 0, 1 }, { 0, -4, 0 }, { 1, 0, 1 } }, "Laplacian (half)");
            stockMasks[18].total = 1.0;
            cbxFilters.Items.Add(stockMasks[18]);

            stockMasks[19] = new Mask(new double[,] { { 0, 0, -1, 0, 0 }, { 0, -1, -2, -1, 0 }, { -1, -2, 16, -2, -1 }, { 0, -1, -2, -1, 0 }, { 0, 0, -1, 0, 0 } }, "LoG(5)");
            stockMasks[19].total = 1.0;
            cbxFilters.Items.Add(stockMasks[19]);

            cbxFilters.SelectedIndex = 0;
        }

        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog( );
            if( dlg.ShowDialog( ) != DialogResult.OK ) return;
            originalImage = new ColorImage( new Bitmap( dlg.FileName ) );
            pcbOriginal.Image = originalImage.displayedBitmap;

            // store gray images
            averageGrayOriginal = new MonoImage( originalImage.displayedBitmap );
            weightedGrayOriginal = new MonoImage( originalImage.displayedBitmap, true );
        }

        private void cbxFilters_SelectedIndexChanged( object sender, EventArgs e )
        {
            ResetCustomFilterEditor( cbxFilters.SelectedItem as Mask );
        }

        private void ResetCustomFilterEditor( Mask msk )
        {
            nudRows.Value = msk.height;
            nudCols.Value = msk.width;
            dgvMask.Rows.Clear( );
            dgvMask.Columns.Clear( );
            for( int c = 0 , s=- msk.width / 2; c < msk.width ; c++,s++ )
                dgvMask.Columns.Add( $"col{c}", (c+1).ToString( ) );
            foreach( DataGridViewColumn dgvc in dgvMask.Columns )
                dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for( int r = 0 , s= -msk.height / 2; r < msk.height ;r++,s++ )
            {
                dgvMask.Rows.Add( );
                dgvMask.Rows[ r ].HeaderCell.Value = r+1;
                for( int c = 0 ; c < msk.width ; c++ )
                    dgvMask.Rows[ r ].Cells[ c ].Value = msk.weights[ r, c ];
            }
        }

        private void nudRows_ValueChanged( object sender, EventArgs e )
        {
            int newRow = (int)nudRows.Value;
            if(  dgvMask.RowCount > newRow )
            {
                int r = dgvMask.RowCount - 1;
                do dgvMask.Rows.RemoveAt( r-- );
                while( r >= newRow );
            }
            else
            {
                for( int r = dgvMask.RowCount ; r < newRow ; r++ )
                {
                    dgvMask.Rows.Add( );
                    dgvMask.Rows[ r ].HeaderCell.Value = r + 1;
                    for( int c = 0 ; c < dgvMask.ColumnCount ; c++ )
                        dgvMask.Rows[ r ].Cells[ c ].Value = 1;
                }
            }

        }

        private void nudCols_ValueChanged( object sender, EventArgs e )
        {
           
                int newCols = (int) nudCols.Value;
                if( dgvMask.ColumnCount > newCols )
                {
                    int c = dgvMask.ColumnCount - 1;
                    do dgvMask.Columns.RemoveAt( c-- );
                    while( c >= newCols );
                }
                else
                {
                    for( int cc = dgvMask.ColumnCount ; cc < newCols ; cc++ )
                    {
                        dgvMask.Columns.Add( $"col{cc}", (cc+1).ToString() );
                        for( int r = 0 ; r < dgvMask.RowCount ; r++ )
                            dgvMask.Rows[ r ].Cells[ cc ].Value = 1;
                    }
                }


                foreach( DataGridViewColumn dgvc in dgvMask.Columns )
                dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        DateTime startTime;
        private void btnApply_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;

            startTime = DateTime.Now;

            if( rdbColor.Checked )
            {
                if( ckbTurbo.Checked ) resultingImage = ( cbxFilters.SelectedItem as Mask ) * originalImage;
                else resultingImage = ( cbxFilters.SelectedItem as Mask ) + originalImage;
                 pcbResults.Image = resultingImage.displayedBitmap;
            }
            else
            {
                MonoImage output;
                if( rdbAverageGray.Checked )
                    if( ckbTurbo.Checked ) output = ( cbxFilters.SelectedItem as Mask ) * averageGrayOriginal;
                    else output = ( cbxFilters.SelectedItem as Mask ) + averageGrayOriginal;
                else
                                    if( ckbTurbo.Checked ) output = ( cbxFilters.SelectedItem as Mask ) * weightedGrayOriginal;
                else output = ( cbxFilters.SelectedItem as Mask ) + weightedGrayOriginal;

                pcbResults.Image = output.displayedBitmap;
            }

            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep( );
        }

        private void btnSobel_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;

            startTime = DateTime.Now;
 
            MonoImage output1 = ( stockMasks[ 13 ] + averageGrayOriginal ) + ( stockMasks[ 14 ] + averageGrayOriginal );
            MonoImage output2 = ( stockMasks[ 15 ] + averageGrayOriginal ) + ( stockMasks[ 16 ] + averageGrayOriginal );
            pcbResults.Image = (output1+output2).displayedBitmap;

            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep( );

        }

        private void label5_Click( object sender, EventArgs e )
        {

        }

        private void btnMarr_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;

            startTime = DateTime.Now;

            // Gaussian
            int h = (int)nudMarrHeight.Value;
            int w = (int) nudMarrWidth.Value;
            double std = double.Parse( txbSTD.Text );
            Mask msk =  Mask.CreateLaplacianOfGaussian( h, w, std );
            MonoImage output = msk * averageGrayOriginal;
            pcbResults.Image = output.displayedBitmap;


            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep( );

        }

        private void btnLaplacian_Click(object sender, EventArgs e)
        {
            double[,] laplacian =  new double[,] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } } ;
            
            double[,] values = laplacian + averageGrayOriginal;

            int[,] pixels = new int[averageGrayOriginal.height, averageGrayOriginal.width];

            //for (int r = 0; r < averageGrayOriginal.height; r++)
            //    for (int c = 0; c < averageGrayOriginal.width; c++)
            //    {
            //        pixels[r, c] = (int)( averageGrayOriginal.pixels[r,c] - values[r, c]  );
            //        if (pixels[r, c] > 255) pixels[r, c] = 255;
            //        else if (pixels[r, c] < 0) pixels[r, c] = 0;
            //    }
            double max = double.MinValue, min = double.MaxValue;
            for (int r = 0; r < averageGrayOriginal.height; r++)
                for (int c = 0; c < averageGrayOriginal.width; c++)
                {
                    if (values[r, c] > max) max = values[r, c];
                    else if (values[r, c] < min) min = values[r, c];
                }
            if (rdbABsolute.Checked)
            {
                for(int r = 0; r < averageGrayOriginal.height; r++)
                    for( int c = 0; c < averageGrayOriginal.width; c++)
                    {
                        if (values[r, c] > 0)
                            pixels[r, c] = 128 + (int)(128 * values[r, c] / max);
                        else
                            pixels[r, c] = 127 + (int)(127 * (1- values[r, c] / min));
                    }
            }
            else if(rdbMiddleMap.Checked)
            {
                for (int r = 0; r < averageGrayOriginal.height; r++)
                    for (int c = 0; c < averageGrayOriginal.width; c++)
                    {
                            pixels[r, c] = (int)(255 * (values[r, c]-min) / (max-min) );
                    }
            }
            else
            {
                for (int r = 0; r < averageGrayOriginal.height; r++)
                    for (int c = 0; c < averageGrayOriginal.width; c++)
                    {
                        if( values[r,c] > 0 )
                            pixels[r, c] = (int)( 255 * values[r, c] / max );
                        else 
                            pixels[r, c] =  0;
                    }
            }
            for (int r = 0; r < averageGrayOriginal.height; r++)
                for (int c = 0; c < averageGrayOriginal.width; c++)
                {
                    if (pixels[r, c] > 255) pixels[r, c] = 255;
                    else if (pixels[r, c] < 0) pixels[r, c] = 0;
                }
            MonoImage output = new MonoImage(pixels);
            pcbResults.Image = output.displayedBitmap;

        }

        private void btnLineFinder_Click(object sender, EventArgs e)
        {
            double[,] weights;
            if( rdbHorizontal.Checked)
                weights = new double[,] { { -1, -1, -1 }, { 2, 2, 2 }, { -1, -1, -1 } };
            else if( rdb45Deg.Checked)
                weights = new double[,] { { -1, -1, 2 }, { -1, 2, -1 }, {2, -1, -1 } };
            else if (rdbVertical.Checked)
                weights = new double[,] { { -1, 2, -1 }, { -1, 2, -1 }, { -1, 2, -1 } };
            else  
                weights = new double[,] { { 2, -1, -1 }, { -1, 2, -1 }, { -1, -1, 2 } };
            Mask msk = new Mask(weights);
            msk.total = 1.0;

            MonoImage output = msk * averageGrayOriginal;
            pcbResults.Image = output.displayedBitmap;

        }

        private void nudMarrHeight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudMarrWidth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomGaussianBox_Click(object sender, EventArgs e)
        {
            int h = (int)nudRows.Value;
            int w = (int)nudCols.Value;

            Mask msk = null;
            if (sender == btnCustomBox)
                msk = Mask.CreateBoxFilter(h, w);
            else if (sender == btnCustomGaussian)
            {
                double std = double.Parse(txbStandardDE.Text);
                msk = Mask.CreateGaussianFilter(h, w, 1, std);
            }

            startTime = DateTime.Now;
            Cursor = Cursors.WaitCursor;

            if( ckbTurbo.Checked)
            {
                if (rdbColor.Checked)
                    pcbResults.Image = (msk * originalImage).displayedBitmap;
                else if( rdbAverageGray.Checked)
                    pcbResults.Image = (msk * averageGrayOriginal).displayedBitmap;
                else
                    pcbResults.Image = (msk * weightedGrayOriginal).displayedBitmap;
            }
            else
            {
                if (rdbColor.Checked)
                    pcbResults.Image = (msk + originalImage).displayedBitmap;
                else if (rdbAverageGray.Checked)
                    pcbResults.Image = (msk + averageGrayOriginal).displayedBitmap;
                else
                    pcbResults.Image = (msk + weightedGrayOriginal).displayedBitmap;

            }
            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep();
        }

        private void btnCustomLaplacian_Click(object sender, EventArgs e)
        {
            Mask msk = null;
            if (rdbDiagonal.Checked )
                msk =  new Mask(new double[,] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } }, "Laplacian (full)");
            else
                msk = new Mask(new double[,] { { 1, 0, 1 }, { 0, -4, 0 }, { 1, 0, 1 } }, "Laplacian (half)");
            msk.total = 1.0;
       
            startTime = DateTime.Now;
            Cursor = Cursors.WaitCursor;

            if (ckbTurbo.Checked)
            {

                if (rdbColor.Checked)
                    pcbResults.Image = (originalImage - (msk * originalImage)).displayedBitmap;
                else if (rdbAverageGray.Checked)
                    pcbResults.Image = (averageGrayOriginal - (msk * averageGrayOriginal)).displayedBitmap;
                else
                    pcbResults.Image = (weightedGrayOriginal - (msk * weightedGrayOriginal)).displayedBitmap;
            }
            else
            {
                if (rdbColor.Checked)
                    pcbResults.Image = (originalImage - (msk + originalImage)).displayedBitmap;
                else if (rdbAverageGray.Checked)
                    pcbResults.Image = (averageGrayOriginal - (msk * averageGrayOriginal)).displayedBitmap;
                else
                    pcbResults.Image = (weightedGrayOriginal - (msk * weightedGrayOriginal)).displayedBitmap;
            }

            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep();
        }
    }
}
