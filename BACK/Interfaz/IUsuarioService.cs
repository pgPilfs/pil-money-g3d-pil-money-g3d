using PipayWalletFinal.Models;
using PWFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Interfaz
{
    public interface IUsuarioService
    {
        Task<Usuario> Guardar(Usuario usuario);

    }
}
