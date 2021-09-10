using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PipayWallet.Models;
using PipayWallet.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly pilacortadaContext _context;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(pilacortadaContext context, IUsuarioService usuarioService)
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
