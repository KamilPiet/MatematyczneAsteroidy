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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            label5.Text = Program.totalPoints.ToString();
            label6.Text = Math.Round(Program.totalTime, 0).ToString() + " s";
            label7.Text = Program.maxStage.ToString();
            if (Program.totalPoints >= 100)
                pictureBox1.Image = Properties.Resources.bronze;
            if (Program.totalPoints >= 500)
                pictureBox2.Image = Properties.Resources.silver;
            if (Program.totalPoints >= 1000)
                pictureBox3.Image = Properties.Resources.gold;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            button3.Visible = false;
        }
    }
}
