using System;
using System.Collections.Generic;

#nullable disable

namespace PWFinal.Entidades
{
    public partial class TipoOperacion
    {
        public TipoOperacion()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdTipoOperacion { get; set; }
        public string NombreOperacion { get; set; }

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
