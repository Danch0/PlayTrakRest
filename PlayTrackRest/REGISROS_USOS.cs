//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayTrackRest
{
    using System;
    using System.Collections.Generic;
    
    public partial class REGISROS_USOS
    {
        public int id { get; set; }
        public Nullable<System.DateTime> dt_inicio { get; set; }
        public Nullable<System.DateTime> dt_fin { get; set; }
        public Nullable<int> dispositivo_id { get; set; }
    
        public virtual DISPOSITIVO DISPOSITIVO { get; set; }
    }
}
