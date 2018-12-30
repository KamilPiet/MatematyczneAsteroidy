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
        public static int totalPoints = 0;
        public static int stage = 1;
        public static int maxStage = 1;
        public static int numberOfAsteroids = 7;
        public static int timeLimit = 30;
        public static double speedScale = 0.6;
        public static double totalGameTime = 0; // czas aktualnej gry
        public static double totalTime = 0;     // czas wszystkich gier
        public static bool nextLvl = true;
        public static Game f1;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
            while (true)
            {
                f1 = new Game();
                Application.Run(f1);
                if(nextLvl)
                {
                    stage++;
                    if (stage > maxStage)
                        maxStage = stage;
                    Application.Run(new NextLevel());
                }
                else
                {
                    Application.Run(new GameOver());
                    Application.Run(new MainMenu());
                    points = 0;
                    stage = 1;
                    totalGameTime = 0;
                }
            }
        }
    }
}
