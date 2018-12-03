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
        private int ax, ay, bx, by, cx, cy;

        public double angle = Math.PI/2.0;

        public bool accelerate = false;
        public bool angleIncrease = false;
        public bool angleDecrease = false;

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

        public void Update(double X, double Y)
        {
            this.Left = (int)Math.Round(X);
            this.Top = (int)Math.Round(Y);
            this.ax = Left + Properties.Resources.SpaceShip.Width / 2;
            this.ay = Top;                                            //Górny wierzchołek
            this.bx = Left;
            this.by = Top + Properties.Resources.SpaceShip.Height;    //Dolny lewy wierzchołek
            this.cx = Left + Properties.Resources.SpaceShip.Width;
            this.cy = Top + Properties.Resources.SpaceShip.Height;    //Dolny prawy wierzchołek
        }
    }
}
