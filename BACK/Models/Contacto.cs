using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdUsuarioagendado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
