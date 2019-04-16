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
    /// Controlador para el manejo de los Mesa de black jack.
    /// </summary>
    public class BlackJackController : ApiController
    {
        /// <summary>
        /// Obtiene todos los elementos Mesa de black jack..
        /// </summary>
        /// <returns>Regresa un objeto de la clase RespuestaBase</returns>
        public RespuestaBase Get()
        {
            BlackJack blackjack = new BlackJack();
            RespuestaBase respuesta = blackjack.ObtenerDispositivos();
            return respuesta;
        }
    }
}
