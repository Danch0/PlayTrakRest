using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    /// <summary>
    /// Representa la clase para el manejo de Mesas de BlckJack.
    /// </summary>
    public class BlackJack : DispositivosModel
    {
        /// <summary>
        /// Instancia de la interfas para usar log4net
        /// </summary>
        public static new ILog log = log4net.LogManager.GetLogger(typeof(BlackJack));
        /// <summary>
        /// Obtiene los n primeros Mesa de BlackJack.
        /// </summary>
        /// <param name="limit"> Numero de dispositivos a obtener por defecto 1000.</param>
        /// <param name="tipo_dispositivo"> Tipo de dispositivo a obtener por defecto obtiene solo Mesa de BlackJack.</param>
        /// <returns>Regresa un objeto de la clase RespuestaBase con una coleccion con los n dispositivos especificado.</returns>
        internal override RespuestaBase ObtenerDispositivos(TiposDispositivo tipo_dispositivo = TiposDispositivo.MESA_DE_BLACKJACK, int limit = 1000)
        {
            log.Info("Llamada al metodo");
            return ObtenerDispositivosBase(tipo_dispositivo, limit);
        }
    }
}