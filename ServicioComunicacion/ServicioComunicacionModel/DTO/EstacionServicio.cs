using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DTO
{
    class EstacionServicio
    {
        private int capacidadMAxima;
        private DateTime horario;

        public int CapacidadMAxima { get => capacidadMAxima; set => capacidadMAxima = value; }
        public DateTime Horario { get => horario; set => horario = value; }

        public override string ToString()
        {
            return CapacidadMAxima + ";" + Horario;
        }
    }
}
