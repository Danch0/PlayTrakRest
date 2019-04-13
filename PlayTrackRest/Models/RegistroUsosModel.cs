using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    /// <summary>
    /// Representa el modelo para el manejo de la tabla DISPOSITIVOS.
    /// </summary>
    public class RegistroUsosModel
    {
        /// <summary>
        /// Identificador primario del componente.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Fecha y hora a la que inicio a ser utilizar el dispositivo.
        /// </summary>
        public Nullable<System.DateTime> dt_inicio { get; set; }
        /// <summary>
        /// Fecha y hora a la que termino de ser utilizar el dispositivo.
        /// </summary>
        public Nullable<System.DateTime> dt_fin { get; set; }
        /// <summary>
        /// LLave foranea del dispositivo al que pertenece el resitro de uso.
        /// </summary>
        public Nullable<int> dispositivo_id { get; set; }
    }
}