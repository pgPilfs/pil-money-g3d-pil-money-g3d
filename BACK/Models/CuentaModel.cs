using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PWFinal.Models
{
    public class CuentaModel
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuenta { get; set; }


        public int? IdUsuario { get; set; }
        public string TipoCuenta { get; set; }
        public string Cvu { get; set; }
        public string Alias { get; set; }
        public string Saldo { get; set; }


    }
}
