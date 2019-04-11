using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PlayTrackRest.Controllers
{
    /// <summary>
    /// Clase que manejara la informacion correspondiente a los dispositivos
    /// </summary>
    public class DispositivosController : ApiController
    {
        public string Get()
        {
            string respuesta = "Hola mundo";
            return respuesta;
        }
    }
}
