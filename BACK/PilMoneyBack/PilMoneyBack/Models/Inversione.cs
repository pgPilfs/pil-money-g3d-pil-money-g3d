//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PilMoneyBack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inversione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inversione()
        {
            this.Operaciones = new HashSet<Operacione>();
        }
    
        public int id_Inversion { get; set; }
        public string tipo_Inversion { get; set; }
        public int plazo { get; set; }
        public decimal importe { get; set; }
        public System.DateTime fecha_operacion { get; set; }
        public System.DateTime fecha_vencimiento { get; set; }
        public string accion_al_vto { get; set; }
        public int id_tasa { get; set; }
    
        public virtual Eleccione Eleccione { get; set; }
        public virtual Rendimiento Rendimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
