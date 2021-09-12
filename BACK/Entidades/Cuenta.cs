using System;
using System.Collections.Generic;

#nullable disable

namespace PWFinal.Entidades
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
        public int? Cvu { get; set; }
        public string Alias { get; set; }
        public string Saldo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
