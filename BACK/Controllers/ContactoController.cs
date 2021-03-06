using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PILpw.Entitis;
using PILpw.Interfaz;
using PILpw.Models;
using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Controllers
{
    [Authorize]
    [Route("api/contacto")]
    [ApiController]

    public class ContactoController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IContactoService _contactoService;
        private readonly IMapper _mapper;
        public ContactoController(IContactoService contactoService, dev_pwContext context, IMapper mapper)
        {
            _context = context;
            _contactoService = contactoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var contactos = await _context.Contactos.Where(x=>x.IdUsuario==id).ToListAsync();
            List<UsuarioModel> contactoslist = new List<UsuarioModel>();
            foreach (var item in contactos)
            {
                var items = await _context.Usuarios.Where(x => x.IdUsuario == item.IdUsuarioAgendado).FirstOrDefaultAsync();
                var usuariomap = _mapper.Map<UsuarioModel>(items);
                contactoslist.Add(usuariomap);
            }
                
            return Ok(contactoslist);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactoModel contacto, string alias)
        {
            var post = await _contactoService.Guardar(contacto, alias);
            if (post!=null)
            {
                return Ok(post);
            }
            return BadRequest("Contacto ya existente o No encontrado");
        }




        //TODO: ver el return de ok si funciona bien..
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]int? idusuario, [FromQuery]int idcontacto)
        {
            if (idusuario == null)
            {
                return NotFound();
            }
            else
            {
                var contacto = _context.Contactos.Where(x => x.IdUsuario == idusuario)
                .Where(e => e.IdUsuarioAgendado == idcontacto).FirstOrDefault();
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
