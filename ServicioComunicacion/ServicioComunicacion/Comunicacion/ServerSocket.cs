using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacion.Comunicacion
{
    class ServerSocket

    {
        private int puerto;
        private Socket servidor;
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;

        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        public void Iniciar()
        {
            try
            {
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));

                this.servidor.Listen(10);

            }
            catch (Exception ex)
            {
            }

        }
        /*Obtiene el cliente*/
        public bool ObtenerCliente()
        {
            try
            {
                this.comCliente = this.servidor.Accept();

                Stream stream = new NetworkStream(this.comCliente);
                this.writer = new StreamWriter(stream);
                this.reader = new StreamReader(stream);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool Escribir(String mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (IOException ex)
            {

                return false;
            }

        }

        public String Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (IOException ex)
            {
                return null;
            }

        }
        public void CerrarConexion()
        {
            this.comCliente.Close();

        }
    }
}