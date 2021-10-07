
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PILpw.Entitis;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using PWFinal.Interfaz;
using PWFinal.Mapping;
using PWFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipayWalletFinal.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly dev_pwContext _context;
        private readonly ICuentaService _cuentaservice;
        private readonly IMapper _mapper;
        public UsuarioService(dev_pwContext context, ICuentaService cuentaservice, IMapper mapper)
        {
            _context = context;
            _cuentaservice = cuentaservice;
            _mapper = mapper;
        }
        public async Task<UsuarioModel> Guardar(UsuarioModel usuario)
        {
            CuentaModel cuenta = new CuentaModel();
            Random r = new Random();
            var usuariomap = _mapper.Map<Usuario>(usuario);
            var usuariocreado=await _context.Usuarios.AddAsync(usuariomap);
            await _context.SaveChangesAsync();
            var usuarioguar = _mapper.Map<UsuarioModel>(usuariomap);
            int id = usuarioguar.IdUsuario;

            int est = 0;
            //Crea una nueva cuenta
            do
            {
                
                int random = r.Next(1000000000, 2000000000);
                string adicionales = "000000800002";
                string cvu = adicionales + random.ToString();
                var res =_context.Cuentas.Any(x=>x.Cvu==cvu);
                if (res==false)
                {
                    cuenta.IdUsuario = id;
                    cuenta.TipoCuenta = "Pesos";
                    cuenta.Cvu = cvu;
                    //cuenta.Alias = usuario.Nombre.ToUpper() + usuario.Apelldio.ToUpper() + ".PIPAY";
                    cuenta.Saldo = 0;
                  
                    await _cuentaservice.CrearCuenta(cuenta);
                    est = 1;

                }
            } while (est==0);

            return _mapper.Map<UsuarioModel>(usuariomap);
            
        }

        public async Task<UsuarioModel> Editar(UsuarioModel usuario, int id)
        {
            usuario.IdUsuario = id;
            var entity = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
            
            entity = _mapper.Map(usuario, entity);
           

            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioModel>(usuario);

        }
    }

        

    
}
