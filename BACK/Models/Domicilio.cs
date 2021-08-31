using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdDomicilio { get; set; }
        public string Calle { get; set; }
        public int? Altura { get; set; }
        public string Referencia { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
