using FCYangImageLibray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021HWK04
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            Complex a = new Complex( -11, 22 );
            Complex b = new Complex( 33, 44 );
            Complex c = a * b;
            Complex d = c / b;

            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainFrom( ) );
        }
    }
}
