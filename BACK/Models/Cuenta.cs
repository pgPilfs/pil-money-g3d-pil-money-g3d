using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Operaciones = new HashSet<Operacione>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Cvu { get; set; }
        public string Alias { get; set; }
        public decimal Saldo { get; set; }
        public int IdMoneda { get; set; }

        public virtual TipoMonedum IdMonedaNavigation { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
