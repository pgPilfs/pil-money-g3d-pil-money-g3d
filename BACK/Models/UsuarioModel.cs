using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apelldio { get; set; }
        public int? Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Password { get; set; }


    }
}
