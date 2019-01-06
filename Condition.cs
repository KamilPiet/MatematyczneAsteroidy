using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematyczneAsteroidy
{
    /// <summary>Klasa odpowiedzialna za wybieranie polecenia na danym poziomie oraz za sprawdzanie warunku przy trafieniu asteroidy</summary>
    class Condition
    {
        /// <summary>Numer polecenia</summary>
        private int topicNumber;
        /// <summary>Zmienna używana do sprecyzowania niektorych poleceń</summary>
        private int topicValue;
        /// <summary>Konstruktor przypisuje numer polecenia</summary>
        /// <param name="tNumber">Numer polecenia, który ma zostać przypisany</param>
        public Condition(int tNumber)
        {
            topicNumber = tNumber;
        }
        /// <summary>Metoda wybierająca polecenie</summary>
        public string cTopic()
        {
            Random rnd = new Random();
            string topic;
            switch(topicNumber)
            {
                case 0:
                    topic = "Liczby parzyste";
                    break;
                case 1:
                    topic = "Liczby nieparzyste";
                    break;
                case 2:
                    topicValue = rnd.Next(3, 6);
                    topic = "Liczby podzielne przez " + topicValue;
                    break;
                case 3:
                    topicValue = rnd.Next(-90, 51);
                    topic = "Liczby większe od " + topicValue;
                    break;
                case 4:
                    topicValue = rnd.Next(-50, 91);
                    topic = "Liczby mniejsze od " + topicValue;
                    break;
                default:
                    topicValue = rnd.Next(3, 6);
                    topic = "Liczby podzielne przez " + topicValue;
                    break;
            }
            return topic;
        }
        /// <summary>Metoda sprawdzająca warunek przy trafieniu asteroidy</summary>
        /// <param name="x">Liczba przypisana do trafionej asteroidy</param>
        public bool checkC(int x)
        {
            bool c = true; ;
            switch (topicNumber)
            {
                case 0:
                    if (x % 2 == 0)
                        c = true;
                    else
                        c = false;
                    break;
                case 1:
                    if (x % 2 != 0)
                        c = true;
                    else
                        c = false;
                    break;
                case 2:
                    if (x % topicValue == 0)
                        c = true;
                    else
                        c = false;
                    break;
                case 3:
                    if (x > topicValue)
                        c = true;
                    else
                        c = false;
                    break;
                case 4:
                    if (x < topicValue)
                        c = true;
                    else
                        c = false;
                    break;
                default:
                    if (x % 2 == 0)
                        c = true;
                    break;
            }
            return c;
        }
    }
}
