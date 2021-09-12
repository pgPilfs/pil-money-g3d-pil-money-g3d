using System;
using System.Collections.Generic;

#nullable disable

namespace PWFinal.Entidades
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdUsuarioAgendado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
