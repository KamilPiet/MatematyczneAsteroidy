using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    /// <summary>Klasa modelująca statek kosmiczny</summary>
    class SpaceShip : MovingBase
    {
        /// <summary>Składowa odcięta górnego wierzchołka statku kosmicznego</summary>
        private float ax = 0;
        /// <summary>Składowa rzędna górnego wierzchołka statku kosmicznego</summary>
        private float ay = 0;
        /// <summary>Składowa odcięta dolnego lewego wierzchołka statku kosmicznego</summary>
        private float bx = 0;
        /// <summary>Składowa rzędna dolnego lewego wierzchołka statku kosmicznego</summary>
        private float by = 0;
        /// <summary>Składowa odcięta dolnego prawego wierzchołka statku kosmicznego</summary>
        private float cx = 0;
        /// <summary>Składowa rzędna dolnego prawego wierzchołka statku kosmicznego</summary>
        private float cy = 0;
        /// <summary>Zbiór punktów opisujących statek kosmiczny</summary>
        PointF[] points = new PointF[3];
        /// <summary>Aktualny kąt obrotu statku</summary>
        public double angle = Math.PI / 2.0;
        /// <summary>Poprzedni kąt obrotu statku</summary>
        public double angleOld = Math.PI / 2.0;
        /// <summary>Flaga - czy statek ma przyspieszać</summary>
        public bool accelerate = false;
        /// <summary>Flaga - czy zwiększyć kąt obrotu statku</summary>
        public bool angleIncrease = false;
        /// <summary>Flaga - czy zmniejszyć kąt obrotu statku</summary>
        public bool angleDecrease = false;

        /// <summary>Górny wierzchołek statku</summary>
        public PointF A
        {
            get { return points[0]; }
            set { points[0] = value; }
        }
        /// <summary>Dolny lewy wierzchołek statku</summary>
        public PointF B
        {
            get { return points[1]; }
            set { points[1] = value; }
        }
        /// <summary>Dolny prawy wierzchołek statku</summary>
        public PointF C
        {
            get { return points[2]; }
            set { points[2] = value; }
        }
        /// <summary>Konstruktor tworzący statek kosmiczny</summary>
        public SpaceShip()
            :base()
        {
            MakeTriangle();
        }
        /// <summary>Metoda odświeżająca informacje o statku kosmicznym - ustala jego aktualne położenie</summary>
        /// <param name="X">Składowa odcięta środka statku</param>
        /// <param name="Y">Składowa rzędna środka statku</param>
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            MakeTriangle();
        }
        /// <summary>Metoda odpowiedzialna za rysowanie trójkąta reprezentującego statek we właściwym miejscu i pod właściwym kątem</summary>
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
        /// <summary>Metoda rysująca statek kosmiczny na ekranie</summary>
        public void DrawImage(Graphics gr)
        {
            gr.DrawPolygon(Pens.White, points);
        }
    }
}
