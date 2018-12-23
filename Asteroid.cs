using System;
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
        Bitmap _bitmap; //handler
        private int liczba;
        public int li
        {
            get { return liczba; }
            set { liczba = value; }
        }
        public Asteroid(Bitmap _h)
        {
            _AsteroidBox.X = Left + 4;
            _AsteroidBox.Y = Top + 4;
            _AsteroidBox.Width = 92;
            _AsteroidBox.Height = 92;
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
            Font font = new Font("Courier New", 16);
            SolidBrush brush = new SolidBrush(Color.LightGray);
            gr.DrawImage(_bitmap, Left, Top);
            gr.DrawString(li.ToString(), font, brush, Left + 5*_AsteroidBox.Width / 16, Top + 7*_AsteroidBox.Height / 16);
        }
    }
}
