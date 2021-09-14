using System;
using System.Collections.Generic;

#nullable disable

namespace PILpw.Entitis
{
    public partial class Operacione
    {
        public int IdOperacion { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? Destinatario { get; set; }
        public string Monto { get; set; }
        public string FechaOperacion { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
        public virtual TipoOperacion IdOperacionNavigation { get; set; }
    }
}
