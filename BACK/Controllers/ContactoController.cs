using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PILpw.Entitis;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Controllers
{
    /*
    [Route("api/contacto")]
    [ApiController]
    
    public class ContactoController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IcontactoService _contactoService;
        public ContactoController(IcontactoService contactoService, dev_pwContext context)
        {
            _context = context;
            _contactoService = contactoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contacto = _context.Contactos.ToList();
            return Ok(contacto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(contactoModel contacto)
        {
            return Ok(await _contactoService.Guardar(contacto));
        }
    }
    */
}
