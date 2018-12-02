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
        //Asteroid Asteroid;
        int numberOfAsteroids = 3;
        public Form1()
        {
            InitializeComponent();
            switch (rnd.Next(1, 3))
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
            }
            SpaceShip = new SpaceShip() { Left = this.Width/2, Top = this.Height/2};
            for (int i = 0; i < numberOfAsteroids; i++)
                asteroids.Add(new Asteroid(_h) { Left = rnd.Next(), Top = rnd.Next() });
           // Asteroid = new Asteroid(_h) { Left = rnd.Next(0, this.Width), Top = rnd.Next(0, this.Height) };
        }

        private void timerGameLoop_Tick(object sender, EventArgs e)
        {
            //SpaceShip.Update(100, 100);
            //this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SpaceShip.DrawImage(g);
            //foreach(Asteroid a in asteroids)
            //a.DrawImage(g);
            asteroids[1].DrawImage(g);
            //Asteroid.DrawImage(g);
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
