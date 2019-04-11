using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Repositories
{
    public class DispositivosRepository
    {
        internal static IEnumerable<DISPOSITIVO> ObtenerTodos()
        {
            play0dbEntities dbEntities = new play0dbEntities();

            return dbEntities.DISPOSITIVOS.Select(x=> x);
        }
    }
}