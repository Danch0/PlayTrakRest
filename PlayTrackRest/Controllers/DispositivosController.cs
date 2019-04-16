using PlayTrackRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayTrackRest.Controllers
{
    /// <summary>
    /// Controlador para el manejo de los dispositivos.
    /// </summary>
    public class DispositivosController : ApiController
    {
        /// <summary>
        /// Obtiene todos los elementos dispositivos.
        /// </summary>
        /// <returns>Regresa un objeto de la clase RespuestaBase</returns>
        public RespuestaBase Get()
        {
            DispositivosModel Dispositivos = new DispositivosModel();
            RespuestaBase respuesta = Dispositivos.ObtenerDispositivos();
            return respuesta;
        }
        /// <summary>
        /// Agregar nuevo dispositivo.
        /// </summary>
        /// <returns>Regresa un objeto de la clase RespuestaBase</returns>
        [AcceptVerbs("POST")]
        public RespuestaBase Post(DispositivosModel dispositivo)
        {
            DispositivosModel dispositivos = new DispositivosModel();
            RespuestaBase respuesta = dispositivos.AgregarDispositivo(dispositivo);
            return respuesta;
        }
    }
}
