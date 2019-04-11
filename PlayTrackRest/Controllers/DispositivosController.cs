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
    /// Clase que manejara la informacion correspondiente a los dispositivos
    /// </summary>
    public class DispositivosController : ApiController
    {
        /// <summary>
        /// Obtiene todos los elementos de Dispositivos
        /// </summary>
        /// <returns>Regresa un json con la estructura de la clase response, donde data el un arreglo con todos los elementos de Dispositivos</returns>
        public IHttpActionResult Get()
        {
            RespuestaBase respuesta = DispositivosModel.ObtenerTodos();
            return Json(new { respuesta });
        }
    }
}
