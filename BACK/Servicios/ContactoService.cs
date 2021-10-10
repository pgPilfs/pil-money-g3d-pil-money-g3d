using AutoMapper;
using PILpw.Entitis;
using PILpw.Interfaz;
using PILpw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PILpw.Servicios
{
    public class ContactoService : IContactoService
    {

        private readonly dev_pwContext _context;
        private readonly IMapper _mapper;

        public ContactoService(dev_pwContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ContactoModel> Eliminar(ContactoModel contacto, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactoModel> Guardar(ContactoModel contacto)
        {
            var entity = _mapper.Map<Contacto>(contacto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContactoModel>(entity);
        }
    }
}
