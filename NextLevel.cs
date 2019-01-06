﻿using System;
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
    public partial class NextLevel : Form
    {
        public NextLevel()
        {
            InitializeComponent();
            if (Program.livesOff)
                label2.Visible = false;
            else
                label2.Visible = true;
            label2.Text = "+ " + (Program.bonusPointsA + Program.bonusPointsB + Program.bonusPointsC).ToString() + " punktów";
            if (Program.totalPoints >= 100 && !Program.trophy1Showed)
            {
                Program.trophy1Showed = true;
                pictureBox1.Visible = true;
                pictureBox1.Image = Properties.Resources.bronze;
            }
            else if (Program.totalPoints >= 500 && !Program.trophy2Showed)
            {
                Program.trophy2Showed = true;
                pictureBox1.Visible = true;
                pictureBox1.Image = Properties.Resources.silver;
            }
            else if (Program.totalPoints >= 1000 && !Program.trophy3Showed)
            {
                Program.trophy3Showed = true;
                pictureBox1.Visible = true;
                pictureBox1.Image = Properties.Resources.gold;
            }
            else
                pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.nextLvl = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form o1 = new Options();
            o1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form s1 = new Statistics();
            s1.ShowDialog();
        }
    }
}
