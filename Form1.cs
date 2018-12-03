using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatematyczneAsteroidy
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Bitmap _h;
        SpaceShip SpaceShip;
        List<Asteroid> asteroids = new List<Asteroid>();
        int numberOfAsteroids = 8;
        public Form1()
        {
            InitializeComponent();            
            SpaceShip = new SpaceShip() { Left = Width/2, Top = Height/2};
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        _h = new Bitmap(Properties.Resources.Ast1);
                        break;
                    case 2:
                        _h = new Bitmap(Properties.Resources.Ast2);
                        break;
                    case 3:
                        _h = new Bitmap(Properties.Resources.Ast3);
                        break;
                    default:
                        _h = new Bitmap(Properties.Resources.Ast3);
                        break;
                }
                asteroids.Add(new Asteroid(_h)
                {
                    Left = rnd.Next(0, Width),
                    Top = rnd.Next(0, Height),
                    VelX = (rnd.NextDouble() - 0.5)/1,
                    VelY = (rnd.NextDouble() - 0.5)/1
                });
            }
        }

        private void timerGameLoop_Tick(object sender, EventArgs e)
        {
            //SpaceShip.Update(100, 100);
            foreach (Asteroid a in asteroids)
            {
                a.Update(a.Left + a.VelX * timerGameLoop.Interval, a.Top + a.VelY * timerGameLoop.Interval);
                if (a.Left < 0 - a._AsteroidBox.Width)
                    a.Left = Width-8;
                else if (a.Left > Width)
                    a.Left = 0-a._AsteroidBox.Width;
                if (a.Top < 0 - a._AsteroidBox.Height)
                    a.Top = Height-8;
                else if (a.Top > Height)
                    a.Top = 0-a._AsteroidBox.Height; 
            }
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SpaceShip.DrawImage(g);
            foreach(Asteroid a in asteroids)
                a.DrawImage(g);
            base.OnPaint(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.RShiftKey)
            {

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private void Accelerate()
        {

        }
    }
}
