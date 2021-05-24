using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteMedidor
{
    public partial class Program
    {
        public static int GetTipo()
        {
            int aux = -1;
            do
            {
                Console.WriteLine("Ingrese tipo de medidor");
                Console.WriteLine("1. Trafico");
                Console.WriteLine("2. Consumo");
                if (!int.TryParse(Console.ReadLine().Trim(), out aux))
                {
                    Console.WriteLine("El tipo debe ser numerico");
                    aux = -1;
                }
                else if (aux != 1 && aux != 2)
                {
                    Console.WriteLine("El tipo deber ser 1 o 2");
                    aux = -1;
                }

            } while (aux != 1 && aux != 2);
            return aux;

        }
        public static string GetFecha()
        {
            string fecha;
            string años = "";
            string meses = "";
            string dias = "";
            string horas = "";
            string minutos = "";
            string segundos = "";
            int mesesint = -1;
            int diasint = -1;
            int horasint = -1;
            int minutosint = -1;
            int segundosint = -1;
            do
            {
                Console.WriteLine("Ingrese Fecha en formato yyyy-MM-dd-HH-mm-ss");
                string fechaFormat = Console.ReadLine().Trim();
                string[] formatos = fechaFormat.Split('-');
                try
                {
                    años = formatos[0];
                    meses = formatos[1];
                    dias = formatos[2];
                    horas = formatos[3];
                    minutos = formatos[4];
                    segundos = formatos[5];
                    fecha = años + "-" + meses + "-" + dias + " " + horas + ":" + minutos + ":" + segundos;
                    mesesint = int.Parse(meses);
                    diasint = int.Parse(dias);
                    horasint = int.Parse(horas);
                    minutosint = int.Parse(minutos);
                    segundosint = int.Parse(segundos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ingrese fecha en formato requerido");
                    fecha = null;
                }

            } while (fecha == null || años.Length != 4 || meses.Length != 2 || dias.Length != 2
            || horas.Length != 2 || minutos.Length != 2 || segundos.Length != 2 || mesesint > 12
            || diasint > 31 || horasint > 23 || minutosint > 59 || segundosint > 59);
            return fecha;
        }

        public static int GetNroMedidor()
        {
            int aux = -1;
            do
            {
                Console.WriteLine("Ingrese numero de Medidor");
                if (!int.TryParse(Console.ReadLine().Trim(), out aux))
                {
                    Console.WriteLine("El numero del medidor debe ser numerico");
                    aux = -1;
                }
                else if (aux < 0 || aux > 9)
                {
                    Console.WriteLine("El numero del medidor es de largo 1");
                    aux = -1;
                }
            } while (aux == -1);
            return aux;
        }

        public static int GetNroSerie()
        {
            int aux = -1;
            do
            {
                Console.WriteLine("Ingresar Numero de Serie");
                if (!int.TryParse(Console.ReadLine().Trim(), out aux))
                {
                    Console.WriteLine("El numero de serie debe ser numerico");
                    aux = -1;
                }
            } while (aux == -1);
            return aux;
        }
        public static int GetValor()
        {
            int aux = -1;
            do
            {
                Console.WriteLine("Ingresar valor");
                if (!int.TryParse(Console.ReadLine().Trim(), out aux))
                {
                    Console.WriteLine("El valor debe ser numerico");
                    aux = -1;
                }
                else if (aux < 0 || aux > 1000)
                {
                    Console.WriteLine("El valor debe ser entre 0 y 1000");
                    aux = -1;
                }

            } while (aux == -1);
            return aux;
        }

        public static int GetEstado()
        {
            int aux = -1;
            do
            {
                Console.WriteLine("¿Ingresar Estado?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");
                if (!int.TryParse(Console.ReadLine().Trim(), out aux))
                {
                    Console.WriteLine("La confirmacion debe ser numerica");
                    aux = -1;
                }
                else if (aux != 1 && aux != 2)
                {
                    Console.WriteLine("La confirmacion debe ser 1 o 2");
                    aux = -1;
                }

            } while (aux == -1);
            return aux;
        }

        public static int GetSeleccion()
        {
            int aux = -2;
            do
            {
                Console.WriteLine("Seleccione estado");
                Console.WriteLine("-1. Error de lectura");
                Console.WriteLine("0. OK");
                Console.WriteLine("1. Punto de carga lleno");
                Console.WriteLine("2. Requiere mantencion preventiva");
                if (!int.TryParse(Console.ReadLine().Trim(), out aux))
                {
                    Console.WriteLine("El Estado debe ser numerico");
                    aux = -2;
                }
                else if (aux != -1 && aux != 0 && aux != 1 && aux != 2)
                {
                    Console.WriteLine("Debe seleccionar un estado de la lista");
                    aux = -2;
                }


            } while (aux == -2);
            return aux;
        }
    }
}