using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    /// <summary>
    /// Representa el modelo para el manejo de la tabla COMPONENTES.
    /// </summary>
    public class ComponentesModel
    {
        /// <summary>
        /// Identificador primario del componente.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nombre del componente.
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Descripcion del componente.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Fecha y hora en el que se registro el componente.
        /// </summary>
        public Nullable<System.DateTime> registro { get; set; }
        /// <summary>
        /// LLave foranea del dispositivo al que pertenece el componente.
        /// </summary>
        public Nullable<int> dispositivo_id { get; set; }
    }
}