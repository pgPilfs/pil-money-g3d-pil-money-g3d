using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Models
{
    public class OperacioneModel
    {

        public int IdOperacion { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? Destinatario { get; set; }
        public decimal Monto { get; set; }
        public string FechaOperacion { get; set; }
    }
}
