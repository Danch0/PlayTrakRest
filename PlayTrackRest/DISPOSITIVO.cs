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
    
    public partial class DISPOSITIVO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISPOSITIVO()
        {
            this.COMPONENTES = new HashSet<COMPONENTE>();
            this.REGISROS_USOS = new HashSet<REGISROS_USOS>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> registro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPONENTE> COMPONENTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISROS_USOS> REGISROS_USOS { get; set; }
    }
}