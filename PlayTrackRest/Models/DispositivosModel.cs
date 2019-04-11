using log4net;
using PlayTrackRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    public class DispositivosModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> registro { get; set; }
        public List<ComponentesModel> componentes { get; set; }
        public List<RegistroUsosModel> registro_usos { get; set; }

        static ILog log = log4net.LogManager.GetLogger(typeof(DispositivosModel));

        internal static RespuestaBase ObtenerTodos()
        {
            log.Info("Llamada al metodo");
            RespuestaBase respuesta = new RespuestaBase();
            List<DispositivosModel> datos = new List<DispositivosModel>();
            try
            {
                IEnumerable<DISPOSITIVO> dispositivos = DispositivosRepository.ObtenerTodos();
                foreach (DISPOSITIVO dispositivo in dispositivos)
                {
                    DispositivosModel dispositivo_temp = null;
                    dispositivo_temp = BaseModel.GetModel<DispositivosModel>(dispositivo, new DispositivosModel());
                    if (dispositivo_temp.id != 0)
                    {
                        datos.Add(dispositivo_temp);
                    }
                }
                respuesta.Mensaje = "OK";
                respuesta.Estatus = true;
                respuesta.Datos = datos;
            }
            catch (Exception ex)
            {
                log.Error("ObtenerTodos--> mensage: " + respuesta.Mensaje, ex);
            }
            return respuesta;
        }
    }
}