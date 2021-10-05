using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PILpw.Entitis;
using PILpw.Interfaz;
using PILpw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Controllers
{

    [Route("api/contacto")]
    [ApiController]

    public class ContactoController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IContactoService _contactoService;
        public ContactoController(IContactoService contactoService, dev_pwContext context)
        {
            _context = context;
            _contactoService = contactoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var contactos = await _context.Contactos.Where(x => x.IdContacto == id).FirstOrDefaultAsync();
            return Ok(contactos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactoModel contacto)
        {
            return Ok(await _contactoService.Guardar(contacto));
        }




        //TODO: ver el return de ok si funciona bien..
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var contacto = await _context.Contactos
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
                if (contacto == null)
                {
                    return NotFound();
                }
                else
                {
                     _context.Contactos.Remove(contacto);
                     _context.SaveChanges();
                    return Ok();
                }
            }

        }


    }

}
