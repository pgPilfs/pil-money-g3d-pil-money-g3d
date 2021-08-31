using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Extraccione
    {
        public Extraccione()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdExtraccion { get; set; }
        public string CodSeguridad { get; set; }
        public int IdTipo { get; set; }
        public decimal Monto { get; set; }

        public virtual TiposDepExtr IdTipoNavigation { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
