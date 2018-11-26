using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class Bullet : ImageBase
    {
        public int xVel = 1;
        public int yVel = 1;

        private Rectangle _BulletBox = new Rectangle();

        public Bullet()
            : base(Properties.Resources.Bullet)
        {
            this._BulletBox.X = Left;
            this._BulletBox.Y = Top;
            this._BulletBox.Width = 10;
            this._BulletBox.Height = 10;
        }
    }
}
