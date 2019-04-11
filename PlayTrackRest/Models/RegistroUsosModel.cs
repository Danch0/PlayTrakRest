using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTrackRest.Models
{
    public class RegistroUsosModel
    {
        public int id { get; set; }
        public Nullable<System.DateTime> dt_inicio { get; set; }
        public Nullable<System.DateTime> dt_fin { get; set; }
        public Nullable<int> dispositivo_id { get; set; }
    }
}