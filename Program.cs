using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatematyczneAsteroidy
{
    public static class Program
    {
        public static int points = 0;
        public static int stage = 1;
        public static bool nF = true;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
            while (true)
            {
                Application.Run(new Form1());
                if(nF)
                {
                    stage++;
                    Application.Run(new Form2());
                }
                else
                {
                    points = 0;
                    stage = 1;
                    Application.Run(new Form3());
                }
            }
        }
    }
}
