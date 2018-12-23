using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematyczneAsteroidy
{
    class Condition
    {
        private int tNumber;
        private int tVal;
        public Condition(int tNumber)
        {
            this.tNumber = tNumber;
        }
        public string cTopic()
        {
            Random rnd = new Random();
            string topic;
            switch(tNumber)
            {
                case 0:
                    topic = "Liczby parzyste";
                    break;
                case 1:
                    topic = "Liczby nieparzyste";
                    break;
                case 2:
                    tVal = rnd.Next(2, 5);
                    topic = "Liczby podzielne przez " + tVal;
                    break;
                case 3:
                    tVal = rnd.Next(-90, 50);
                    topic = "Liczby większe od " + tVal;
                    break;
                case 4:
                    tVal = rnd.Next(-50, 90);
                    topic = "Liczby mniejsze od " + tVal;
                    break;
                default:
                    topic = "Liczby parzyste";
                    break;
            }
            return topic;
        }
        public bool checkC(int x)
        {
            bool c = true; ;
            switch (tNumber)
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
                    if (x % tVal == 0)
                        c = true;
                    else
                        c = false;
                    break;
                case 3:
                    if (x > tVal)
                        c = true;
                    else
                        c = false;
                    break;
                case 4:
                    if (x < tVal)
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
