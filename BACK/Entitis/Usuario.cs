using System;
using System.Collections.Generic;

#nullable disable

namespace PILpw.Entitis
{
    public partial class Usuario
    {
        public Usuario()
        {
            Contactos = new HashSet<Contacto>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apelldio { get; set; }
        public int? Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
