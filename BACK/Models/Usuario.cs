using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public int Cvu { get; set; }
        public string Email { get; set; }

        public virtual Cuenta CvuNavigation { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
