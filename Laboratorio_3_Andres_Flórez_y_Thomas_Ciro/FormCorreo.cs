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
    public partial class FormCorreo : Form
    {
        OperBasicas operaciones = new OperBasicas();
        
        public FormCorreo()
        {
            InitializeComponent();
        }

        private void botonEnviar_Click(object sender, EventArgs e)
        {
            Close();
            operaciones.mensajeEmergente("Exito", "se ha enviado correctamente el mensaje");
            textBoxCorreo.Text = String.Empty;
        }
    }
}
