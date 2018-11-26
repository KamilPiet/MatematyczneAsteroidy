using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class SpaceShip : ImageBase
    {
        public int xVel;
        public int yVel;

        private int ax, ay, bx, by, cx, cy;

        public SpaceShip()
            : base(Properties.Resources.SpaceShip)
        {
            this.ax = Left + 60;
            this.ay = Top;          //Górny wierzchołek
            this.bx = Left;
            this.by = Top + 120;    //Dolny lewy wierzchołek
            this.cx = Left + 120;
            this.cy = Top + 120;    //Dolny prawy wierzchołek

        }

        public void Update(int X, int Y)
        {
            Left = X;
            Top = Y;
            this.ax = Left + 60;
            this.ay = Top;          //Górny wierzchołek
            this.bx = Left;
            this.by = Top + 120;    //Dolny lewy wierzchołek
            this.cx = Left + 120;
            this.cy = Top + 120;    //Dolny prawy wierzchołek
        }
    }
}
