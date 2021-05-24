using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAL
{
    public class MedidorDALFactory
    {
        //Se guarda la instancia
        public static IMedidorDAL CreateDal()
        {
            return MedidorDALArchivos.GetInstance();
        }

    }
}
