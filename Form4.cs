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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            label5.Text = Program.points.ToString();
            label6.Text = Math.Round(Program.totalGameTime, 0).ToString();
            label7.Text = Program.stage.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
