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
        OperBasicas operaciones; 
        AmigoSecreto datosJuego;
        datosJugador formDatosJugador = new datosJugador();
        int posJugador = 0;

        public crearJuegoForm()
        {
            InitializeComponent();
            operaciones = new OperBasicas();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void initJuegoBtn_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = fechaInicioText.Value;
            DateTime fechaFinal = fechaFinalText.Value;
            String[] validarDatosJuego = { frecEndulzText.Text, numEndulzText.Text, valorEndulzText.Text, valorRegaloText.Text, numJugText.Text };

            int x = 0;

            Boolean validarEnteros = true;


            for (int i = 0; i < validarDatosJuego.Length; i++) {

                if (!operaciones.validarIntPositivo(validarDatosJuego[i]))
                {
                    validarEnteros = false;
                }

            }

            if (validarEnteros)
            {
                int frecEndulz  = int.Parse(validarDatosJuego[0]);
                int numEndulz = int.Parse(validarDatosJuego[1]);
                int valorEndulz = int.Parse(validarDatosJuego[2]);
                int valorRegalo = int.Parse(validarDatosJuego[3]);
                int numJug = int.Parse(validarDatosJuego[4]);

                Boolean validarFecha = operaciones.validarFecha(fechaInicio, fechaFinal, frecEndulz, numEndulz);

                if (numJug >= 4)
                {

                    if (validarFecha)
                    {
                        datosJuego = new AmigoSecreto(numJug, fechaInicio, fechaFinal, frecEndulz, numEndulz, valorEndulz, valorRegalo);
                        operaciones.mensajeEmergente("Creado", "Se ha creado el juego, por favor ingrese los jugadores");

                    }
                    else
                    {
                        // error de fechas
                        operaciones.mensajeEmergente("Error", "Error, Revise las fechas, la frecuencia de endulzada y el numero de endulzadas");
                    }
                }
                else 
                {
                    // el minimo de jugadores debe de ser 4, pues de lo contrario el amigo no seria tan secreto
                    operaciones.mensajeEmergente("Error", "Error, El minimo de jugadores debe ser 4");

                }
            }
            else
            {

                //error con los valores enteros
                operaciones.mensajeEmergente("Error", "los valores numericos deben ser enteros positivos");
            }

        }

        private void addJugador_Click(object sender, EventArgs e)
        {
            Console.WriteLine("no entra");
            if (datosJuego.getJugador(datosJuego.getTotalJugadores()-1) == null)
            {
                Console.WriteLine("si entra");
                formDatosJugador.ShowDialog();

                String nombre = formDatosJugador.getNombre();
                String email = formDatosJugador.getEmail();
                String endulzada = formDatosJugador.getEndulzadaIdeal();
                String regalo = formDatosJugador.getRegaloIdeal();

                if (nombre == "" || email == "" || endulzada == "" || regalo == "")
                {
                    operaciones.mensajeEmergente("Error", "Por favor llene todos los campos");
                }
                else {

                    if (email.IndexOf("@") == -1)
                    {
                        operaciones.mensajeEmergente("Error", "Ingrese un correo valido");
                    }
                    else
                    { 

                        Jugador jugador = new Jugador(nombre, email, endulzada, regalo);
                        datosJuego.addJugador(jugador,this.posJugador);

                        this.posJugador++;

                        JugadoresBox.Items.Add(nombre);

                    }

                }

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
