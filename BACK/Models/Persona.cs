using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int IdDomicilio { get; set; }
        public int NroTarjeta { get; set; }

        public virtual Domicilio IdDomicilioNavigation { get; set; }
        public virtual Tarjeta NroTarjetaNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
