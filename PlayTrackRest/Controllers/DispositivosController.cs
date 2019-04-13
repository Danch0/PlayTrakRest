﻿using PlayTrackRest.Models;
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
        public RespuestaBase GetDispositivos()
        {
            DispositivosModel Dispositivos = new DispositivosModel();
            RespuestaBase respuesta = Dispositivos.ObtenerTodos();
            return respuesta;
        }
    }
}
