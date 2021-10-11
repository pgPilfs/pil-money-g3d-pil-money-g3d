using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Interfaz
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> Guardar(UsuarioModel usuario);
        Task<UsuarioModel> Editar(UsuarioModel usuario, int id);
    }
}
