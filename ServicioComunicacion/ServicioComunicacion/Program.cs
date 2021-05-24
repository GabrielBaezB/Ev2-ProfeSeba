using ServicioComunicacion.Comunicacion;
using ServicioComunicacionModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacion
{
    public partial class Program
    {
        static void Main(string[] args)
        {

            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            Thread t = new Thread(new ThreadStart(servidor.Iniciar));

            t.IsBackground = true;

            t.Start();
            {
                while (true)
                {
                    if (servidor.ObtenerCliente())
                    {
                        Console.WriteLine("Solicitud recibida!");
                        string mensaje = "";
                        {
                            mensaje = servidor.Leer();

                            string[] formatMensaje = mensaje.Split('|');
                            string fecha, nro_medidor;
                            string tipo;
                            fecha = formatMensaje[0];
                            nro_medidor = formatMensaje[1];
                            tipo = formatMensaje[2];
                            int tipoInt = int.Parse(tipo);
                            if (tipoInt == 1)
                            {
                                if (validadorFecha(fecha) && validarNroMTrafico(nro_medidor))
                                {
                                    servidor.Escribir(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");
                                    string actualizacion = servidor.Leer();
                                    Console.WriteLine(actualizacion);
                                    string[] formatActua = actualizacion.Split('|');
                                    string nro_Serie, fechaL, tipoL, valor, estado;
                                    nro_Serie = formatActua[0];
                                    fechaL = formatActua[1];
                                    DateTime fechatra = Convert.ToDateTime(fechaL);
                                    tipoL = formatActua[2];
                                    valor = formatActua[3];
                                    estado = formatActua[4];
                                    if (ValidarNroSerieTrafico(nro_Serie))
                                    {
                                        ControladorMedicion l = new ControladorMedicion()
                                        {
                                            NroSerie = nro_Serie,
                                            Fecha = fechatra,
                                            Tipo = tipoInt,
                                            Valor = valor + " vehículos",
                                            Estado = EstadoToString(estado)

                                        };
                                        lock (dal)
                                        {
                                            dal.RegistrarMedicion(l, "traficos.txt");
                                        }
                                        servidor.Escribir("");
                                    }
                                    else
                                    {
                                        servidor.Escribir(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + nro_Serie + "|ERROR");
                                    }
                                }
                                else
                                {
                                    if (validadorFecha(fecha) == false)
                                    {
                                        servidor.Escribir("Error en la fecha");
                                    }
                                    else if (validarNroMConsumo(nro_medidor) == false)
                                    {
                                        servidor.Escribir("No se encuentra el medidor");
                                    }
                                }
                            }
                            else if (tipoInt == 2)
                            {
                                if (validadorFecha(fecha) && validarNroMConsumo(nro_medidor))
                                {
                                    servidor.Escribir(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");
                                    string actualizacion = servidor.Leer();
                                    Console.WriteLine(actualizacion);
                                    string[] formatActua = actualizacion.Split('|');
                                    string nro_Serie, fechaL, tipoL, valor, estado;
                                    nro_Serie = formatActua[0];
                                    fechaL = formatActua[1];
                                    DateTime fechaCon = Convert.ToDateTime(fechaL);
                                    tipoL = formatActua[2];
                                    valor = formatActua[3];
                                    estado = formatActua[4];
                                    if (ValidarNroSerieConsumo(nro_Serie))
                                    {
                                        ControladorMedicion l = new ControladorMedicion()
                                        {
                                            NroSerie = nro_Serie,
                                            Fecha = fechaCon,
                                            Tipo = tipoInt,
                                            Valor = valor + " Kwh consumidos",
                                            Estado = EstadoToString(estado)
                                        };
                                        lock (dal)
                                        {
                                            dal.RegistrarMedicion(l, "consumos.txt");
                                        }
                                        servidor.Escribir("");
                                    }
                                    else
                                    {
                                        servidor.Escribir(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + nro_Serie + "|ERROR");
                                    }

                                }
                                else
                                {
                                    if (validadorFecha(fecha) == false)
                                    {
                                        servidor.Escribir("Error en la fecha");
                                    }
                                    else if (validarNroMConsumo(nro_medidor) == false)
                                    {
                                        servidor.Escribir("No se encuentra el medidor");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
