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
    public partial class Form5 : Form
    {
        public Form5()
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
                    radioButton4.Checked = true;
                    break;
                case 30:
                    radioButton5.Checked = true;
                    break;
                case 35:
                    radioButton6.Checked = true;
                    break;
                default:
                    radioButton5.Checked = true;
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Program.speedScale = 0.45;
            else if (radioButton2.Checked)
                Program.speedScale = 0.6;
            else if (radioButton3.Checked)
                Program.speedScale = 0.75;

            if (radioButton4.Checked)
                Program.numberOfAsteroids = 6;
            else if (radioButton5.Checked)
                Program.numberOfAsteroids = 7;
            else if (radioButton6.Checked)
                Program.numberOfAsteroids = 8;

            if (radioButton7.Checked)
                Program.timeLimit = 25;
            else if (radioButton8.Checked)
                Program.timeLimit = 30;
            else if (radioButton9.Checked)
                Program.timeLimit = 35;

            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
