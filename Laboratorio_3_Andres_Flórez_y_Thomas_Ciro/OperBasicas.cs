using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using System.Windows.Forms;

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

        public bool crearArchivo(String nombre)
        {
            String ruta = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine("Directorio actual: " + ruta);
            ruta = ruta + @"\" + nombre + ".txt";

            try
            {
                using(FileStream fs = File.Create(ruta))
                {
                    byte[] texto = new UTF8Encoding(true).GetBytes("Nuevo Juego Creado");
                    // Add some information to the file.
                    fs.Write(texto, 0, texto.Length);
                    fs.Close();
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool escribirLinea(String nombreArchivo, String linea)
        {
            String ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta + @"\" + nombreArchivo + ".txt";

            try
            {
                using(StreamWriter sw = File.AppendText(ruta)) 
                { 
                    sw.WriteLine(linea);
                }
             
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool sobreEscribirLinea(String nombreArchivo, String lineaNUeva, int pos)
        {
            String nombreCopia = nombreArchivo + "Copia";
            String ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta + @"\" + nombreArchivo + ".txt";
            if (crearArchivo(nombreCopia))
            {
                try
                {
                    using (StreamReader sr = File.OpenText(ruta))
                    {
                        String linea = "";
                        int i = 0;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            if (i == pos)
                            {
                                escribirLinea(nombreArchivo, lineaNUeva);
                            }
                            else
                            {
                                escribirLinea(nombreArchivo, linea);
                            }
                        }
                        sr.Close();
                    }
                    String rutaCopia = System.IO.Directory.GetCurrentDirectory();
                    rutaCopia = rutaCopia + @"\" + nombreCopia + "0.txt";
                    File.Copy(rutaCopia, ruta);
                    File.Delete(rutaCopia);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public String leerLinea(String nombreArchivo) 
        {
            String ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta + @"\" + nombreArchivo + ".txt";

            try
            {
                using(StreamReader sr = File.OpenText(ruta))
                {
                    String linea = "";
                    linea = sr.ReadLine();
                    return linea;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public String[] leerArchivo(String nombreArchivo)
        {
            String ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta + @"\" + nombreArchivo + ".txt";

            try
            {
                String[] result = File.ReadAllLines(ruta);
                return result;
            }
            catch
            {
                return null;
            }

        }

        public void mensajeEmergente(String titulo, String mensaje) {
            MessageBoxButtons buttons;
            buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(mensaje, titulo, buttons);
            Console.WriteLine("ingreso al texto");
        }


        public Boolean validarFecha(DateTime fechaInicio, DateTime fechaFin, int frecEndulzada, int numEndulzadas) {
            TimeSpan peridoEndulzada = new TimeSpan(frecEndulzada*numEndulzadas,0,0,0);
            DateTime ultimaendulzada = fechaInicio + peridoEndulzada;

            Console.WriteLine("validacion 1"+(fechaFin <= fechaInicio));
            Console.WriteLine("validacion 2" + (fechaFin <= DateTime.Today));
            Console.WriteLine("validacion 3" + (fechaInicio < DateTime.Today));
            Console.WriteLine("validacion 4" + (fechaFin < ultimaendulzada));

            if (fechaFin <= fechaInicio || fechaFin <= DateTime.Today || fechaInicio < DateTime.Today || fechaFin < ultimaendulzada)
            {
                return false;
            }
            Console.WriteLine("buena validaciones es true");
            return true;
        }

        public Boolean validarIntPositivo(String num) {
            int x = 0;
            if (int.TryParse(num, out x)) {
                int valor = int.Parse(num);
                if (valor <= 0)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }


}
