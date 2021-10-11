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
    public class OperacioneService : IOperacioneService
    {

        private readonly dev_pwContext _context;
        private readonly IMapper _mapper;


        public OperacioneService(dev_pwContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperacioneModel> Guardar(OperacioneModel Operacione)
        {
            var tipo = _mapper.Map<Operacione>(Operacione);
            await _context.AddAsync(tipo);
            await _context.SaveChangesAsync();
            return _mapper.Map<OperacioneModel>(Operacione);
        }

        Task<object> IOperacioneService.Guardar(OperacioneModel operacione)
        {
            throw new NotImplementedException();
        }
    }
}
