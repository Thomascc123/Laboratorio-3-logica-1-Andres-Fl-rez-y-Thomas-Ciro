using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Andres_Flórez_y_Thomas_Ciro
{
    internal class AmigoSecreto
    {
        int totalJugadores;
        DateTime fechaInicio;
        DateTime fechaFinal;
        int freqEndulzadas;
        int numEndulzadas;
        Jugador[] jugadores;

        public AmigoSecreto(int totalJugadores, DateTime fechaInicio,
              DateTime fechaFinal, int freqEndulzadas, int numEndulzadas)
        {
            this.totalJugadores = totalJugadores;
            this.jugadores = new Jugador[totalJugadores];
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.freqEndulzadas = freqEndulzadas;
            this.numEndulzadas = numEndulzadas;
        }


    }
}
