using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class FormaDePago
    {
        public FormaDePago()
        {
            Pagos = new HashSet<Pago>();
        }

        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
