using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Contactos = new HashSet<Contacto>();
            Cuenta = new HashSet<Cuenta>();
            DatosDeUsuarios = new HashSet<DatosDeUsuario>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        public List<DatosDeUsuario> DatosUsuario { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<DatosDeUsuario> DatosDeUsuarios { get; set; }
    }
}
