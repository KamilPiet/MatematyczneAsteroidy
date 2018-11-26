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
        public int xVel;
        public int yVel;

        private Rectangle _AsteroidBox = new Rectangle();

        public Asteroid(Bitmap _h)
            : base(_h)
        {
            this._AsteroidBox.X = Left + 10;
            this._AsteroidBox.Y = Top + 10;
            this._AsteroidBox.Width = 130;
            this._AsteroidBox.Height = 130;
        }
    }
}
