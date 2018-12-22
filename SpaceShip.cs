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
        public float ax=0, ay=0, bx=0, by=0, cx=0, cy=0;
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
            MakeTriangle();
        }
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            MakeTriangle();
        }
        private void MakeTriangle()
        {
            ax = (float)(Left - 25 * Math.Cos(angle));
            ay = (float)(Top - 25 * Math.Sin(angle));    //Górny wierzchołek
            bx = (float)(Left - 30 * Math.Cos(angle + 3f * Math.PI / 4f));
            by = (float)(Top - 30 * Math.Sin(angle + 3f * Math.PI / 4f));    //Dolny lewy wierzchołek
            cx = (float)(Left - 30 * Math.Cos(angle - 3f * Math.PI / 4f));
            cy = (float)(Top - 30 * Math.Sin(angle - 3f * Math.PI / 4f));    //Dolny prawy wierzchołek
            A = new PointF(ax, ay);
            B = new PointF(bx, by);
            C = new PointF(cx, cy);
        }
        public void DrawImage(Graphics gr)
        {
            gr.DrawPolygon(Pens.White, points);
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
