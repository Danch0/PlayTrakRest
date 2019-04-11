using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    public class BaseModel
    {
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

    public class RespuestaBase
    {
        public string mensaje { get; set; }
        public object datos { get; set; }
        public bool estatus { get; set; }

        public RespuestaBase()
        {
            mensaje = "Error no manejado";
            datos = null;
            estatus = false;
        }
    }
}