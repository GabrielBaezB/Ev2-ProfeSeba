using ClienteMedidor.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteMedidor
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            String ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ClienteSocket clienteSocket = new ClienteSocket(ip, puerto);
            Console.WriteLine("Conectandose al servidor {0} en el puerto {1}", ip, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Cliente Conectado");

                int tipo = GetTipo();
                string fecha = GetFecha();
                int nro_medidor = GetNroMedidor();
                string mensaje = fecha + "|" + nro_medidor + "|" + tipo;

                clienteSocket.Escribir(mensaje);
                string mensajeRecibido = clienteSocket.Leer();

                Console.WriteLine(mensajeRecibido);
                if (mensajeRecibido.Equals("Error en la fecha") || mensajeRecibido.Equals("No se encuentra el medidor"))
                {
                    Console.WriteLine("Presione Enter para salir . . .");
                    Console.ReadLine();
                }
                else
                {
                    string[] formatos2 = mensajeRecibido.Split('|');
                    string confPeticion;
                    confPeticion = formatos2[1];
                    if (confPeticion.Equals("WAIT"))
                    {
                        Console.WriteLine("Actualizacion de estado");

                        int nro_serie = GetNroSerie();
                        string fechaAct = GetFecha();
                        int valor = GetValor();
                        int estado = GetEstado();
                        int seleccion = 3;
                        if (estado == 1)
                        {
                            seleccion = GetSeleccion();
                            if (seleccion == -1)
                            {
                                seleccion = -1;
                            }
                            else if (seleccion == 0)
                            {
                                seleccion = 0;
                            }
                            else if (seleccion == 1)
                            {
                                seleccion = 1;
                            }
                            else if (seleccion == 2)
                            {
                                seleccion = 2;
                            }
                        }
                        else if (estado == 2)
                        {
                            estado = 11;
                        }
                        clienteSocket.Escribir(nro_serie + "|" + fecha + "|" + tipo + "|" + valor + "|" + seleccion + "|UPDATE");
                        string confirmacion = clienteSocket.Leer();
                        if (confirmacion != "")
                        {
                            Console.WriteLine(confirmacion);
                            Console.WriteLine("Presione Enter para salir. . .");
                            Console.ReadLine();
                        }
                        else
                        {
                            clienteSocket.Desconectar();
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error de conexion");
            }
        }
    }
}