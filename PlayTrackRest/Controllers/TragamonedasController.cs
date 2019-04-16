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
    /// Controlador para el manejo de los tragamonedas.
    /// </summary>
    public class TragamonedasController : ApiController
    {
        /// <summary>
        /// Obtiene todos los elementos tragamonedas.
        /// </summary>
        /// <returns>Regresa un objeto de la clase RespuestaBase</returns>
        public RespuestaBase Get()
        {
            Tragamonedas tragamonedas = new Tragamonedas();
            RespuestaBase respuesta = tragamonedas.ObtenerDispositivos();
            return respuesta;
        }
    }
}
