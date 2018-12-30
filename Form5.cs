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
            switch((int)(10.0*Program.speedScale))
            {
                case 5:
                    radioButton1.Checked = true;
                    break;
                case 6:
                    radioButton2.Checked = true;
                    break;
                case 7:
                    radioButton3.Checked = true;
                    break;
                default:
                    radioButton1.Checked = true;
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Program.speedScale = 0.5;
            else if (radioButton2.Checked)
                Program.speedScale = 0.6;
            else if (radioButton3.Checked)
                Program.speedScale = 0.7;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
