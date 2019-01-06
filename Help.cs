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
    /// <summary>Okno zawierąjące informacje o sterowaniu w grze</summary>
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }
        /// <summary>Metoda obsługująca wciśnięcie przycisku "Powrót"</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
