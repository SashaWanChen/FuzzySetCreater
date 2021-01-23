using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    //Delegate 委派函式指標(集合)
    public delegate int FunctionTakesNoArgumentReturnInt();
    static class Program
    {
        static int f()
        {
            MessageBox.Show("F()");
            return 1;
        }
        static int g()
        {
            MessageBox.Show("G()");
            return 1;
        }
        static double h()
        {
            MessageBox.Show("H()");
            return 1;
        }
        static int j(int k)
        {
            MessageBox.Show("J()");
            return 1;
        }
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FunctionTakesNoArgumentReturnInt ptr;

            ptr = f;
            ptr += g;
            //ptr();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
