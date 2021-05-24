using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DTO
{
    class Ciudades
    {
        private int codigoPostal;
        private string ciudad;
        private string comuna;
        private string direccion;

        public int CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Comuna { get => comuna; set => comuna = value; }
        public string Direccion { get => direccion; set => direccion = value; }


        public override string ToString()
        {
            return CodigoPostal + ";" + Ciudad + ";" + Comuna + ";" + Direccion;
        }
    }
}
