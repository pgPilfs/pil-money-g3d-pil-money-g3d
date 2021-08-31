using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            Personas = new HashSet<Persona>();
        }

        public string MarcaTc { get; set; }
        public int NroTarjeta { get; set; }
        public string Titular { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Cvv { get; set; }
        public int Dni { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
