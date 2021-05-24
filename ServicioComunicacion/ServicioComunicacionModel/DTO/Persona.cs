using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DTO
{
    class Persona
    {
        private string rut;
        private string nombre, apellido, direccion;
        private int telefono;

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }


        public override string ToString()
        {
            return Rut  + ";" + Nombre + ";" + Apellido + ";" + Direccion + ";" + Telefono;
        }
    }
}
