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
    public class TipoOperacionService: ITipoOperacionService
    {
        private readonly dev_pwContext _context;
        private readonly IMapper _mapper;
        public TipoOperacionService(dev_pwContext context,  IMapper mapper)
        {
            _context = context;           
            _mapper = mapper;
        }
        public async Task<TipoOperacionModel> Guardar(TipoOperacionModel tipoOperacion)
        {
            var tipo = _mapper.Map<TipoOperacion>(tipoOperacion);
            await _context.TipoOperacions.AddAsync(tipo);
            await _context.SaveChangesAsync();
            return _mapper.Map<TipoOperacionModel>(tipo);
        }
    }
}
