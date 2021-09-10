using PipayWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWallet.Servicios
{
    public interface IUsuarioService
    {
        Task<Usuario> Guardar(Usuario usuario);
    }
}
