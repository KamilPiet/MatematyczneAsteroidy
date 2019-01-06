using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    /// <summary>Klasa modelująca pocisk</summary>
    class Bullet : MovingBase
    {
        /// <summary>Prostokąt określający obszar zajmowany przez pocisk; używany do detekcji kolizji</summary>
        public Rectangle _BulletBox = new Rectangle();
        /// <summary>Pole zawierające informacje o grafice pocisku</summary>
        Bitmap _bitmap;
        /// <summary>Czas życia pocisku</summary>
        public int lifetime = 0;
        /// <summary>Konstruktor ustala rozmiar prostokata i grafikę pocisku</summary>
        /// <param name="_h">Przechowuje informacje o przypisanej grafice</param>
        public Bullet(Bitmap _h)
        {
            _BulletBox.X = Left;
            _BulletBox.Y = Top;
            _BulletBox.Width = 6;
            _BulletBox.Height = 6;
            _bitmap = _h;
        }
        /// <summary>Metoda odświeżająca informacje o pocisku</summary>
        /// <param name="X">Odległość lewej krawędzi pocisku od lewej krawędzi pola gry</param>
        /// <param name="Y">Odległość górnej krawędzi pocisku od górnej krawędzi pola gry</param>
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            _BulletBox.X = Left;
            _BulletBox.Y = Top;
        }
        /// <summary>Metoda rysująca pocisk na ekranie</summary>
        public void DrawImage(Graphics gr)
        {
            gr.DrawImage(_bitmap, Left, Top);
        }
    }
}
