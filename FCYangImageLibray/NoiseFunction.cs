using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCYangImageLibray
{
    public class NoiseFunction
    {
        protected Random randomizer = new Random( );
        public virtual double GetValue( ) { return 0.0; }
    }

    public class GaussianNoiseFunction : NoiseFunction
    {
        protected static double p0 = 0.322232431088;
        protected static double q0 = 0.099348462606;
        protected static double p1 = 1.0;
        protected static double q1 = 0.588581570495;
        protected static double p2 = 0.342242088547;
        protected static double q2 = 0.531103462366;
        protected static double p3 = 0.204231210245e-1;
        protected static double q3 = 0.103537752850;
        protected static double p4 = 0.453642210148e-4;
        protected static double q4 = 0.385607006340e-2;

        double mean = 0, standardDeviation = 100;
        public GaussianNoiseFunction( double mean, double standardDeviation )
        {
            this.mean = mean;
            this.standardDeviation = standardDeviation;
        }

        protected double NormalFunction( double m, double s )
        {
            double u, t, p, q, z;
            u = randomizer.NextDouble( );
            if( u < 0.5 )
                t = Math.Sqrt( -2.0 * Math.Log( u ) );
            else
                t = Math.Sqrt( -2.0 * Math.Log( 1.0 - u ) );
            p = p0 + t * ( p1 + t * ( p2 + t * ( p3 + t * p4 ) ) );
            q = q0 + t * ( q1 + t * ( q2 + t * ( q3 + t * q4 ) ) );
            if( u < 0.5 )
                z = ( p / q ) - t;
            else
                z = t - ( p / q );
            return m + z * s;
        }

        public override double GetValue( )
        {
            double u, t, p, q, z;
            u = randomizer.NextDouble( );
            if( u < 0.5 )
                t = Math.Sqrt( -2.0 * Math.Log( u ) );
            else
                t = Math.Sqrt( -2.0 * Math.Log( 1.0 - u ) );
            p = p0 + t * ( p1 + t * ( p2 + t * ( p3 + t * p4 ) ) );
            q = q0 + t * ( q1 + t * ( q2 + t * ( q3 + t * q4 ) ) );
            if( u < 0.5 )
                z = ( p / q ) - t;
            else
                z = t - ( p / q );
            return mean + z * standardDeviation;
        }
    }
}
