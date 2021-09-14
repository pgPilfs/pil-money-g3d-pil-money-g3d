using AutoMapper;
using PILpw.Entitis;
using PWFinal.Interfaz;
using PWFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWFinal.Servicios
{
    public class CuentaService:ICuentaService
    {
        private readonly dev_pwContext _context;
        private readonly IMapper _mapper;

        public CuentaService(dev_pwContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CuentaModel> CrearCuenta(CuentaModel cuenta)
        {
            var entity = _mapper.Map<Cuenta>(cuenta);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CuentaModel>(entity);
        }
    }
}
