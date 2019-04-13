﻿using System;
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
        /// Obtiene los n primeros dispositivos.
        /// </summary>
        /// <param name="limit"> Numero de dispositivos a obtener por defecto 1000.</param>
        /// <returns>Coleccion con los n dispositivos especificado.</returns>
        internal static IEnumerable<DISPOSITIVO> ObtenerTodos(int limit = 1000)
        {
            play0dbEntities dbEntities = new play0dbEntities();

            return (from dispositivos in dbEntities.DISPOSITIVOS orderby dispositivos.id descending  select dispositivos).Skip(limit).Take(limit);
        }
    }
}