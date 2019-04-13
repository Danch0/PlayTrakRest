using log4net;
using Newtonsoft.Json;
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
        public List<ComponentesModel> Componentes { get; set; }
        public List<RegistroUsosModel> Registro_usos { get; set; }

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
                    DispositivosModel dispositivo_temp = BaseModel.GetModel<DispositivosModel>(dispositivo, new DispositivosModel());
                    List<ComponentesModel> componentes = new List<ComponentesModel>();
                    List<RegistroUsosModel> registros = new List<RegistroUsosModel>();

                    if (dispositivo_temp.id != 0)
                    {
                        if (dispositivo.COMPONENTES != null)
                        {
                            dispositivo_temp.Componentes = BaseModel.GetModelList<ComponentesModel>(dispositivo.COMPONENTES, new List<ComponentesModel>(), new ComponentesModel());
                            //foreach (COMPONENTE componente in dispositivo.COMPONENTES)
                            //{
                            //    ComponentesModel componente_temp = BaseModel.GetModel<ComponentesModel>(componente, new ComponentesModel());
                            //    if (componente_temp.id != 0)
                            //    {
                            //        componentes.Add(componente_temp);
                            //    }
                            //}
                        }
                        if (dispositivo.REGISROS_USOS != null)
                        {
                            dispositivo_temp.Registro_usos = BaseModel.GetModelList<RegistroUsosModel>(dispositivo.REGISROS_USOS, new List<RegistroUsosModel>(), new RegistroUsosModel());
                            //foreach (REGISROS_USOS registro in dispositivo.REGISROS_USOS)
                            //{
                            //    RegistroUsosModel registro_temp = BaseModel.GetModel<RegistroUsosModel>(registro, new RegistroUsosModel());
                            //    if (registro_temp.id != 0)
                            //    {
                            //        registros.Add(registro_temp);
                            //    }
                            //}
                        }
                        datos.Add(dispositivo_temp);
                    }
                    else
                    {
                        log.Error("No fue posible procesar dispositivo con ID-->" + dispositivo.id.ToString());
                        return respuesta;
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