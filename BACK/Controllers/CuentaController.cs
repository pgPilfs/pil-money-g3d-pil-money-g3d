using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PILpw.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly dev_pwContext _context;

        public CuentaController( dev_pwContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var usuarios = await _context.Cuentas.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
            return Ok(usuarios);

        }
    }
}
