using PWFinal.Entidades;
using PWFinal.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWFinal.Servicios
{
    public class CuentaService:ICuentaService
    {
        private readonly dbFinalContext _context;

        public CuentaService(dbFinalContext context)
        {
            _context = context;
        }

        public async Task<Cuenta> CrearCuenta(Cuenta cuenta)
        {
            await _context.Cuentas.AddAsync(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }
    }
}
