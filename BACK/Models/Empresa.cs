using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Pagos = new HashSet<Pago>();
        }

        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
