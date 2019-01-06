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
    /// <summary>Okno wyświetlane po zakończeniu gry</summary>
    public partial class GameOver : Form
    {
        /// <summary>Metoda odpowiedzialna za wyświetlenia właściwych informacji w oknie</summary>
        public GameOver()
        {
            InitializeComponent();
            label5.Text = Program.points.ToString();
            label6.Text = Math.Round(Program.totalGameTime, 0).ToString() + " s";
            label7.Text = Program.stage.ToString();
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
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Menu Główne"</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
