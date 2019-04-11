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
        /// <returns>Regresa un objeto de la clase RespuestaBase, <see cref="IDocumentationProvider"/> detalles de las clases devueltas.</returns>
        public RespuestaBase Get()
        {
            RespuestaBase respuesta = DispositivosModel.ObtenerTodos();
            return respuesta;
        }
    }
}
