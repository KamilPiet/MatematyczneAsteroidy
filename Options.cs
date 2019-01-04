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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            switch((int)(100.0*Program.speedScale))
            {
                case 45:
                    radioButton1.Checked = true;
                    break;
                case 60:
                    radioButton2.Checked = true;
                    break;
                case 75:
                    radioButton3.Checked = true;
                    break;
                default:
                    radioButton2.Checked = true;
                    break;
            }
            switch ( Program.numberOfAsteroids)
            {
                case 6:
                    radioButton4.Checked = true;
                    break;
                case 7:
                    radioButton5.Checked = true;
                    break;
                case 8:
                    radioButton6.Checked = true;
                    break;
                default:
                    radioButton5.Checked = true;
                    break;
            }
            switch (Program.timeLimit)
            {
                case 25:
                    radioButton7.Checked = true;
                    break;
                case 30:
                    radioButton8.Checked = true;
                    break;
                case 35:
                    radioButton9.Checked = true;
                    break;
                case 0:
                    radioButton10.Checked = true;
                    break;
                default:
                    radioButton8.Checked = true;
                    break;
            }

            if (Program.livesOff)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Program.speedScale = 0.45;
                Program.bonusPointsA = 20;
            }
            else if (radioButton2.Checked)
            {
                Program.speedScale = 0.6;
                Program.bonusPointsA = 30;
            }
            else if (radioButton3.Checked)
            {
                Program.speedScale = 0.75;
                Program.bonusPointsA = 40;
            }

            if (radioButton4.Checked)
            {
                Program.numberOfAsteroids = 6;
                Program.bonusPointsB = 20;
            }
            else if (radioButton5.Checked)
            {
                Program.numberOfAsteroids = 7;
                Program.bonusPointsB = 40;
            }
            else if (radioButton6.Checked)
            {
                Program.numberOfAsteroids = 8;
                Program.bonusPointsB = 60;
            }

            if (radioButton7.Checked)
            {
                Program.timeLimit = 25;
                Program.bonusPointsC = 10;
                Program.timerOff = false;
            }
            else if (radioButton8.Checked)
            {
                Program.timeLimit = 30;
                Program.bonusPointsC = 30;
                Program.timerOff = false;
            }
            else if (radioButton9.Checked)
            {
                Program.timeLimit = 35;
                Program.bonusPointsC = 50;
                Program.timerOff = false;
            }
            else if (radioButton10.Checked)
            {
                Program.timeLimit = 0;
                Program.bonusPointsC = 0;
                Program.timerOff = true;
            }

            if (checkBox1.Checked)
            {
                Program.livesOff = true;
            }
            else
                Program.livesOff = false;
                
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
