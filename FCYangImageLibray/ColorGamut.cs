﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FCYangImageLibray
{
    public partial class ColorGamut : UserControl
    {
        public static int Red, Green, Blue;
        public static double Hue, Saturation, Intensity;
        public static double[ ] HSI = new double[ 3 ];

        public static double SetRGBToSaturation( int r, int g, int b)
        {
            Red = r; Green = g; Blue = b;
            int min = Red;
            if( Green < min ) min = Green;
            if( Blue < min ) min = Blue;
            HSI[1] = 1.0 - 3.0 * min / ( Red + Green + Blue );
            return HSI[ 1 ];
        }

        public static double SetRGBToHue( int r, int g, int b )
        {
            Red = r; Green = g; Blue = b;
            int RmG = Red - Green;
            int RmB = Red - Blue;
            int GmB = Green - Blue;
            double Hue = Math.Acos( 0.5 * ( RmG + RmB ) / Math.Sqrt( RmG * RmG + RmB * GmB ) ) * 180.0 / Math.PI;
            if( Hue < 0 ) Hue += 360;
            if( Blue > Green ) Hue = 360 - Hue;
            HSI[ 0 ] = Hue;
            return HSI[ 0 ];
        }

        public static double SetRGBToIntensity( int r, int g, int b )
        {
            Red = r; Green = g; Blue = b;
            HSI[2] =  ( Red + Green + Blue ) / 3.0;
            return HSI[ 2 ];
        }


        public static double[] SetRGBToHSI( int r, int g, int b )
        {
            Red = r; Green = g; Blue = b;
            int min = Red;
            if( Green < min ) min = Green;
            if( Blue < min ) min = Blue;
            Saturation = 1.0 - 3.0 * min / ( Red + Green + Blue );
            int RmG = Red - Green;
            int RmB = Red - Blue;
            int GmB = Green - Blue;
            Hue = Math.Acos( 0.5 * ( RmG + RmB ) / Math.Sqrt( RmG * RmG + RmB * GmB ) ) * 180.0 / Math.PI;
            if( Hue < 0 ) Hue += 360;
            if( Blue > Green ) Hue = 360 - Hue;

            Intensity = ( Red + Green + Blue ) / 3.0;
            HSI[ 0 ] = Hue;
            HSI[ 1 ] = Saturation;
            HSI[ 2 ] = Intensity;
            return HSI;
        }

       static double[ , ] XYZtoRGB = {
            { 0.41847, -0.15866, -0.082835 },
            { -0.091169, 0.25243, 0.015708 },
            { 0.00092090, -0.0025498, 0.17860 } };

       static double[ , ] RGBtoXYZ = {
            { 0.49 / 0.17697, 0.31/ 0.17697,0.2 / 0.17697 },
            { 1.0, 0.8124 / 0.17697, 0.01063 / 0.17697 },
            { 0, 0.01 / 0.17697, 0.99 /  0.17697 } };

        public static Color[] GetLinearInterpolatedColors( int numberOfColors, double x1, double y1, double x2, double y2 )
        {
            Color[ ] colors = new Color[ numberOfColors ];
            x2 = x2 - x1; y2 = y2 - y1;
            double xd = x2 / ( numberOfColors - 1 ), yd = y2 / ( numberOfColors - 1 );
            double[ ] xyz = new double[ 3 ];
            double[ ,] rgb = new double[ numberOfColors, 3 ];
            int big = 255;
            for( int i = 0 ; i < numberOfColors ; i++ )
            {
                xyz[ 0 ] = x1 + i * x2 / numberOfColors;
                xyz[ 1 ] = y1 + i * y2 / numberOfColors;
                xyz[ 2 ] = 1.0 - xyz[ 0 ] - xyz[ 1 ];
                for( int r = 0 ; r < 3 ; r++ )
                {
                    rgb[i, r ] = 0.0;
                    for( int c = 0 ; c < 3 ; c++ )
                    {
                        rgb[ i, r ] += XYZtoRGB[ r, c ] * xyz[ c ];
                    }

                }
            }
            for( int i = 0 ; i < numberOfColors ; i++ )
            { 
                for( int r = 0 ; r < 3 ; r++ )
                {
                    rgb[ i, r ] *= big*8;
                    if( rgb[ i, r ] < 0 ) rgb[ i, r ] = 0;
                    if( rgb[ i, r ] > 255 ) rgb[ i, r ] = 255;
                }
                colors[ i ] = Color.FromArgb( (int)(rgb[i,0]), (int) ( rgb[i, 1 ] ), (int) ( rgb[ i, 2 ] ) );
            }
            return colors;
        }

        
        

        private void chtGamut_MouseClick( object sender, MouseEventArgs e )
        {

            double y = chtGamut.ChartAreas[ 0 ].AxisY.PixelPositionToValue( e.Y );
            double x = chtGamut.ChartAreas[ 0 ].AxisX.PixelPositionToValue( e.X );
            double dis0 = ( x - chtGamut.Series[ 1 ].Points[ 0 ].XValue ) * ( x - chtGamut.Series[ 1 ].Points[ 0 ].XValue )
                + ( y - chtGamut.Series[ 1 ].Points[ 0 ].YValues[ 0 ] ) * ( y - chtGamut.Series[ 1 ].Points[ 0 ].YValues[ 0 ] );
            double dis1 = ( x - chtGamut.Series[ 1 ].Points[ 1 ].XValue ) * ( x - chtGamut.Series[ 1 ].Points[ 1 ].XValue )
                 + ( y - chtGamut.Series[ 1 ].Points[ 1 ].YValues[ 0 ] ) * ( y - chtGamut.Series[ 1 ].Points[ 1 ].YValues[ 0 ] );
            if( dis0 < dis1 || e.Button == MouseButtons.Left )
            {
                chtGamut.Series[ 1 ].Points[ 0 ].XValue = x;
                chtGamut.Series[ 1 ].Points[ 0 ].YValues[ 0 ] = y;
            }
            else
            {
                chtGamut.Series[ 1 ].Points[ 1 ].XValue = x;
                chtGamut.Series[ 1 ].Points[ 1 ].YValues[ 0 ] = y;
            }

        }

        double increment = 0.01;
        public ColorGamut( )
        {
            InitializeComponent( );
            //PopulateColorPoints( 255 );
 
        }
 

        private void DrawSpectralLine( )
        {
            throw new NotImplementedException( );
        }




        void PopulateColorPoints( int BigY )
        {
            DataPoint dp;
            chtGamut.Series[ 0 ].Points.Clear( );
            for( double x = 0 ; x <= 0.8 ; x += increment )
            {
                for( double y = increment ; y <= 0.9 ; y += increment )
                {
                    double z = 1.0 - x - y;
                    if( z < 0 ) continue;
                    int R = (int) ( BigY * x / y );
                    int G = (int) (BigY );
                    int B = (int) ( BigY * z / y );
                    //double Largest = R;
                    //if( G > Largest ) Largest = G;
                    //if( B > Largest ) Largest = B;
                    //if( Largest > 255 )
                    //{
                    //    R = (int) ( R / Largest );
                    //    G = (int) ( G / Largest );
                    //    B = (int) ( B / Largest );
                    //} 
                    if( R > 255 ) R = 255;
                    if( G > 255 ) G = 255;
                    if( B > 255 ) B = 255;
                        
                     Color c = Color.FromArgb( R, G,B);
                    dp = new DataPoint( x, y );
                    dp.Color = c;
                    chtGamut.Series[ 0 ].Points.Add( dp );
                }
            }
        }
   
    
    
    }
}
