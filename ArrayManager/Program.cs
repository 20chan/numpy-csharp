using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ArrayManager
{
    static class Program
    {
        public static int Length = -1;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (Length > 0)
                Application.Run(new Form2());
        }
    }
}
