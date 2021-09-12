
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using PWFinal.Entidades;
using PWFinal.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly dbFinalContext _context;
        private readonly ICuentaService _cuentaservice;
        public UsuarioService(dbFinalContext context, ICuentaService cuentaservice)
        {
            _context = context;
            _cuentaservice = cuentaservice;
        }
        public async Task<Usuario> Guardar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            var result = await _context.Cuentas.OrderByDescending(x => x.Cvu).FirstOrDefaultAsync();
            if (result==null )
            {
                var cvu = 1000000000;
                Cuenta cuentanueva = new Cuenta
                {
                    IdUsuario = usuario.IdUsuario,
                    TipoCuenta = "Pesos",
                    Cvu = cvu,
                    Alias = usuario.Nombre + "." + usuario.Apellido,
                    Saldo = "0",

                };

                await _cuentaservice.CrearCuenta(cuentanueva);
                return usuario;
            }
            else
            {
                var resultcvu = await _context.Cuentas.OrderByDescending(x => x.Cvu).FirstOrDefaultAsync();
                var sumacvu = resultcvu.Cvu + 1;
                Cuenta cuenta = new Cuenta
                {
                    IdUsuario = usuario.IdUsuario,
                    TipoCuenta = "Pesos",
                    Cvu = sumacvu,
                    Alias = usuario.Nombre + "." + usuario.Apellido,
                    Saldo = "0",

                };
                await _cuentaservice.CrearCuenta(cuenta);
                return usuario;
            }
            
            
        }
    }

        

    
}
