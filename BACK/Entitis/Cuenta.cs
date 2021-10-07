using System;
using System.Collections.Generic;

#nullable disable

namespace PILpw.Entitis
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdCuenta { get; set; }
        public int? IdUsuario { get; set; }
        public string TipoCuenta { get; set; }
        public string Cvu { get; set; }
        public string Alias { get; set; }
        public decimal Saldo { get; set; }

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
