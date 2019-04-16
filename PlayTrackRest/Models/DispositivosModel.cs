using log4net;
using Newtonsoft.Json;
using PlayTrackRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    /// <summary>
    /// Representa el modelo para el manejo de la tabla DISPOSITIVOS.
    /// </summary>
    public class DispositivosModel
    {
        /// <summary>
        /// Identificador primario del dispositivo.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nombre del dispositivo.
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Fecha y hora en el que se registro el dispositivo.
        /// </summary>
        public Nullable<System.DateTime> registro { get; set; }
        /// <summary>
        /// Representa una coleccion de COMPONENTES del dispositivo
        /// </summary>
        public List<ComponentesModel> Componentes { get; set; }
        /// <summary>
        /// Id del tipo de dispositivo.
        /// </summary>
        public Nullable<int> tipo_id
        {
            get
            {
                return _tipo_id;
            }
            set
            {
                _tipo_id = value;
                this.Tipo = (TiposDispositivo)Enum.ToObject(typeof(TiposDispositivo), _tipo_id);
            }
        }
        /// <summary>
        /// Representa una coleccion de REGISTO_USOS del dispositivo
        /// </summary>
        public List<RegistroUsosModel> Registro_usos { get; set; }
        /// <summary>
        /// Id del tipo de dispositivo.
        /// </summary>
        private Nullable<int> _tipo_id { get; set; }
        /// <summary>
        /// Tipo segun el enum
        /// </summary>
        internal TiposDispositivo Tipo { get; set; }
        /// <summary>
        /// Instancia de la interfas para usar log4net
        /// </summary>
        public static ILog log = log4net.LogManager.GetLogger(typeof(DispositivosModel));
        /// <summary>
        /// Representa el constructor del modelo DispositivosModel.
        /// </summary>
        public DispositivosModel()
        {
            id = 0;
            nombre = null;
            registro = null;
            Componentes = new List<ComponentesModel>();
            Registro_usos = new List<RegistroUsosModel>();
        }
        /// <summary>
        /// Obtiene los n primeros dispositivos.
        /// </summary>
        /// <param name="limit"> Numero de dispositivos a obtener por defecto 1000.</param>
        /// <param name="tipo_dispositivo"> Tipo de dispositivo a obtener por defecto obtiene todos.</param>
        /// <returns>Regresa un objeto de la clase RespuestaBase con una coleccion con los n dispositivos especificado.</returns>
        internal virtual RespuestaBase ObtenerDispositivos(TiposDispositivo tipo_dispositivo = TiposDispositivo.NONE, int limit = 1000)
        {
            return ObtenerDispositivosBase(tipo_dispositivo, limit);
        }
        /// <summary>
        /// Obtiene los n primeros dispositivos.
        /// </summary>
        /// <param name="limit"> Numero de dispositivos a obtener.</param>
        /// <param name="tipo_dispositivo"> Tipo de dispositivo a obtener.</param>
        /// <returns>Regresa un objeto de la clase RespuestaBase con una coleccion con los n dispositivos especificado.</returns>
        internal RespuestaBase ObtenerDispositivosBase(TiposDispositivo tipo_dispositivo, int limit)
        {
            log.Info("Llamada al metodo");
            RespuestaBase respuesta = new RespuestaBase();
            List<DispositivosModel> datos = new List<DispositivosModel>();
            try
            {
                IEnumerable<DISPOSITIVO> dispositivos = DispositivosRepository.ObtenerDispositivos(tipo_dispositivo, limit);
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
                        string mensaje = String.Format("No fue posible procesar dispositivo con ID-->{0}.", dispositivo.id.ToString());
                        respuesta.Mensaje += " " + mensaje;
                        log.Error(mensaje);
                    }
                }
                respuesta.Datos = datos;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje += " " + ex.Message;
                respuesta.Estatus = false;
                log.Error(respuesta.Mensaje, ex);
            }
            return respuesta;
        }
        /// <summary>
        /// Agregar nuevo dispositivo.
        /// </summary>
        /// <param name="dispositivo">Objeto dispositivo del modelo DispositivosModel.</param>
        /// <returns></returns>
        internal RespuestaBase AgregarDispositivo(DispositivosModel dispositivo)
        {
            log.Info("Llamada al metodo");
            RespuestaBase respuesta = new RespuestaBase();
            try
            {
                dispositivo.registro = dispositivo.registro != null ? dispositivo.registro : DateTime.Now;
                DISPOSITIVO new_dispositivo = BaseModel.GetModel<DISPOSITIVO>(dispositivo, new DISPOSITIVO());
                DISPOSITIVO dispositivo_agregado = DispositivosRepository.AgregarDispositivo(new_dispositivo);
                if (dispositivo_agregado != null)
                {
                    respuesta.Datos = dispositivo;

                    if (dispositivo.Componentes.Count > 0)
                    {
                        COMPONENTE componente_agregado = null;
                        foreach (ComponentesModel componenete in dispositivo.Componentes)
                        {
                            COMPONENTE new_componenete = BaseModel.GetModel<COMPONENTE>(componenete, new COMPONENTE());
                            if (new_componenete.nombre != null)
                            {
                                try
                                {
                                    new_componenete.registro = DateTime.Now;
                                    new_componenete.dispositivo_id = new_dispositivo.id;
                                    componente_agregado = ComponentesRepository.AgregarComponente(new_componenete);
                                }
                                catch (Exception ex)
                                {
                                    respuesta.Mensaje += " " + ex.Message;
                                    log.Error(respuesta.Mensaje, ex);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje += " " + ex.Message;
                respuesta.Estatus = false;
                log.Error(respuesta.Mensaje, ex);
            }
            return respuesta;
        }

    }
}