using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Andres_Flórez_y_Thomas_Ciro
{
    internal class OperBasicas
    {
        public void DesordenarVector<T>(IList<T> vector)
        {
            int longitud = vector.Count;
            Random generador = new Random();
            for (int i = 0; i < longitud; i++) 
            {
                int j = generador.Next(0, longitud);
                var aux = vector[i];
                vector[i] = vector[j];
                vector[j] = aux;
            }
        }

        public int[] AsignarLongSubGrupos(int longGrupo, int cantSubGrupos)
        {
            if(cantSubGrupos == 1)
            {
                int[] result = new int[1];
                result[0] = longGrupo;
                return result;
            }
            int maxCantSubGrupos = longGrupo / 2;
            int maxLongSubGrupo = (maxCantSubGrupos - cantSubGrupos + 1) * 2;
            if(longGrupo % 2 == 1)
            {
                maxLongSubGrupo++;
            }
            Random generador = new Random();
            int[] asignacion = new int[cantSubGrupos];
            asignacion[0] = generador.Next(2, maxLongSubGrupo+1);
            int longSubVector = longGrupo - asignacion[0];
            int[] subVector = new int[longSubVector];
            int[] subAsignacion = new int[cantSubGrupos-1];
            subAsignacion = AsignarLongSubGrupos(longSubVector, cantSubGrupos - 1);
            for(int i = 1; i < cantSubGrupos; i++)
            {
                asignacion[i] = subAsignacion[i - 1];
            }
            return asignacion;
        }
    }


}
