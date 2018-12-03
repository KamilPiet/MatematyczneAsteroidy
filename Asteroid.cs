using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class Asteroid : ImageBase
    {
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

        public Rectangle _AsteroidBox = new Rectangle();

        public Asteroid(Bitmap _h)
            : base(_h)
        {
            this._AsteroidBox.X = Left + 4;
            this._AsteroidBox.Y = Top + 4;
            this._AsteroidBox.Width = 52;
            this._AsteroidBox.Height = 52;
        }
        public void Update(double X, double Y)
        {
            this.Left = (int)Math.Round(X);
            this.Top = (int)Math.Round(Y);
            this._AsteroidBox.X = Left + 4;
            this._AsteroidBox.Y = Top + 4;
            this._AsteroidBox.Width = 52;
            this._AsteroidBox.Height = 52;
        }
    }
}
