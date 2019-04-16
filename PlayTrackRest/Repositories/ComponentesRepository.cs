using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Repositories
{
    /// <summary>
    /// Representa una coleccion de metodos para el manejo de la tabla COMPONENTES.
    /// </summary>
    public class ComponentesRepository
    {
        /// <summary>
        /// Instancia de la interfas para usar log4net
        /// </summary>
        public static ILog log = log4net.LogManager.GetLogger(typeof(ComponentesRepository));
        /// <summary>
        /// Agrega nuevo componente.
        /// </summary>
        /// <param name="new_componente">Nuevo objeto componente de la tabla COMPONENTES</param>
        /// <returns></returns>
        internal static COMPONENTE AgregarComponente(COMPONENTE new_componente)
        {
            log.Info("Llamada al metodo");
            using (play0dbEntities dbEntities = new play0dbEntities())
            {
                COMPONENTE existe_componente = dbEntities.COMPONENTES.Where(x => x.nombre == new_componente.nombre && x.dispositivo_id == new_componente.dispositivo_id).Select(s => s).FirstOrDefault();

                if (existe_componente != null)
                {
                    throw new ArgumentException(string.Format("Ya existe un componente con el nombre {0} en el dispositovo con ID {1}.", new_componente.nombre, new_componente.dispositivo_id.ToString()));
                }
                dbEntities.COMPONENTES.Add(new_componente);
                dbEntities.SaveChanges();

                if (new_componente.id != 0)
                {
                    return new_componente;
                }
                else
                    throw new Exception(string.Format("No fue posible guardar un nuevo componente {0}.", new_componente.nombre));
            }
        }
    }
}