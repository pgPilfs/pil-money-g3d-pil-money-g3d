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
    
    public partial class tipo_moneda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_moneda()
        {
            this.Cuentas = new HashSet<Cuenta>();
            this.compra_venta_Divisas = new HashSet<compra_venta_Divisas>();
        }
    
        public int id_moneda { get; set; }
        public string nom_moneda { get; set; }
        public decimal cotizacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuenta> Cuentas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compra_venta_Divisas> compra_venta_Divisas { get; set; }
    }
}
