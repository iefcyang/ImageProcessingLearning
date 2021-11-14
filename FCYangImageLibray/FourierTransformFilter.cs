using System;

namespace FCYangImageLibray
{
    public class FourierTransformFilter
    { 
        public virtual Complex GetValue( double distanceToCenter) { return new Complex(0, 0); }
    }

    public class IdentityFilter : FourierTransformFilter
    {
        public override Complex GetValue(double distanceToCenter)
        {
            return new Complex(1, 0);
        }
    }

    public class ZeroCenterLowPassFilter : FourierTransformFilter
    {
        public override Complex GetValue(double distanceToCenter)
        {
            if (distanceToCenter == 0) return new Complex(0, 0);
            else return new Complex(1, 0);
        }
    }

    public class IdealLowPassFilter : FourierTransformFilter
    {
        double radius = 10.0;
        public IdealLowPassFilter(double dis)
        {
            radius = dis;
        }
        public override Complex GetValue(double distanceToCenter)
        {
            if (distanceToCenter <= radius) return new Complex(1, 0);
            else return new Complex(0, 0);
        }
    }

    public class ButterworthLowPassFilter : FourierTransformFilter
    {
        int order = 2;
        double radius = 10.0;

        public ButterworthLowPassFilter(double radius, int order)
        {
            this.radius = radius;
            this.order = order;
        }

        public override Complex GetValue(double distanceToCenter)
        {
            double temp = 1.0 + Math.Pow(distanceToCenter / radius, 2 * order);
            return new Complex(1.0 / temp, 0);
        }
    }

    public class GaussianLowPassFilter : FourierTransformFilter
    {
        double std = 10.0;

        public GaussianLowPassFilter(double value)
        {
        }

        public override Complex GetValue(double distanceToCenter)
        {
            double temp = distanceToCenter / std;
            double real = Math.Exp(-0.5 * temp * temp);
            return new Complex(real, 0);
        }
    }

    public class HomomorphicFilter : FourierTransformFilter
    {
        double c = 1.0, range = 1.0, low = 0.1, radius = 10;
        string title;
        public override string ToString()
        {
            return title;
        }
        public HomomorphicFilter( double order, double gammaH, double gammaL, double D0)
        {
            c = order; range = gammaH-gammaL; low = gammaL; radius = D0;
            title = $"Homomorphic(H{gammaH} L{gammaL} D{D0} c{order})";
        }

        public override Complex GetValue(double distanceToCenter)
        {
            double temp = distanceToCenter / radius;             
            temp = low + (1.0 - Math.Exp(-c * temp * temp)) * range;
            return new Complex(temp, 0);
        }
    }
}
