using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PILpw.Entitis;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ver namespace
namespace PILpw.Controllers
{    /* 
    [Route("api/operaciones")]
    [ApiController]

       public class OperacioneController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IOperacioneService _OperacioneService;
        public OperacioneController(IOperacioneService OperacioneService, dev_pwContext context)
        {
            _context = context;
            _OperacioneService = OperacioneService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Operaciones = _context.Operaciones.ToList();
            return Ok(Operaciones);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OperacioneModel Operacione)
        {
            return Ok(await _OperacioneService.Guardar(Operacione));
        }
    }

     */
}
