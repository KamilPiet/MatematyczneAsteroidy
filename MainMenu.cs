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
    /// <summary>Menu główne</summary>
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Start"</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Wyjście"</summary>
        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Opcje"</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Form o1 = new Options();
            o1.ShowDialog();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Statystyki"</summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Form s1 = new Statistics();
            s1.ShowDialog();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Pomoc"</summary>
        private void button4_Click(object sender, EventArgs e)
        {
            Form h1 = new Help();
            h1.ShowDialog();
        }
    }
}
