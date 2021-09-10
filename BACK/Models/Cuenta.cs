using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Operacions = new HashSet<Operacion>();
        }

        public int IdCuenta { get; set; }
        public int? IdUsuario { get; set; }
        public string TipoCuenta { get; set; }
        public string Cvu { get; set; }
        public string Alias { get; set; }
        public int? Saldo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
