﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    class Asteroid : MovingBase
    {
        public Rectangle _AsteroidBox = new Rectangle();
        bool disposed = false;
        Bitmap _bitmap; //handler
        public Asteroid(Bitmap _h)
        {
            _AsteroidBox.X = Left + 4;
            _AsteroidBox.Y = Top + 4;
            _AsteroidBox.Width = 52;
            _AsteroidBox.Height = 52;
            _bitmap = _h;
        }
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            _AsteroidBox.X = Left + 4;
            _AsteroidBox.Y = Top + 4;
        }
        public void DrawImage(Graphics gr)
        {
            gr.DrawImage(_bitmap, Left, Top);
        }
    }
}
