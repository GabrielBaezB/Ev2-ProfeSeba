using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DTO
{
    public class MedidorConsumo
    {
        private int id;
        private int nro_medidor; //no se encuentra en mi CASO de  USO
        private string consumoKwH;
        private string estadoPuntoCarga;
        private string estadoSensores;
        private DateTime fecha;

        public int Id { get => id; set => id = value; }
        public int Nro_medidor { get => nro_medidor; set => nro_medidor = value; }
        public string ConsumoKwH { get => consumoKwH; set => consumoKwH = value; }
        public string EstadoPuntoCarga { get => estadoPuntoCarga; set => estadoPuntoCarga = value; }
        public string EstadoSensores { get => estadoSensores; set => estadoSensores = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }


        public MedidorConsumo(int nro_medidor, int id)
        {
            this.nro_medidor = nro_medidor;
            this.id = id;
        }

        // public Tipo Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return Id +";"+ Nro_medidor;
        }
    }

}
