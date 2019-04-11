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
            RespuestaBase respuesta = new RespuestaBase();
            DispositivosModel datos = new DispositivosModel();
            try
            {
                IQueryable<DISPOSITIVO> dispositivos = DispositivosRepository.ObtenerTodos();
                datos = BaseModel.GetModel<DispositivosModel>(dispositivos, new DispositivosModel());
                respuesta.datos = datos;
            }
            catch (Exception ex)
            {
                log.Error("ObtenerTodos--> mensage: " + ex.Message);
            }
            return respuesta;
        }
    }
}