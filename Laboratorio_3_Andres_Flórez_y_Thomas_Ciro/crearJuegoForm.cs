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
    public partial class crearJuegoForm : Form
    {
        //AmigoSecreto informacionJuego = new AmigoSecreto();

        public crearJuegoForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void initJuegoBtn_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = fechaFinalText.Value;
            DateTime fechaFinal = fechaFinalText.Value;
            String[] validarDatosJuego = { frecEndulzText.Text, numEndulzText.Text, valorEndulzText.Text, valorRegaloText.Text, valorRegaloText.Text };

            int x = 0;

            Boolean validarEnteros = true;

            for (int i = 0; i < validarDatosJuego.Length; i++) {

                if (!int.TryParse(validarDatosJuego[i], out x))
                {
                    validarEnteros = false;
                }
            }



        }

    }
}
