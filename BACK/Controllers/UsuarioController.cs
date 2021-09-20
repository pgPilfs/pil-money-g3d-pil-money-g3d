using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PILpw.Entitis;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService, dev_pwContext context)
        {
            _context = context;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async  Task<IActionResult> Get(int id)
        {
            var usuarios = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
            return Ok(usuarios);

        }


        [HttpPost]
        public async Task<IActionResult> Post(UsuarioModel usuario)
        {
            return Ok(await _usuarioService.Guardar(usuario));
        }
    }
}
