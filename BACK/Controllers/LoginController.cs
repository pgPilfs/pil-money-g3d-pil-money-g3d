using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PILpw.Entitis;
using PILpw.Models;
using PipayWalletFinal.Interfaz;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PILpw.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService, dev_pwContext context)
        {
            _context = context;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var nombreusuario = await _context.Usuarios.Where(x => x.NombreUsuario == login.NombreUsuario).FirstOrDefaultAsync();
            var pass = await _context.Usuarios.Where(x => x.Password == login.Password).FirstOrDefaultAsync();

            if (nombreusuario != null && pass != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44331",
                    audience: "https://localhost:44331",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(4),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString, Id = nombreusuario.IdUsuario });
            }
            return BadRequest();

        }
    }
}
