using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class Bullet : MovingBase
    {
        public Rectangle _BulletBox = new Rectangle();
        Bitmap _bitmap; //handler
        public int lifetime = 0;

        public Bullet(Bitmap _h)
        {
            _BulletBox.X = Left;
            _BulletBox.Y = Top;
            _BulletBox.Width = 6;
            _BulletBox.Height = 6;
            _bitmap = _h;
        }
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            _BulletBox.X = Left;
            _BulletBox.Y = Top;
        }
        public void DrawImage(Graphics gr)
        {
            gr.DrawImage(_bitmap, Left, Top);
        }
    }
}
