using ServicioComunicacionModel.DAL;
using ServicioComunicacionModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacion
{
    public partial class Program
    {
            
        static IMedidorDAL dal = MedidorDALFactory.CreateDal();

        static Boolean validadorFecha(string fecha)
        {
            DateTime fechaFormat = DateTime.Parse(fecha);
            TimeSpan diferencia = fechaFormat - DateTime.Now;
            double diferenciaMinutos = diferencia.TotalMinutes;
            double diferenciaMinutosPos = Math.Abs(diferenciaMinutos);
            if (diferenciaMinutosPos > 30)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        static Boolean validarNroMTrafico(string cod_medidor)
        {
            string codigo = cod_medidor;
            MedidorTrafico mt = dal.TraficoGetAll().Find(m => m.Cod_medidor == codigo);
            if (mt != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Boolean validarNroMConsumo(string nro_medidor)
        {
            int nro_medidorInt = int.Parse(nro_medidor);
            MedidorConsumo me = dal.ConsumoGetAll().Find(m => m.Nro_medidor == nro_medidorInt);
            if (me != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Boolean ValidarNroSerieConsumo(string nroSerie)
        {
            int nroSerieInt = int.Parse(nroSerie);
            MedidorConsumo me = dal.ConsumoGetAll().Find(m => m.Id == nroSerieInt);
            if (me != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Boolean ValidarNroSerieTrafico(String nroSerie)
        {
            int nroSerieInt = int.Parse(nroSerie);
            MedidorTrafico me = dal.TraficoGetAll().Find(m => m.Id == nroSerieInt);
            if (me != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string EstadoToString(string estado)
        {
            int estadoInt = int.Parse(estado);
            if (estadoInt == -1)
            {
                return "Error de lectura";
            }
            else if (estadoInt == 0)
            {
                return "OK";
            }
            else if (estadoInt == 1)
            {
                return "Punto de carga lleno";
            }
            else if (estadoInt == 2)
            {
                return "Requiere mantención preventiva";
            }
            else if (estadoInt == 11)
            {
                return "";
            }
            return null;
        }
    }
}