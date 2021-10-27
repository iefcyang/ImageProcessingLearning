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
        ColorImage resultingImage;

        public MainFromHWK3()
        {
            InitializeComponent();

            // Create stocked masks
            stockMasks = new Mask[ 15 ];
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
            cbxFilters.Items.Add(stockMasks[13]);
            stockMasks[14] = new Mask(new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }, "Sobel Vertical");
            cbxFilters.Items.Add(stockMasks[14]);

            cbxFilters.SelectedIndex = 0;
        }

        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog( );
            if( dlg.ShowDialog( ) != DialogResult.OK ) return;
            originalImage = new ColorImage( new Bitmap( dlg.FileName ) );
            pcbOriginal.Image = originalImage.displayedBitmap;
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
            if( ckbTurbo.Checked) resultingImage = ( cbxFilters.SelectedItem as Mask ) * originalImage;
            else resultingImage = ( cbxFilters.SelectedItem as Mask ) + originalImage;
            pcbResults.Image = resultingImage.displayedBitmap;
            Cursor = Cursors.Default;
            labMessage.Text = $"Time Spent: {DateTime.Now - startTime}";
            Console.Beep( );
        }
    }

    //public class ColorImage
    //{
    //    public Bitmap theBitmap;
    //    public int[ , , ] pixels;
    //    public ColorImage( Bitmap bmp )
    //    {

    //    }
    //}
    public class Mask
    {
        public static Mask CreateLaplacianOfGaussian( int height, int width, double std)
        {
            double[,] w = new double[height, width];
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                {
                    double deltaY = r - height / 2;
                    double deltaX = c - width / 2;
                    double distanceSquare = deltaY * deltaY + deltaX * deltaX;
                    w[r, c] = ( (distanceSquare /std / std - 2 ) / std / std ) * Math.Exp(-0.5 * distanceSquare / std / std);
                }
            return new Mask(w, $"LoG[{std}]({height}x{width})");

        }
        public static Mask CreateGaussianFilter( int height, int width, double scale, double standardDeviation )
        {
            double[ , ] w = new double[ height, width ];
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                {
                    double dis = r - height / 2;
                    double h = c - width / 2;
                    w[ r, c ] = scale * Math.Exp(-0.5* (dis*dis+h*h)/standardDeviation/standardDeviation);
                }
            return new Mask( w, $"Gaussian[{scale},{standardDeviation}]({height}x{width})" );

        }


        public static Mask CreateBoxFilter( int height, int width )
        {
            double[ , ] w = new double[ height, width ];
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                    w[ r, c ] = 1;
            return new Mask( w , $"box({height}x{width})");

        }

        public static int counter = 1;
        public string name;
        public int height, width;
        public double[ , ] weights;
        public double total;

        public override string ToString( )
        {
            return name;
        }

        public Mask( double[ , ] weights, string title = null )
        {
            this.weights = weights;
            total = 0;
            foreach( double w in weights ) total += w;

            height = weights.GetLength( 0 );
            width = weights.GetLength( 1 );
            if( title == null ) name = $"Mask{counter++}";
            else name = title;
        }

        public Mask(  int height, int width, string title = null )
        {
            this.height = height;
            this.width = width;

            weights = new double[ height, width ];
            for( int r = 0 ; r < height ; r++ )
                for( int c = 0 ; c < width ; c++ )
                    weights[ r, c ] = 1;
            total = 9;
            if( title == null ) name = $"Mask{counter++}";
            else name = title;
        }


    }
}
