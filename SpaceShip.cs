using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class SpaceShip : MovingBase, IDisposable
    {
        private float ax=0, ay=0, bx=0, by=0, cx=0, cy=0;
        PointF[] points = new PointF[3];

        public double angle = Math.PI / 2.0;
        public double angleOld = Math.PI / 2.0;

        public bool accelerate = false;
        public bool angleIncrease = false;
        public bool angleDecrease = false;

        bool disposed = false;
        public PointF A
        {
            get { return points[0]; }
            set { points[0] = value; }
        }
        public PointF B
        {
            get { return points[1]; }
            set { points[1] = value; }
        }
        public PointF C
        {
            get { return points[2]; }
            set { points[2] = value; }
        }
        public SpaceShip()
            :base()
        {
            ax = Left + Properties.Resources.SpaceShip.Width / 2;
            ay = Top;                                            //Górny wierzchołek
            bx = Left;
            by = Top + Properties.Resources.SpaceShip.Height;    //Dolny lewy wierzchołek
            cx = Left + Properties.Resources.SpaceShip.Width;
            cy = Top + Properties.Resources.SpaceShip.Height;    //Dolny prawy wierzchołek
            A = new PointF(ax, ay);
            B = new PointF(bx, by);
            C = new PointF(cx, cy);
        }

        public void DrawImage(Graphics gr)
        {
            gr.FillPolygon(Brushes.White, points);
        }

        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            ax = Left + Properties.Resources.SpaceShip.Width / 2;
            ay = Top;                                            //Górny wierzchołek
            bx = Left;
            by = Top + Properties.Resources.SpaceShip.Height;    //Dolny lewy wierzchołek
            cx = Left + Properties.Resources.SpaceShip.Width;
            cy = Top + Properties.Resources.SpaceShip.Height;    //Dolny prawy wierzchołek
            A = new PointF(ax, ay);
            B = new PointF(bx, by);
            C = new PointF(cx, cy);
        }
        public void Dispose()
        {
            Dispose(true);                  //overloading
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                return;

            disposed = true;
        }
    }
}
