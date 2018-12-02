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

        private int angle;

        public SpaceShip()
            : base(Properties.Resources.SpaceShip)
        {
            this.ax = Left + Properties.Resources.SpaceShip.Width / 2;
            this.ay = Top;                                            //Górny wierzchołek
            this.bx = Left;
            this.by = Top + Properties.Resources.SpaceShip.Height;    //Dolny lewy wierzchołek
            this.cx = Left + Properties.Resources.SpaceShip.Width;
            this.cy = Top + Properties.Resources.SpaceShip.Height;    //Dolny prawy wierzchołek

        }

        public void Update(int X, int Y)
        {
            this.Left = X;
            this.Top = Y;
            this.ax = Left + Properties.Resources.SpaceShip.Width / 2;
            this.ay = Top;                                            //Górny wierzchołek
            this.bx = Left;
            this.by = Top + Properties.Resources.SpaceShip.Height;    //Dolny lewy wierzchołek
            this.cx = Left + Properties.Resources.SpaceShip.Width;
            this.cy = Top + Properties.Resources.SpaceShip.Height;    //Dolny prawy wierzchołek
        }
    }
}
