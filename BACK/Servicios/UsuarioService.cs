using Microsoft.EntityFrameworkCore;
using PipayWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWallet.Servicios
{
    public class UsuarioService:IUsuarioService
    {
        private readonly pilacortadaContext _context;
        public UsuarioService(pilacortadaContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Guardar(Usuario usuario)
        {
            

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                int id = usuario.IdUsuario;
                var result = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
                return result;

        }

    }
}
