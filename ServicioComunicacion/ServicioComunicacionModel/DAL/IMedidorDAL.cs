using ServicioComunicacionModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAL
{
    public interface IMedidorDAL
    {
       
        List<MedidorConsumo> ConsumoGetAll();
        List<MedidorTrafico> TraficoGetAll();
        
        List<ControladorMedicion> ObtenerLecturasTrafico();
        List<ControladorMedicion> ObtenerLecturasConsumo();
        void RegistrarMedicion(ControladorMedicion l, string archivo);

    }
}
