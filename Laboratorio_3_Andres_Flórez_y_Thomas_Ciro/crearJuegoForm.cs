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
        FormCorreo formCorreo = new FormCorreo();
        datosJugador formDatosJugador = new datosJugador();
        OperBasicas operaciones; 
        AmigoSecreto datosJuego;
        int posJugador = 0;

        public crearJuegoForm()
        {
            InitializeComponent();
            operaciones = new OperBasicas();
        }


        /*
            *metido initJuegoBtn_Clic
            *
            *es un evento que se encarga de recoger los datos del juego engresados por el usuario en el formulario
            *y los valida, si estan correctos los almacena en el objeto datosJuego, sino, muestra un mensaje de error
        */
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

        /*
            *metodo addJugador_Click 
            *
            *es un evento que valida si ya esta lleno el array de jugadores de no ser asi abre una ventana
            *con un formulario que le pide al usuario los datos de un jugador, los valida si estan mal da un mensaje de error,
            *pero si estan correctos almacena los datos y los imprime
        */
        private void addJugador_Click(object sender, EventArgs e)
        {
            if (datosJuego.getJugador(datosJuego.getTotalJugadores()-1) == null)
            {
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

                        detallesJugador.Rows.Add(this.posJugador, nombre, email, endulzada, regalo);

                    }

                }

            }

        }


      

        private void envCorreosBtn_Click(object sender, EventArgs e)
        {
            formCorreo.ShowDialog();
        }
    }
}
