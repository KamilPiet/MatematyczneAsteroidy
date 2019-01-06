using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MatematyczneAsteroidy
{
    /// <summary>Klasa modelująca asteroidę</summary>
    class Asteroid : MovingBase
    {
        /// <summary>Prostokąt określający obszar zajmowany przez asteroidę; używany do detekcji kolizji</summary>
        public Rectangle _AsteroidBox = new Rectangle();
        /// <summary>Pole zawierające informacje o grafice asteroidy</summary>
        public Bitmap _bitmap;
        /// <summary>Liczba wyświetlana na asteroidzie</summary>
        private int liczba;
        public int Li
        {
            get { return liczba; }
            set { liczba = value; }
        }
        /// <summary>Konstruktor ustala rozmiar prostokata i grafikę asteroidy</summary>
        /// <param name="_h">Przechowuje informacje o przypisanej grafice</param>
        public Asteroid(Bitmap _h)
        {
            _AsteroidBox.X = Left + 4;
            _AsteroidBox.Y = Top + 4;
            _AsteroidBox.Width = 92;
            _AsteroidBox.Height = 92;
            _bitmap = _h;
        }
        /// <summary>Metoda odświeżająca informacje o asteroidzie</summary>
        /// <param name="X">Odległość lewej krawędzi asteroidy od lewej krawędzi pola gry</param>
        /// <param name="Y">Odległość górnej krawędzi asteroidy od górnej krawędzi pola gry</param>
        public void Update(double X, double Y)
        {
            Left = (int)Math.Round(X);
            Top = (int)Math.Round(Y);
            _AsteroidBox.X = Left + 4;
            _AsteroidBox.Y = Top + 4;
        }
        /// <summary>Metoda rysująca asteroidę na ekranie</summary>
        public void DrawImage(Graphics gr)
        {
            Font font = new Font("Courier New", 16);
            SolidBrush brush = new SolidBrush(Color.LightGray);
            gr.DrawImage(_bitmap, Left, Top);
            gr.DrawString(Li.ToString(), font, brush, Left + 5*_AsteroidBox.Width / 16, Top + 7*_AsteroidBox.Height / 16);
        }
    }
}
