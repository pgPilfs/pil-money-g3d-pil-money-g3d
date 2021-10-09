using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Models
{
    public class MovimientosModels
    {
        public int idOperacion { get; set; }
        public int?  idCuenta { get; set; }
        public string operacion { get; set; }
        public string destinatario { get; set; }
        public decimal monto { get; set; }
        public string fecha { get; set; }




    }
}
