using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class Bullet : MovingBase, IDisposable
    {
        public Rectangle _BulletBox = new Rectangle();
        bool disposed = false;
        Bitmap _bitmap; //handler
        public int lifetime = 0;

        public Bullet(Bitmap _h)
        {
            _BulletBox.X = Left;
            _BulletBox.Y = Top;
            _BulletBox.Width = 10;
            _BulletBox.Height = 10;
            _bitmap = _h;
        }
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            _BulletBox.X = Left;
            _BulletBox.Y = Top;
            _BulletBox.Width = 6;
            _BulletBox.Height = 6;
        }
        public void DrawImage(Graphics gr)
        {
            gr.DrawImage(_bitmap, Left, Top);
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
                _bitmap.Dispose();

            disposed = true;
        }
    }
}
