using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Contacto
    {
        public string NombreUsuario { get; set; }
        public int Cvu { get; set; }
        public string Email { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
