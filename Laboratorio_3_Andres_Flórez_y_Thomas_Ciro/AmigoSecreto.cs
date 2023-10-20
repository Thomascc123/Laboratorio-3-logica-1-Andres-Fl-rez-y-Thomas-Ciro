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


        /*
            *Constructor vacio
            *Este metodo crea un objeto de la clase AmigoSecreto
        */
        public AmigoSecreto() {

        }

        /*
            * Constructo
            * Recibe como parametos: un entero de totalJugadores un DateTime fechaInicio, un DateTime fechaFinal,
            * un entero freqEndulzadas, un entero numEndulzadas, un entero valorEndulzada, un entero valorRegalo)
            * 
            * le asigna a los valores de los parametros a los valores locales de la clase
        */
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


        /*
            *Metodo addJugador
            *
            *tiene como parametos a un objeto Jugador y un entero pos
            *
            *al vector local de jugadores le añade el objeto jugador ingresado en la posicion ingresada.
         */

        public void addJugador(Jugador jugador, int pos)
        {
            jugadores[pos] = jugador;
        }

        
        /*
            *metodo inicializarVectorJugadores
            *
            *inicializa el vector local que tiene como elementos jugadores y usa para ello el numero de jugadores que tiene
            *el juego de amigo secreto.
        */
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

        /*
            *metodo calcProximaEndulzada
            *parametro fecha en DateTime
            *
            *teniendo en cuenta los valores de la fecha inicial de la endulzada, el numero de endulzadas y la frecuencia
            *calcula cual es la endulzada mas proxima a fecha y retorna cuantos dias faltan para esa endulzada
            *
            *si hay una endulzada cercana retorna los dias que faltan para esa endulzada, sino hay una endulzada cercana
            *significa que ya paso la ultima endulzada por lo que retorna el TimeSpan (1,1,1,1) para validar
        */
        public TimeSpan calcProximaEndulzada(DateTime fecha)
        {
            int freqEndulzadas = this.freqEndulzadas;
            int numEndulzadas = this.numEndulzadas;
            DateTime fechaInicial = this.fechaInicio;

            for (int i = 0; i <= numEndulzadas; i++)
            {
                TimeSpan intervaloEndulzada = new TimeSpan (i * freqEndulzadas, 0, 0, 0);
                DateTime endulzadaMasCercana = fechaInicial + intervaloEndulzada;  // recorre todas las fechas de las endulzadas y la primera de la que sea menor es la siguiente endulzada.

                if (fecha < endulzadaMasCercana)
                {
                    TimeSpan diasRestantes = endulzadaMasCercana.Subtract(fecha);
                    return diasRestantes;
                }

            }

            return new TimeSpan(1, 1, 1, 1);

        }

    }
}
