using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class MovingBase
    {
        private int x;
        private int y;
        public int Left
        {
            get { return x; }
            set { x = value; }
        }
        public int Top
        {
            get { return y; }
            set { y = value; }
        }
        private double xVel;
        private double yVel;
        public double VelX
        {
            get { return xVel; }
            set { xVel = value; }
        }
        public double VelY
        {
            get { return yVel; }
            set { yVel = value; }
        }
    }
}
