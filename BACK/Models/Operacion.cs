using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class Operacion
    {
        public int IdOperacion { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdTipoOperacion { get; set; }
        public string CodSeguridad { get; set; }
        public string Monto { get; set; }
        public DateTime? FechaOperacion { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
        public virtual TipoOperacione IdTipoOperacionNavigation { get; set; }
    }
}
