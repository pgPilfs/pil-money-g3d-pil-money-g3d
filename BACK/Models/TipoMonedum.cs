using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class TipoMonedum
    {
        public TipoMonedum()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int IdMoneda { get; set; }
        public string NomMoneda { get; set; }
        public decimal Cotizacion { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
