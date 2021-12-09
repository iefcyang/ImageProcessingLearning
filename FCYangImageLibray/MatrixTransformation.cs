using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCYangImageLibray
{
    public class MatrixTransformation
    {
        double[ , ] temp2;
        double[ ,, ] temp3;

        public double[,] ForwardTransform(  double[,] matrix, double[,] target )
        {
            double[ , ] results;
            int rowCount = target.GetLength( 0 );
            int colCount = target.GetLength( 1 );
            if( rowCount != colCount ) throw new Exception( "Target matrix must be square." );
            if( matrix.GetLength( 0 ) != rowCount || matrix.GetLength( 1 ) != colCount ) throw new Exception( "Transformation matrix target does not match the target data!" );
            if( temp2 == null || temp2.GetLength(0) != rowCount || temp2.GetLength(1) != colCount )
                temp2 = new double[ rowCount, colCount ];
            results = new double[ rowCount, colCount ];
            // matrix * source * matrixT
            for( int r = 0 ; r < rowCount ; r++  )
                for( int c = 0 ; c < colCount ; c++ )
                {
                    temp2[ r, c ] = 0.0;
                    for( int k = 0 ; k < rowCount ; k++ )
                        temp2[ r, c ] += matrix[ r, k ] * target[ k, c ];
                }
            for( int r = 0 ; r < rowCount ; r++ )
                for( int c = 0 ; c < colCount ; c++ )
                {
                    results[ r, c ] = 0.0;
                    for( int k = 0 ; k < rowCount ; k++ )
                        results[ r, c ] += temp2[ r, k ] * matrix[ c, k ];
                }
            return results;
        }

        public double[ , ] ForwardTransform( int[ , ] matrix, int[ , ] target )
        {
            double[ , ] results;
            int rowCount = target.GetLength( 0 );
            int colCount = target.GetLength( 1 );
            if( rowCount != colCount ) throw new Exception( "Target matrix must be square." );
            if( matrix.GetLength( 0 ) != rowCount || matrix.GetLength( 1 ) != colCount ) throw new Exception( "Transformation matrix target does not match the target data!" );
            if( temp2 == null || temp2.GetLength( 0 ) != rowCount || temp2.GetLength( 1 ) != colCount )
                temp2 = new double[ rowCount, colCount ];
            results = new double[ rowCount, colCount ];
            // matrix * source * matrixT
            for( int r = 0 ; r < rowCount ; r++ )
                for( int c = 0 ; c < colCount ; c++ )
                {
                    temp2[ r, c ] = 0.0;
                    for( int k = 0 ; k < rowCount ; k++ )
                        temp2[ r, c ] += matrix[ r, k ] * target[ k, c ];
                }
            for( int r = 0 ; r < rowCount ; r++ )
                for( int c = 0 ; c < colCount ; c++ )
                {
                    results[ r, c ] = 0.0;
                    for( int k = 0 ; k < rowCount ; k++ )
                        results[ r, c ] += temp2[ r, k ] * matrix[ c, k ];
                }
            return results;
        }

        public double[ ,, ] ForwardTransform( int[ , ] matrix, int[ ,, ] target )
        {
            double[ ,, ] results;
            int channelCount = target.GetLength( 0 );
            int rowCount = target.GetLength( 1 );
            int colCount = target.GetLength( 2 );
            if( rowCount != colCount ) throw new Exception( "Target matrix must be square." );
            if( matrix.GetLength( 0 ) != rowCount || matrix.GetLength( 1 ) != colCount ) throw new Exception( "Transformation matrix target does not match the target data!" );
            if( temp3 == null || temp3.GetLength( 1 ) != rowCount || temp3.GetLength( 2 ) != colCount )
                temp3 = new double[channelCount,  rowCount, colCount ];
            results = new double[ channelCount, rowCount, colCount ];
            // matrix * source * matrixT
            for( int d = 0 ; d < 3 ; d++ )
            {
                for( int r = 0 ; r < rowCount ; r++ )
                    for( int c = 0 ; c < colCount ; c++ )
                    {
                        temp3[ d, r,  c ] = 0.0;
                        for( int k = 0 ; k < rowCount ; k++ )
                            temp3[d, r, c ] += matrix[ r, k ] * target[ d, k, c ];
                    }
                for( int r = 0 ; r < rowCount ; r++ )
                    for( int c = 0 ; c < colCount ; c++ )
                    {
                        results[ d, r, c ] = 0.0;
                        for( int k = 0 ; k < rowCount ; k++ )
                            results[ d, r, c ] += temp3[d, r, k ] * matrix[ c, k ];
                    }
            }
            return results;
        }





    }
}
