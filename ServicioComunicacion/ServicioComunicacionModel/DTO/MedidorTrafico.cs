using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DTO
{
    public class MedidorTrafico
    {
        private int id;
        private int cod_medidor; //no se encuentra en mi CASO de  USO
        private int cantidadIngreso;

        public MedidorTrafico( int id, int Cod_medidor)
        {
            this.id = id;
            this.Cod_medidor = Cod_medidor;

        }
        public int Id { get => id; set => id = value; }
        public int Cod_medidor { get => cod_medidor; set => cod_medidor = value; }
        public int CantidadIngreso { get => cantidadIngreso; set => cantidadIngreso = value; }

        public override string ToString()
        {
            return Id + ";" + Cod_medidor + ";" + CantidadIngreso;
        }
    }
}