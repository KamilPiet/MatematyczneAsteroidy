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
        Condition Condition;
        List<Asteroid> asteroids = new List<Asteroid>();
        List<Bullet> bullets = new List<Bullet>();
        private int bulletDelay = 9;
        private int numberOfAsteroids = 6;
        private int maxLifeTime = 50;
        private int lifes = 3;
        private int astLeft = 0;
        private double speedScale = 0.6;
        private bool finalScreenS = false;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            finalScreenS = false;
            Program.nF = false;
            numberOfAsteroids += Program.stage / 2;
            Condition = new Condition(rnd.Next(0, 4));
            SpaceShip = new SpaceShip() { Left = Width / 2, Top = Height / 2 };
            label2.Text = Condition.cTopic();
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
                    Left = rnd.Next(10, Width - 10),
                    Top = rnd.Next(10, Height - 10),
                    VelX = (rnd.NextDouble() - 0.5) * speedScale,
                    VelY = (rnd.NextDouble() - 0.5) * speedScale,
                    Li = rnd.Next(-100, 100)
                });
                if (Condition.checkC(asteroids[i].Li))
                    astLeft++;
            }
            while (astLeft == 0) // aby co najmniej jedna asteroida spelniala kryterium
            {
                foreach (Asteroid a in asteroids.ToList())
                {
                    a.Li = rnd.Next(-100, 100);
                    if (Condition.checkC(a.Li))
                        astLeft++;
                }
            }
        }
        private void timerGameLoop_Tick(object sender, EventArgs e)
        {
            if (SpaceShip.angleIncrease)
                SpaceShip.angle += 0.15;
            if (SpaceShip.angleDecrease)
                SpaceShip.angle -= 0.15;
            if (SpaceShip.accelerate)
            {
                SpaceShip.VelX -= 0.09 * Math.Cos(SpaceShip.angle);
                SpaceShip.VelY -= 0.09 * Math.Sin(SpaceShip.angle);
            }
            SpaceShip.Update(SpaceShip.Left + SpaceShip.VelX * timerGameLoop.Interval, SpaceShip.Top + SpaceShip.VelY * timerGameLoop.Interval);
            WrapAround(SpaceShip);

            foreach (Asteroid a in asteroids.ToList())
            {
                a.Update(a.Left + a.VelX * timerGameLoop.Interval, a.Top + a.VelY * timerGameLoop.Interval);
                WrapAround(a);
                foreach (Bullet b in bullets.ToList())
                {
                    if (a._AsteroidBox.Contains(b._BulletBox))
                    {
                        asteroids.Remove(a);
                        bullets.Remove(b);
                        if (Condition.checkC(a.Li))
                        {
                            Program.points += 10;
                            astLeft--;
                        }
                        else
                            lostLife();
                    }
                }
                if (a._AsteroidBox.Contains((int)SpaceShip.A.X, (int)SpaceShip.A.Y+3) ||
                    a._AsteroidBox.Contains((int)SpaceShip.B.X+3, (int)SpaceShip.B.Y-3) ||
                    a._AsteroidBox.Contains((int)SpaceShip.C.X-3, (int)SpaceShip.C.Y-3))
                {
                    asteroids.Remove(a);
                    lostLife();
                    if (Condition.checkC(a.Li))
                        astLeft--;
                }
            }
            foreach (Bullet b in bullets.ToList())
            {
                b.lifetime++;
                if (b.lifetime >= maxLifeTime)
                {
                    bullets.Remove(b);                    
                }
                b.Update(b.Left + b.VelX * timerGameLoop.Interval, b.Top + b.VelY * timerGameLoop.Interval);
                WrapAround(b);
            }
            bulletDelay--;
            if (lifes < 3)
            {
                pictureBox3.Visible = false;
                if (lifes < 2)
                {
                    pictureBox2.Visible = false;
                    if (lifes < 1)
                    {
                        pictureBox1.Visible = false;
                        if(!finalScreenS)
                        {
                            finalScreenS = true;
                            Form f4 = new Form4();
                            f4.ShowDialog();
                            Program.nF = false;
                            Close();
                        }
                    }
                }     
            }  
            label1.Text = Program.points.ToString();
            label4.Text = Program.stage.ToString();
            if (astLeft == 0)
            {
                Program.nF = true;
                Close();
            }
            Refresh();
        }
        private void WrapAround(MovingBase obj)
        {
            int shift = 0;
            Type type = obj.GetType();
            if (type == typeof(SpaceShip))
                shift = 0;
            else if (type == typeof(Bullet))
                shift = 6;
            else if (type == typeof(Asteroid))
                shift = 92;

            if (obj.Left < 0 - shift)
                obj.Left = Width;
            else if (obj.Left > Width)
                obj.Left = 0 - shift;
            if (obj.Top < 0 - shift)
                obj.Top = Height- label2.Height;
            else if (obj.Top > Height-label2.Height)
                obj.Top = 0 - shift;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SpaceShip.DrawImage(g);
            foreach(Asteroid a in asteroids)
                a.DrawImage(g);
            foreach (Bullet a in bullets)
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
                case Keys.Space:
                    if(bulletDelay<=0)
                    {
                        bullets.Add(new Bullet(Properties.Resources.Bullet)
                        {
                            Left = (int)SpaceShip.A.X - 6,
                            Top = (int)SpaceShip.A.Y - 6,
                            VelX = -1 * Math.Cos(SpaceShip.angle),
                            VelY = -1 * Math.Sin(SpaceShip.angle)
                        });
                        bulletDelay = 10;
                    }
                    break;
            }
        }
        private void lostLife()
        {
            lifes--;
            SpaceShip.VelX = 0;
            SpaceShip.VelY = 0;
            SpaceShip.angle = Math.PI / 2.0;
            SpaceShip.Update(Width / 2, Height / 2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
                panel3.Visible = false;
            else
                panel3.Visible = true;
            label1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f5 = new Form5();
            f5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
