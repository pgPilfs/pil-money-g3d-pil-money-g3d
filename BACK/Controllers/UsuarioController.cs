using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PILpw.Entitis;
using PILpw.Models;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PipayWalletFinal.Controllers
{
    [Authorize]
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

        

        [HttpPut]
        public async Task<IActionResult> Put(UsuarioModel usuario, int id)
        {
            return Ok(await _usuarioService.Editar(usuario, id));
        }
    }
}
