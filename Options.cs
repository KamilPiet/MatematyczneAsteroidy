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
            switch((int)(100.0*Program.speedScaleMod))
            {
                case -15:
                    radioButton1.Checked = true;
                    break;
                case 0:
                    radioButton2.Checked = true;
                    break;
                case 15:
                    radioButton3.Checked = true;
                    break;
                default:
                    radioButton2.Checked = true;
                    break;
            }
            switch ( Program.numberOfAsteroidsMod)
            {
                case -1:
                    radioButton4.Checked = true;
                    break;
                case 0:
                    radioButton5.Checked = true;
                    break;
                case 1:
                    radioButton6.Checked = true;
                    break;
                default:
                    radioButton5.Checked = true;
                    break;
            }
            switch (Program.timeLimitMod)
            {
                case -5:
                    radioButton7.Checked = true;
                    break;
                case 0:
                    radioButton8.Checked = true;
                    break;
                case 5:
                    radioButton9.Checked = true;
                    break;
                case -30:
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
                Program.speedScaleMod = -0.15;
                Program.bonusPointsA = 20;
            }
            else if (radioButton2.Checked)
            {
                Program.speedScaleMod = 0;
                Program.bonusPointsA = 30;
            }
            else if (radioButton3.Checked)
            {
                Program.speedScaleMod = 0.15;
                Program.bonusPointsA = 40;
            }

            if (radioButton4.Checked)
            {
                Program.numberOfAsteroidsMod = -1;
                Program.bonusPointsB = 20;
            }
            else if (radioButton5.Checked)
            {
                Program.numberOfAsteroidsMod = 0;
                Program.bonusPointsB = 40;
            }
            else if (radioButton6.Checked)
            {
                Program.numberOfAsteroidsMod = 1;
                Program.bonusPointsB = 60;
            }

            if (radioButton7.Checked)
            {
                Program.timeLimitMod = -5;
                Program.bonusPointsC = 50;
                Program.timerOff = false;
            }
            else if (radioButton8.Checked)
            {
                Program.timeLimitMod = 0;
                Program.bonusPointsC = 30;
                Program.timerOff = false;
            }
            else if (radioButton9.Checked)
            {
                Program.timeLimitMod = 5;
                Program.bonusPointsC = 10;
                Program.timerOff = false;
            }
            else if (radioButton10.Checked)
            {
                Program.timeLimitMod = -30;
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
