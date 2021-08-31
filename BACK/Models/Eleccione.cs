using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Eleccione
    {
        public Eleccione()
        {
            Inversiones = new HashSet<Inversione>();
        }

        public string AccionAlVto { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Inversione> Inversiones { get; set; }
    }
}
