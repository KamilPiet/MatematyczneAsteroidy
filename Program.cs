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
        public static int numberOfAsteroids = 7;
        public static int timeLimit = 30;
        public static double speedScale = 0.6;
        public static double totalGameTime = 0;
        public static bool nextLvl = true;
        public static Form1 f1;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
            while (true)
            {
                f1 = new Form1();
                Application.Run(f1);
                totalGameTime += Form1.gameTime;
                if(nextLvl)
                {
                    stage++;
                    Application.Run(new Form2());
                }
                else
                {
                    Application.Run(new Form3());
                    points = 0;
                    stage = 1;
                    totalGameTime = 0;
                }
            }
        }
    }
}
