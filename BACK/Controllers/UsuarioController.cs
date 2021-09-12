using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using PWFinal.Entidades;
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
        private readonly dbFinalContext _context;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService, dbFinalContext context)
        {
            _context = context;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);

        }


        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            return Ok(await _usuarioService.Guardar(usuario));
        }
    }
}
