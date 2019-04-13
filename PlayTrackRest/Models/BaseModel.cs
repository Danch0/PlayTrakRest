using log4net;
using System;
using System.Collections;
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
        static ILog log = log4net.LogManager.GetLogger(typeof(BaseModel));
        static Object Generic_object;
        /// <summary>
        /// Crea un objeto del tipo especificado a partir de otro objeto base. Debe concidir tipo y nombre de los parametros de los dos objetos.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto devuelto.</typeparam>
        /// <param name="entity">Objeto base.</param>
        /// <param name="model">Objeto tipado a partir de objeto base.</param>
        /// <returns>Un objeto tipado y creado a partir del objeto base.</returns>
        public static T GetModel<T>(Object entity, Object model)
        {
            if (entity == null)
                return (T)model;
            try
            {
                Type objectType = model.GetType();
                var new_model = Activator.CreateInstance(objectType);
                var modelProperties = model.GetType().GetProperties();
                foreach (var prop in entity.GetType().GetProperties())
                {
                    var thisProp = modelProperties.FirstOrDefault(n => n.Name == prop.Name && n.PropertyType == prop.PropertyType);
                    if (thisProp != null)
                    {
                        var value = prop.GetValue(entity, null);
                        thisProp.SetValue(new_model, value, null);
                    }
                }
                return (T)new_model;
            }
            catch (Exception ex)
            {
                log.Error("Error no manejado.", ex);
            }
            return (T)model;
        }
        /// <summary>
        /// Crear una lista del tipo especificado a partir de otra lista base.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto dentro de la lista devuelta.</typeparam>
        /// <param name="entity_list">Lista base de la que se tomaran los objetos.</param>
        /// <param name="model_list">Lista a la que se agregaran los objtos tipados.</param>
        /// <param name="model">Objeto del cual se tomara el tipo.</param>
        /// <returns>Lita con objetos tipados y creada a partir de la lista base.</returns>
        public static List<T> GetModelList<T>(object entity_list, List<T> model_list, object model)
        {
            if (entity_list == null)
                return (List<T>)model_list;
            try
            {
                IEnumerable enumerable = entity_list as IEnumerable;
                foreach (var item in enumerable)
                {
                    var new_item = GetModel<T>(item, model);
                    if (new_item != null)
                    {
                        model_list.Add(new_item);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error no manejado.", ex);
            }
            return (List<T>)model_list;
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