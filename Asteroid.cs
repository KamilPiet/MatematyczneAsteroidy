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
        public double xVel = 0.1;
        public double yVel = -0.1;

        private Rectangle _AsteroidBox = new Rectangle();

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
