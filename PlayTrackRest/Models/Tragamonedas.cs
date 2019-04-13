using log4net;
using PlayTrackRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    /// <summary>
    /// Representa la clase para el manejo de Tragamonedas.
    /// </summary>
    public class Tragamonedas : DispositivosModel
    {
        /// <summary>
        /// Instancia de la interfas para usar log4net
        /// </summary>
        public static new ILog log = log4net.LogManager.GetLogger(typeof(Tragamonedas));
        /// <summary>
        /// Obtiene los n primeros tragamonedas.
        /// </summary>
        /// <param name="limit"> Numero de dispositivos a obtener por defecto 1000.</param>
        /// <param name="tipo_dispositivo"> Tipo de dispositivo a obtener por defecto obtiene solo tragamonedas.</param>
        /// <returns>Regresa un objeto de la clase RespuestaBase con una coleccion con los n dispositivos especificado.</returns>
        internal override RespuestaBase ObtenerTodos(TiposDispositivo tipo_dispositivo = TiposDispositivo.TRAGAMONEDAS, int limit = 1000)
        {
            log.Info("Llamada al metodo");
            return ObtenerTodosBase(tipo_dispositivo, limit);
        }
    }
}