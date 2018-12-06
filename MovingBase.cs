﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class MovingBase
    {
        private int X;
        private int Y;
        public int Left {
            get { return X; }
            set { X = value; }
        }
        public int Top {
            get { return Y; }
            set { Y = value; }
        }
        private double xVel;
        private double yVel;
        public double VelX {
            get { return xVel; }
            set { xVel = value; }
        }
        public double VelY{
            get { return yVel; }
            set { yVel = value; }
        }
        public MovingBase()
        {
        }
    }
}