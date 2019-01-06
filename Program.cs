using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Gra edukacyjna inspirowana grą arcade "Asteroids" stworzoną przez Atari. Celem gry jest strzelanie w asteroidy zawierające liczby
/// spełniające kryterium wyświetlone na dole pola gry. Za niszczenie właściwych asteroid i przechodzenie na wyższe poziomy gracz 
/// otrzymuje punkty. Za kolizje lub trafianie w niewłaściwe asteroidy gracz traci punkty życia. Liczba asteroid, jak i limit
/// czasowy rośnie wraz z przechodzenie na wyższe poziomy. W opcjach gry istnieje możliwość zmiany ilości i prędkości asteroid, 
/// długości limitu czasowego oraz wyłączenia punktów życia. Za 100, 500 i 1000 punktów gracz otrzymuje trofeum. Grfiki trofeów 
/// zostały stworzone na podstawie grafiki pochodzącej z www.freepik.com. Pozostałe zasoby zostały wykonane samodzielnie.
/// Repozytorium: https://github.com/KamilPiet/MatematyczneAsteroidy
/// </summary>
namespace MatematyczneAsteroidy
{
    /// <summary>Główna klasa programu</summary>
    public static class Program
    {
        /// <summary>Liczba punktów zdobytych w danym podejściu</summary>
        public static int points = 0;
        /// <summary>Liczba punktów zdobytych od momentu uruchomienia programu</summary>
        public static int totalPoints = 0;
        /// <summary>Aktualny poziom</summary>
        public static int stage = 0;
        /// <summary>Maksymalny uzyskany poziom</summary>
        public static int maxStage = 1;
        /// <summary>Liczba asteroid na początku aktualnego poziomu</summary>
        public static int numberOfAsteroids = 7;
        /// <summary>Modyfikator liczby asteroid</summary>
        public static int numberOfAsteroidsMod = 0;
        /// <summary>Limit czasowy na danym poziomie</summary>
        public static int timeLimit = 30;
        /// <summary>Modyfikator limitu czasowego</summary>
        public static int timeLimitMod = 0;
        /// <summary>Dodatkowe punkty przypisywane przy przejściu na następny poziom za wybraną prędkość asteroid</summary>
        public static int bonusPointsA = 30;
        /// <summary>Dodatkowe punkty przypisywane przy przejściu na następny poziom za wybraną liczbę asteroid</summary>
        public static int bonusPointsB = 40;
        /// <summary>Dodatkowe punkty przypisywane przy przejściu na następny poziom za wybrany limit czasowy</summary>
        public static int bonusPointsC = 30;
        /// <summary>Współczynnik skalowania prędkości asteroid</summary>
        public static double speedScale = 0.6;
        /// <summary>Modyfikator współczynnika skalowania prędkości asteroid</summary>
        public static double speedScaleMod = 0;
        /// <summary>Czas aktualnego podejścia</summary>
        public static double totalGameTime = 0;
        /// <summary>Suma czasu wszystkich podejść od momentu uruchomienia programu</summary>
        public static double totalTime = 0;
        /// <summary>Flaga - czy uruchomić następny poziom</summary>
        public static bool nextLvl = true;
        /// <summary>Flaga - czy limit czasowy jest wyłączony</summary>
        public static bool timerOff = false;
        /// <summary>Flaga - czy punkty życia są wyłączone</summary>
        public static bool livesOff = false;
        /// <summary>Flaga - czy zostało wyświetlone brązowe trofeum</summary>
        public static bool trophy1Showed = false;
        /// <summary>Flaga - czy zostało wyświetlone srebrne trofeum</summary>
        public static bool trophy2Showed = false;
        /// <summary>Flaga - czy zostało wyświetlone złote trofeum</summary>
        public static bool trophy3Showed = false;

        /// <summary>Główna metoda programu</summary>
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
