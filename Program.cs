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
        public static int stage = 0;
        public static int maxStage = 1;
        public static int numberOfAsteroids = 7;
        public static int numberOfAsteroidsMod = 0;
        public static int timeLimit = 30;
        public static int timeLimitMod = 0;
        public static int bonusPointsA = 30;
        public static int bonusPointsB = 40;
        public static int bonusPointsC = 30;
        public static double speedScale = 0.6;
        public static double speedScaleMod = 0;
        public static double totalGameTime = 0; // czas aktualnej gry
        public static double totalTime = 0;     // czas wszystkich gier
        public static bool nextLvl = true;
        public static bool timerOff = false;
        public static bool livesOff = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
            while (true)
            {
                numberOfAsteroids = 7;
                timeLimit = 30;
                stage++;
                Application.Run(new Game());
                if (nextLvl)
                {
                    if(!livesOff)
                    {
                        points += bonusPointsA + bonusPointsB + bonusPointsC;
                        totalPoints += bonusPointsA + bonusPointsB + bonusPointsC;
                    }
                    if (stage > maxStage)
                        maxStage = stage;
                    Application.Run(new NextLevel());
                }
                if (!nextLvl)
                {
                    Application.Run(new GameOver());
                    Application.Run(new MainMenu());
                    points = 0;
                    stage = 0;
                    totalGameTime = 0;
                }
            }
        }
    }
}
