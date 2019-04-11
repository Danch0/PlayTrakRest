using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    /// <summary>
    /// Representa un modelo generico con metodos comunes de la aplicacion.
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Crea un objeto del tipo especificado a partir de otro objeto base. Debe concidir tipo y nombre de los parametros de los dos objetos.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto devuelto.</typeparam>
        /// <param name="entity">Objeto base</param>
        /// <param name="model">Objeto creado a partir de objeto base</param>
        /// <returns>Un objeto tipado y creado a partir del objeto base.</returns>
        public static T GetModel<T>(Object entity, Object model)
        {
            if (entity == null)
                return (T)model;
            var modelProperties = model.GetType().GetProperties();
            foreach (var prop in entity.GetType().GetProperties())
            {
                var thisProp = modelProperties.FirstOrDefault(n => n.Name == prop.Name && n.PropertyType == prop.PropertyType);
                if (thisProp != null)
                {
                    var value = prop.GetValue(entity, null);
                    thisProp.SetValue(model, value, null);
                }
            }
            return (T)model;
        }
    }
    /// <summary>
    /// Representa la estructura con la que responde la aplicacion.
    /// </summary>
    public class RespuestaBase
    {
        /// <summary>
        /// Mensaje del estatus de la respuesta, en caso de todo estar bien retornara OK.
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Los datos resultantes de la respuesta.
        /// </summary>
        public object Datos { get; set; }
        /// <summary>
        /// Estatus de la respuesta, False -> con error, True -> todo bien.
        /// </summary>
        public bool Estatus { get; set; }
        /// <summary>
        /// Constructor con los datos por defecto.
        /// </summary>
        public RespuestaBase()
        {
            Mensaje = "OK";
            Estatus = true;
            Datos = null;
        }
    }
}