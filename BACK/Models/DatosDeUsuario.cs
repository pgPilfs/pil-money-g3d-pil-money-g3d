using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class DatosDeUsuario
    {
        public int IdDatousuario { get; set; }
        public int IdUsuario { get; set; }
        public int? IdDomicilio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual Domicilio IdDomicilioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
