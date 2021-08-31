using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class TiposDepExtr
    {
        public TiposDepExtr()
        {
            Depositos = new HashSet<Deposito>();
            Extracciones = new HashSet<Extraccione>();
        }

        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<Deposito> Depositos { get; set; }
        public virtual ICollection<Extraccione> Extracciones { get; set; }
    }
}
