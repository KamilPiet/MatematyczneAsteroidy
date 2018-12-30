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
            label6.Text = Math.Round(Program.totalTime, 0).ToString();
            label7.Text = Program.maxStage.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
