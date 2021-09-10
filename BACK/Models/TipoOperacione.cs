using System;
using System.Collections.Generic;

#nullable disable

namespace PipayWallet.Models
{
    public partial class TipoOperacione
    {
        public TipoOperacione()
        {
            Operacions = new HashSet<Operacion>();
        }

        public int IdTipooperacion { get; set; }
        public string NombreOperacion { get; set; }

        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
