using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_3_Andres_Flórez_y_Thomas_Ciro
{
    public partial class datosJugador : Form
    {

        crearJuegoForm jugadorAux = new crearJuegoForm();

        public datosJugador()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void addJugador_Click(object sender, EventArgs e)
        {

            Close();
        }

        public String getNombre()
        {
            return nombreTextBox.Text;
        }

        public String getEmail()
        {
            return emailTextBox.Text;
        }
        public String getEndulzadaIdeal()
        {
            return EndulzIdealTextBox.Text;
        }
        public String getRegaloIdeal()
        {
            return RegaloIdealTextBox.Text;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
