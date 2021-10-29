using System;

namespace _2021HWK03
{
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
                    w[r, c] =- ( (distanceSquare /std / std - 2 ) / std / std ) * Math.Exp(-0.5 * distanceSquare / std / std);
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
