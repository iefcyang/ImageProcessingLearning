using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalImageProcessing
{
    static class Program
    {
        
       
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    //abstract class XX
    //{
    //    readonly int w, h;

    //    public static XX CreateAnXX()
    //    {
    //        return XX;
    //    }
    //}
}
