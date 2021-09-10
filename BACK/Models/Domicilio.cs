using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            DatosDeUsuarios = new HashSet<DatosDeUsuario>();
        }

        public int IdDomicilio { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<DatosDeUsuario> DatosDeUsuarios { get; set; }
    }
}
