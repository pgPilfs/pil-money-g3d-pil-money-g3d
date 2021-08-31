using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Pago
    {
        public Pago()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdPago { get; set; }
        public int IdEmpresa { get; set; }
        public int NroCliente { get; set; }
        public decimal Monto { get; set; }
        public DateTime Vencimiento { get; set; }
        public string CodBarras { get; set; }
        public int IdFormaPago { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual FormaDePago IdFormaPagoNavigation { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
