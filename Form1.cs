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
            if (SpaceShip.angleIncrease)
                SpaceShip.angle += 0.1;
            if (SpaceShip.angleDecrease)
                SpaceShip.angle -= 0.1;
            if (SpaceShip.accelerate)
            {
                SpaceShip.VelX -= 0.1 * Math.Cos(SpaceShip.angle);
                SpaceShip.VelY -= 0.1 * Math.Sin(SpaceShip.angle);
            }
            SpaceShip.Update(SpaceShip.Left + SpaceShip.VelX * timerGameLoop.Interval, SpaceShip.Top + SpaceShip.VelY * timerGameLoop.Interval);

            if (SpaceShip.Left < 0)
                SpaceShip.Left = Width;
            else if (SpaceShip.Left > Width)
                SpaceShip.Left = 0;
            if (SpaceShip.Top < 0)
                SpaceShip.Top = Height;
            else if (SpaceShip.Top > Height)
                SpaceShip.Top = 0;

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
            switch(e.KeyCode)
            {
                case Keys.K:
                SpaceShip.accelerate = true;
                    break;
                case Keys.D:
                    SpaceShip.angleIncrease = true;
                    break;
                case Keys.A:
                    SpaceShip.angleDecrease = true;
                    break;
            }
                
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.K:
                    SpaceShip.accelerate = false;
                    break;
                case Keys.D:
                    SpaceShip.angleIncrease = false;
                    break;
                case Keys.A:
                    SpaceShip.angleDecrease = false;
                    break;
            }
        }
    }
}
