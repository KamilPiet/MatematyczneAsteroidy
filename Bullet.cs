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
        private Rectangle _BulletBox = new Rectangle();
        bool disposed = false;
        Bitmap _bitmap; //handler

        public Bullet(Bitmap _h)
        {
            this._BulletBox.X = Left;
            this._BulletBox.Y = Top;
            this._BulletBox.Width = 10;
            this._BulletBox.Height = 10;
            _bitmap = _h;
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
