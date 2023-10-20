using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Andres_Flórez_y_Thomas_Ciro
{
    internal class Jugador
    {
        String nombre;
        String correo;
        String endulzadaIdeal;
        String regaloIdeal;
        Jugador amigoSecreto;

        public  Jugador()
        {
            nombre = "Sin asignar";
            correo = "Sin asignar";
            endulzadaIdeal = "Sin asignar";
            regaloIdeal = "Sin asignar";
        }

        public Jugador(string nombre, string correo, string endulzadaIdeal,
            string regaloIdeal)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.endulzadaIdeal = endulzadaIdeal;
            this.regaloIdeal = regaloIdeal;
        }

        public String getNombre()
        {
            return nombre;
        }

        public String getCorreo()
        {
            return correo;
        }
        public String getEndulzadaIdeal()
        {
            return endulzadaIdeal;
        }

        public String getRegaloIdeal()
        {
            return regaloIdeal;
        }

        public Jugador getAmigoSecreto()
        {
            return amigoSecreto;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void setCorreo(String correo)
        {
            this.correo = correo;
        }

        public void setEndulzadaIdeal(String endulzadaIdeal)
        {
            this.endulzadaIdeal = endulzadaIdeal;
        }

        public void setRegaloIdeal(String regaloIdeal)
        {
            this.regaloIdeal = regaloIdeal;
        }

        public void setAmigoSecreto(Jugador amigoSecreto)
        {
            this.amigoSecreto = amigoSecreto;
        }

        public String[] mostrarDatos()
        {
            String[] datos = new string[5];
            datos[0] = "Nombre: " + this.nombre;
            datos[1] = "Correo: " + this.correo;
            datos[2] = "Endulzada ideal: " + this.endulzadaIdeal;
            datos[3] = "Regalo ideal: " + this.regaloIdeal;
            datos[4] = "Tiene como amigo a: " + this.amigoSecreto.getNombre();
            return datos;
        }

    }
}
