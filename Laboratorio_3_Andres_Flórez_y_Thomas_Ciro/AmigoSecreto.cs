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
        int valorEndulzada;
        int valorRegalo;
        Jugador[] jugadores;
        OperBasicas operaciones;

        public AmigoSecreto(int totalJugadores, DateTime fechaInicio,
              DateTime fechaFinal, int freqEndulzadas, int numEndulzadas)
        {
            this.totalJugadores = totalJugadores;
            this.jugadores = new Jugador[totalJugadores];
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.freqEndulzadas = freqEndulzadas;
            this.numEndulzadas = numEndulzadas;
            this.operaciones = new OperBasicas();
        }

        public Jugador getJugador(int pos)
        {
            return jugadores[pos];
        }
        public void addJugador(Jugador jugador, int pos)
        {
            jugadores[pos] = jugador;
        }

        public void asignarAmigoSecreto()
        {
            Random generador = new Random();
            int minNUmSubGrupos = 1;
            int maxNumSubGrupos = totalJugadores / 2;
            int subGrupos = generador.Next(minNUmSubGrupos, maxNumSubGrupos+1);
            int[] asignacionSubGrupos = new int[subGrupos];
            asignacionSubGrupos = operaciones.AsignarLongSubGrupos(totalJugadores, subGrupos);
            int k = 0;
            Jugador[] cadenaDesordenada = new Jugador[totalJugadores];
            this.jugadores.CopyTo(cadenaDesordenada, 0);
            operaciones.DesordenarVector(cadenaDesordenada);
            for (int i = 0; i < subGrupos; i++)
            {
                int longSubGrupo = asignacionSubGrupos[i];
                Jugador[] subGrupo = new Jugador[longSubGrupo];
                for(int j = 0; j < longSubGrupo;j++)
                {
                    subGrupo[j] = cadenaDesordenada[k];
                    k++;
                }
                asignarCadena(subGrupo);
            }
        }

        public void asignarCadena(Jugador[] jugadoresCadena)
        {
            int n = jugadoresCadena.Length;
            for (int i = 0; i < n; i++)
            {
                int sig = (i + 1) % n;
                jugadoresCadena[i].setAmigoSecreto(jugadoresCadena[sig]);
            }
        }
    }
}
