using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel
{
   public class ControladorMedicion
    {
        private string nroSerie;
        private DateTime fecha;
        private int tipo;
        private string valor;
        private string estado;
       
        public string NroSerie { get => nroSerie; set => nroSerie = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Estado { get => estado; set => estado = value; }



    }
}
