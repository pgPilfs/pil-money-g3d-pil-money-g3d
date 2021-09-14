using System;
using System.Collections.Generic;

#nullable disable

namespace PILpw.Entitis
{
    public partial class TipoOperacion
    {
        public int IdTipoOperacion { get; set; }
        public string NombreOperacion { get; set; }

        public virtual Operacione Operacione { get; set; }
    }
}
