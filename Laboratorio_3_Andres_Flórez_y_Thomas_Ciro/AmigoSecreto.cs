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

        public AmigoSecreto() {

        }

        public AmigoSecreto(int totalJugadores, DateTime fechaInicio,
              DateTime fechaFinal, int freqEndulzadas, int numEndulzadas, int valorEndulzada, int valorRegalo)
        {
            this.totalJugadores = totalJugadores;
            this.jugadores = new Jugador[totalJugadores];
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.freqEndulzadas = freqEndulzadas;
            this.numEndulzadas = numEndulzadas;
            this.valorEndulzada = valorEndulzada;
            this.valorRegalo = valorRegalo;
            this.operaciones = new OperBasicas();
        }


        /***************************    setters    *******************************/
        public void setTotalJugadores(int totalJugadores) 
        {
            this.totalJugadores = totalJugadores;
        }

        public void setFechaInicio(DateTime fechaInicio) 
        {
            this.fechaInicio = fechaInicio;
        }

        public void setFechaFinal(DateTime fechaFinal) 
        {
            this.fechaFinal = fechaFinal;
        }

        public void setFreqEndulzadas(int freqEndulzadas)
        {
            this.freqEndulzadas = freqEndulzadas;
        }

        public void setNumEndulzadas(int numEndulzadas)
        {
            this.numEndulzadas = numEndulzadas;
        }

        public void setValorEndulzada(int valorEndulzada)
        {
            this.valorEndulzada = valorEndulzada;
        }

        public void setvalorRegalo(int valorRegalo)
        {
            this.totalJugadores = valorRegalo;
        }
        /*************************              Getters            *************************/

        public int getTotalJugadores() {
            return totalJugadores;
        }

        public DateTime getFechaInicio()
        {
            return this.fechaInicio;
        }

        public DateTime getFechaFinal()
        {
            return this.fechaFinal;
        }

        public int getFreqEndulzadas()
        {
            return this.freqEndulzadas;
        }

        public int getNumEndulzadas()
        {
            return numEndulzadas;
        }

        public int getValorEndulzada() { 
            return this.valorEndulzada;
        }

        public int getValorRegalo() 
        {
            return this.valorRegalo;
        }



        public Jugador getJugador(int pos)
        {
            return jugadores[pos];
        }

        public void addJugador(Jugador jugador, int pos)
        {
            jugadores[pos] = jugador;
        }

        //
        public void inicializarVectorJugadores() 
        {
            this.jugadores = new Jugador[this.totalJugadores];
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
