using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Inversione
    {
        public Inversione()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdInversion { get; set; }
        public string TipoInversion { get; set; }
        public int Plazo { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaOperacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string AccionAlVto { get; set; }
        public int IdTasa { get; set; }

        public virtual Eleccione AccionAlVtoNavigation { get; set; }
        public virtual Rendimiento Rendimiento { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
