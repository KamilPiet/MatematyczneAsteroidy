using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematyczneAsteroidy
{
    class Condition
    {
        private int topicNumber;
        private int topicValue;
        public Condition(int tNumber)
        {
            topicNumber = tNumber;
        }
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
                    topicValue = rnd.Next(3, 5);
                    topic = "Liczby podzielne przez " + topicValue;
                    break;
                case 3:
                    topicValue = rnd.Next(-90, 50);
                    topic = "Liczby większe od " + topicValue;
                    break;
                case 4:
                    topicValue = rnd.Next(-50, 90);
                    topic = "Liczby mniejsze od " + topicValue;
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
