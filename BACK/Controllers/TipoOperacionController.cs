using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PILpw.Entitis;
using PILpw.Interfaz;
using PILpw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ver namespace
namespace PILpw.Controllers
{
    
    [Route("api/TipoOperacion")]
    [ApiController]
    public class TipoOperacionController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly ITipoOperacionService _tipooperacionService;
        public TipoOperacionController(ITipoOperacionService tipooperacionService, dev_pwContext context)
        {
            _context = context;
            _tipooperacionService = tipooperacionService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var TipoOperacions = _context.Operacione.ToList();
            return Ok(TipoOperacions);

        }


        [HttpPost]
        public async Task<IActionResult> Post(TipoOperacionModel TipoOperacion)
        {
            return Ok(await _tipooperacionService.Guardar(TipoOperacion));
        }
    }
  

}
