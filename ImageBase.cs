using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using AForge.Imaging.Filters; //http://www.aforgenet.com/projects/iplab/downloads.html

namespace MatematyczneAsteroidy
{
    class ImageBase : IDisposable
    {
        bool disposed = false;

        Bitmap _bitmap; //handler

        private int X;
        private int Y;

        public int Left {
            get { return X; }
            set { X = value; }
        }
        public int Top {
            get { return Y; }
            set { Y = value; }
        }
        public ImageBase(Bitmap _resource)
        {
            _bitmap = new Bitmap(_resource);
        }

        public void DrawImage(Graphics gr)
        {
            gr.DrawImage(_bitmap, X, Y);
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
