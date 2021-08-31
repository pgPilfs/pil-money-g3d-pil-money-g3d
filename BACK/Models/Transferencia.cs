using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Transferencia
    {
        public Transferencia()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdTransferencia { get; set; }
        public int Cvu { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public string Mensaje { get; set; }

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
