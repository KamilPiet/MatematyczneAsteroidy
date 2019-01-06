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
    /// <summary>Klasa odpowiedzialna za właściwą grę</summary>
    public partial class Game : Form
    {
        Random rnd = new Random();
        /// <summary>Zawiera informacje o grafice przypisanej do obiektu</summary>
        Bitmap _h;
        /// <summary>Obiekt reprezntujący statek kosmiczny sterowany przez gracza</summary>
        SpaceShip SpaceShip;
        /// <summary>Obiekt reprezentujący warunek / polecenie na danym poziomie</summary>
        Condition Condition;
        /// <summary>Lista zawierająca asteroidy</summary>
        List<Asteroid> asteroids = new List<Asteroid>();
        /// <summary>Lista zawierająca pociski</summary>
        List<Bullet> bullets = new List<Bullet>();
        /// <summary>Odstęp czasowy między kolejnymi wystrzelonymi pociskami</summary>
        private int bulletDelay = 9;
        /// <summary>Maksymalny czas życia pocisku</summary>
        private int maxLifeTime = 50;
        /// <summary>Liczba  żyć</summary>
        private int lifes = 3;
        /// <summary>Liczba asteroid spełniających warunek, które zostały do zestrzelenia</summary>
        private int astLeft = 0;
        /// <summary>Czas trwania aktualnego poziomu</summary>
        public static double gameTime = 0;
        /// <summary>Flaga - czy został wyświetlony ekran po utracie wszystkich żyć</summary>
        private bool finalScreenShowed = false;
        /// <summary>Konstruktor przygotowuje polecenie na dany poziom, generuje ruch asteroid i umieszcza statek kosmiczny w początkowej lokalizacji</summary>
        public Game()
        {
            InitializeComponent();
            KeyPreview = true;
            Program.nextLvl = false;
            finalScreenShowed = false;
            Program.timeLimit += ((Program.stage - 1) / 2) * 5;
            gameTime = 0;
            Program.numberOfAsteroids += (Program.stage - 1) / 2;
            Condition = new Condition(rnd.Next(0, 5));
            SpaceShip = new SpaceShip() { Left = Width / 2, Top = Height / 2 };
            label2.Text = Condition.cTopic();
            for (int i = 0; i < Program.numberOfAsteroids + Program.numberOfAsteroidsMod; i++)
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
                    Left = rnd.Next(10, Width - 9),
                    Top = rnd.Next(10, Height - 9),
                    VelX = (rnd.NextDouble() - 0.5) * (Program.speedScale + Program.speedScaleMod),
                    VelY = (rnd.NextDouble() - 0.5) * (Program.speedScale + Program.speedScaleMod),
                    Li = rnd.Next(-100, 101)
                });
                if (Condition.checkC(asteroids[i].Li))
                    astLeft++;
                while (asteroids[i].VelX < 0.1 && asteroids[i].VelX > -0.1)
                    asteroids[i].VelX = (rnd.NextDouble() - 0.5) * (Program.speedScale + Program.speedScaleMod);
                while (asteroids[i].VelY < 0.1 && asteroids[i].VelY > -0.1)
                    asteroids[i].VelY = (rnd.NextDouble() - 0.5) * (Program.speedScale + Program.speedScaleMod); 
                /* aby asteroidy zawsze poruszaly sie w dwoch wymiarach, dzieki
                   czemu nie zostana schowane poza ekranem */
            }
            while (astLeft == 0) // aby co najmniej jedna asteroida spelniala kryterium
            {
                foreach (Asteroid a in asteroids.ToList())
                {
                    a.Li = rnd.Next(-100, 101);
                    if (Condition.checkC(a.Li))
                        astLeft++;
                }
            }
        }
        /// <summary>Metoda odpowiedzialna za mechanikę gry</summary>
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
                            Program.totalPoints += 10;
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
                    if (lifes < 1 && !finalScreenShowed)
                    {
                        pictureBox1.Visible = false;
                        lostGame();
                    }
                }     
            }  
            label1.Text = Program.points.ToString();
            label4.Text = Program.stage.ToString();
            if (astLeft == 0)
            {
                Program.nextLvl = true;
                Close();
                lifes = 3;
            }
            double unitTick = timerGameLoop.Interval / 650.0; //dopasowanie interwalu do zliczania mijajacych sekund
            gameTime += unitTick;
            Program.totalGameTime += unitTick;
            Program.totalTime += unitTick;
            label5.Text = Math.Round(Program.timeLimit + Program.timeLimitMod - gameTime, 0).ToString();
            if (!Program.timerOff)
            {
                label5.Visible = true;
                if ((int)gameTime == Program.timeLimit + Program.timeLimitMod && !finalScreenShowed)
                    lostGame();
            }
            else
                label5.Visible = false;
            Refresh();
        }
        /// <summary>Metoda odpowiedzialna przenoszenie obiektow, w momencie wyjścia za krawędź, do przeciwnej krawędzi</summary>
        /// <param name="obj">Ruchomy obiekt (asteroida, pocisk lub statek kosmiczny)</param>
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
        /// <summary>Metoda odpowiedzialna za rysowanie obiektów w polu gry</summary>
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
        /// <summary>Metoda wykonywana w momencie utraty życia</summary>
        private void lostLife()
        {
            if(!Program.livesOff)
            {
                lifes--;
                SpaceShip.VelX = 0;
                SpaceShip.VelY = 0;
                SpaceShip.angle = Math.PI / 2.0;
                SpaceShip.Update(Width / 2, Height / 2);
            }
        }
        /// <summary>Metoda wykonywana w momencie zakończenia gry</summary>
        private void lostGame()
        {
            finalScreenShowed = true;
            Program.nextLvl = false;
            Close();
        }
        /// <summary>Metoda obsługująca wciśnięcie klawisza</summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            panel3.Visible = false;
            timerGameLoop.Start();
            label1.Focus();
            switch (e.KeyCode)
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
        /// <summary>Metoda obsługująca puszczenie klawisza</summary>
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
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Menu"</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
                timerGameLoop.Start();
            }
            else
            {
                panel3.Visible = true;
                timerGameLoop.Stop();
            }
            label1.Focus();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Opcje"</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Form o1 = new Options();
            o1.ShowDialog();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Statyski"</summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Form s1 = new Statistics();
            s1.ShowDialog();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Zakończ grę"</summary>
        private void button4_Click(object sender, EventArgs e)
        {
            lostGame();
        }
    }
}
