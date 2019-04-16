using log4net;
using PlayTrackRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Repositories
{
    /// <summary>
    /// Representa una coleccion de metodos para el manejo de la tabla DISPOSITIVOS.
    /// </summary>
    public class DispositivosRepository
    {
        /// <summary>
        /// Instancia de la interfas para usar log4net
        /// </summary>
        public static ILog log = log4net.LogManager.GetLogger(typeof(DispositivosModel));
        /// <summary>
        /// Obtiene los n primeros dispositivos.
        /// </summary>
        /// <param name="limit"> Numero de dispositivos a obtener por defecto 1000.</param>
        /// <param name="tipo_dispositivo"> Tipo de dispositivo a obtener por defecto obtiene todos.</param>
        /// <returns>Coleccion con los n dispositivos especificado.</returns>
        internal static IEnumerable<DISPOSITIVO> ObtenerTodos(TiposDispositivo tipo_dispositivo = TiposDispositivo.NONE, int limit = 1000)
        {
            using (play0dbEntities dbEntities = new play0dbEntities())
            {
                if (tipo_dispositivo != TiposDispositivo.NONE)
                {
                    return (from dispositivos in dbEntities.DISPOSITIVOS
                            orderby dispositivos.id descending
                            where dispositivos.tipo_id == tipo_dispositivo.GetHashCode()
                            select dispositivos).Skip(limit).Take(limit);
                }
                return (from dispositivos in dbEntities.DISPOSITIVOS
                        orderby dispositivos.id descending
                        select dispositivos).Skip(limit).Take(limit);
            }
        }
        /// <summary>
        /// Agrega nuevo dispositivo.
        /// </summary>
        /// <param name="new_dispositivo">Nuevo objeto dispositivo de la tabla DISPOSITIVOS</param>
        /// <returns></returns>
        internal static DISPOSITIVO AgregarDispositivo(DISPOSITIVO new_dispositivo)
        {
            log.Info("Llamada al metodo");
            using (play0dbEntities dbEntities = new play0dbEntities())
            {
                DISPOSITIVO existe_dispositivo = dbEntities.DISPOSITIVOS.Where(x => x.nombre == new_dispositivo.nombre).Select(s => s).FirstOrDefault();

                if (existe_dispositivo != null)
                {
                    throw new ArgumentException(string.Format("Ya existe un dispositivo con el nombre {0}", new_dispositivo.nombre));
                }
                dbEntities.DISPOSITIVOS.Add(new_dispositivo);
                dbEntities.SaveChanges();

                if (new_dispositivo.id != 0)
                {
                    return new_dispositivo;
                }
                else
                    throw new Exception(string.Format("No fue posible guardar un nuevo dispositivo {0}.", new_dispositivo.nombre));
            }
        }
    }
}