using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021HWK03
{
    static class Program
    {
        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //internal static extern bool MessageBeep(int type);   
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
        //int MB_ICONHAND = 16;
        //int MB_ICONQUESTION = 32;
        //int MB_ICONEXCLAMATION = 48;
        //int MB_ICONASTERISK = 64;

            //MessageBeep(MB_ICONASTERISK);

           // System.Media.SystemSounds.Exclamation.Play();
            //System.Media.SystemSounds.Question.Play();
            //System.Media.SystemSounds.Hand.Play();

            System.Media.SystemSounds.Beep.Play();
           // Console.Beep();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFromHWK3());
        }
    }
}
