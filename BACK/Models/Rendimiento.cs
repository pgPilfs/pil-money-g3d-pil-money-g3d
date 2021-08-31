using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Rendimiento
    {
        public Rendimiento()
        {
            Inversiones = new HashSet<Inversione>();
        }

        public string TipoInversion { get; set; }
        public int IdTasa { get; set; }
        public decimal Tasa { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Inversione> Inversiones { get; set; }
    }
}
