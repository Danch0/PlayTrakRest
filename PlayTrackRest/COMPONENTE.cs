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
    
    public partial class COMPONENTE
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> registro { get; set; }
        public Nullable<int> dispositivo_id { get; set; }
    
        public virtual DISPOSITIVO DISPOSITIVO { get; set; }
    }
}
