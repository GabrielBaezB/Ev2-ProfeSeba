using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicioComunicacionModel.DTO;


namespace ServicioComunicacionModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {
        private MedidorDALArchivos()
        {
        }

        private static IMedidorDAL instancia;

        public static IMedidorDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MedidorDALArchivos();
            return instancia;
        }

        public List<MedidorConsumo> ConsumoGetAll()
        {
            List<MedidorConsumo> medidoresConsumo = new List<MedidorConsumo>();
            MedidorConsumo m1 = new MedidorConsumo(1, 11100);
            MedidorConsumo m2 = new MedidorConsumo(2, 22200);
            MedidorConsumo m3 = new MedidorConsumo(3, 33300);
            MedidorConsumo m4 = new MedidorConsumo(4, 44400);
            medidoresConsumo.Add(m1);
            medidoresConsumo.Add(m2);
            medidoresConsumo.Add(m3);
            medidoresConsumo.Add(m4);
            return medidoresConsumo;
      }

        public List<MedidorTrafico> TraficoGetAll()
        {
            List<MedidorTrafico> medidoresTrafico = new List<MedidorTrafico>();
            MedidorTrafico m1 = new MedidorTrafico(1, "V01");
            MedidorTrafico m2 = new MedidorTrafico(2, "V02");
            MedidorTrafico m3 = new MedidorTrafico(3, "V03");
            MedidorTrafico m4 = new MedidorTrafico(4, "V04");
            medidoresTrafico.Add(m1);
            medidoresTrafico.Add(m2);
            medidoresTrafico.Add(m3);
            medidoresTrafico.Add(m4);
            return medidoresTrafico; ;
        }
        List<ControladorMedicion> medidores = new List<ControladorMedicion>();

     
        public List<ControladorMedicion> ObtenerLecturasConsumo()
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivoConsumo))
                {
                    String texto = null;

                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            String[] textoArray = texto.Split('|');
                            ControladorMedicion l = new ControladorMedicion()
                            {
                                NroSerie = textoArray[0],
                                Fecha = Convert.ToDateTime(textoArray[1]),
                                Tipo = int.Parse(textoArray[2]),
                                Valor = textoArray[3],
                                Estado = textoArray[4]


                            };
                            medidores.Add(l);

                        }


                    } while (texto != null);
                }


            }
            catch (Exception)
            {

                medidores = null;
            }
            return medidores;
        }

        public List<ControladorMedicion> ObtenerLecturasTrafico()
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivoConsumo))
                {
                    String texto = null;

                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            String[] textoArray = texto.Split('|');
                            ControladorMedicion l = new ControladorMedicion()
                            {
                                NroSerie = textoArray[0],
                                Fecha = Convert.ToDateTime(textoArray[1]),
                                Tipo = int.Parse(textoArray[2]),
                                Valor = textoArray[3],
                                Estado = textoArray[4]


                            };
                            medidores.Add(l);

                        }


                    } while (texto != null);
                }


            }
            catch (Exception)
            {

                medidores = null;
            }
            return medidores;
        }

        public void RegistrarMedicion(ControladorMedicion l, string archivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(l);
                    writer.Flush();

                }
                string json = JsonConvert.SerializeObject(l);
                File.WriteAllText(archivo, json);


            }
            catch (IOException ex)
            {


            }
        }

        private string archivoTrafico = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "traficos.txt";
        private string archivoConsumo = Directory.GetCurrentDirectory()
        + Path.DirectorySeparatorChar + "consumos.txt";
    }
}
