using System;
using System.Collections.Generic;

#nullable disable

namespace PWFinal.Entidades
{
    public partial class Operacione
    {
        public int IdOperacion { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? Monto { get; set; }
        public DateTime? FechaOperacion { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
    }
}
