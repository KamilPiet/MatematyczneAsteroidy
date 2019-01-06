using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    /// <summary>Klasa bazowa odpowiadająca za ruch obiektów (asteroid, pocisków i statku kosmicznego)</summary>
    class MovingBase
    {
        /// <summary>Odległość lewej krawędzi obiektu od lewej krawędzi pola gry</summary>
        private int x;
        /// <summary>Odległość górnej krawędzi obiektu od górnej krawędzi pola gry</summary>
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
        /// <summary>Składowa prędkości obiektu równoległa do osi OX</summary>
        private double xVel;
        /// <summary>Składowa prędkości obiektu równoległa do osi OY</summary>
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
