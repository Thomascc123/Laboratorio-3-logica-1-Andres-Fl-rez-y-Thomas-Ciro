﻿using System;
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
    public partial class principalForm : Form
    {
        public principalForm()
        {
            InitializeComponent();
            DateTime fechaInicio = new DateTime(2023, 10, 20, 17, 0, 0);
            DateTime fechaFinal = new DateTime(2023, 11, 20, 17, 0, 0);
            int feq = 8;
            int end = 3;
            AmigoSecreto juegoPrueba = new AmigoSecreto(16, fechaInicio,
                fechaFinal, feq, end);
            for(int i = 0; i < 16; i++)
            {
                String nombre = "Jugador " + (i+1);
                String correo = "jugador" + (i + 1) + "@amigosecreto.com";
                String endulzada = "Dulces de todos tipos";
                String regalo = "Lo que quieran chicos";
                Jugador jugador = new Jugador(nombre,correo,endulzada,regalo);
                juegoPrueba.addJugador(jugador, i);
            }
            juegoPrueba.asignarAmigoSecreto();
            for(int i = 0;i < 16;i++)
            {
                Jugador jugador = juegoPrueba.getJugador(i);
                String nombre = jugador.getNombre();
                Jugador amigoSecreto = jugador.getAmigoSecreto();
                String amSecrNom = amigoSecreto.getNombre();
                Console.WriteLine("El jugador: " + nombre + " tiene al jugador: " +
                             amSecrNom);
            }
        }
    }
}
