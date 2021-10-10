using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PILpw.Entitis;
using PILpw.Interfaz;
using PILpw.Models;
using PipayWalletFinal.Interfaz;
using PipayWalletFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ver namespace
namespace PILpw.Controllers
{
    [Authorize]
    [Route("api/operaciones")]
    [ApiController]

    public class OperacioneController : ControllerBase
    {
        private readonly dev_pwContext _context;
        private readonly IOperacioneService _OperacioneService;
        private readonly IMapper _mapper;
        public OperacioneController(IOperacioneService OperacioneService, dev_pwContext context, IMapper mapper )
        {
            _context = context;
            _OperacioneService = OperacioneService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int? idcuenta)
        {
            
            List<MovimientosModels> contactoslist = new List<MovimientosModels>();
            if (idcuenta.HasValue)
            {
                var operacion = _context.Operaciones.Where(x => x.IdCuenta == idcuenta).ToList();
                
                foreach (var item in operacion)
                {
                    MovimientosModels movimientos = new MovimientosModels();
                    var nomebreop = _context.Operacione.Where(x => x.IdTipoOperacion == item.IdTipoOperacion).FirstOrDefault();
                    var destina = _context.Cuentas.Where(x => x.IdCuenta == item.Destinatario).FirstOrDefault();
                    movimientos.idOperacion = item.IdOperacion;
                    movimientos.idCuenta = item.IdCuenta;
                    movimientos.monto = item.Monto;
                    movimientos.fecha = item.FechaOperacion;
                    movimientos.operacion = nomebreop.NombreOperacion;
                    if (destina == null)
                    {
                        movimientos.destinatario = "";
                    }
                    else
                    {
                        movimientos.destinatario = destina.Alias;
                       
                    }

                    contactoslist.Add(movimientos);
                }
                return Ok(contactoslist);
            }
            var Operaciones = _context.Operaciones.ToList();
            return Ok(Operaciones);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create( OperacioneModel operacione)
        {

            if (ModelState.IsValid)
            {
                if (operacione.IdTipoOperacion == 1 || operacione.IdTipoOperacion == 2)
                {
                    var usuario = _context.Cuentas.Where(x => x.IdCuenta == operacione.IdCuenta).FirstOrDefault();
                    if(operacione.IdTipoOperacion == 1)
                    {
                        usuario.Saldo -= operacione.Monto;
                    }
                    else
                    {
                        usuario.Saldo += operacione.Monto;
                    }
                    
                    
                    if (usuario.Saldo >= 0)
                    {
                        var subtotal = _mapper.Map<Cuenta>(usuario);
                        _context.Update(subtotal);
                        _context.SaveChanges();
                        var entity = _mapper.Map<Operacione>(operacione);
                        if(operacione.IdTipoOperacion == 1)
                        {
                            entity.Monto = entity.Monto * -1;
                        }
                        
                        entity.FechaOperacion = DateTime.Now.ToString("dd/MM/yyyy");
                        _context.Add(entity);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    return StatusCode(500,"No se puede realizar la operación, saldo insuficiente");
                }
                else if (operacione.IdTipoOperacion == 3)
                {
                    var usuario = _context.Cuentas.Where(x => x.IdCuenta == operacione.IdCuenta).FirstOrDefault();
                    var usuarioDestinatario = _context.Cuentas.Where(x => x.IdCuenta == operacione.Destinatario).FirstOrDefault();
                    usuario.Saldo -= operacione.Monto;
                    if (usuario.Saldo >= 0)
                    {
                        var subtotal = _mapper.Map<Cuenta>(usuario);
                        _context.Update(subtotal);
                        _context.SaveChanges();
                        usuarioDestinatario.Saldo += operacione.Monto;
                        var subtotaldes = _mapper.Map<Cuenta>(usuarioDestinatario);
                        _context.Update(subtotaldes);
                        _context.SaveChanges();

                        var entity = _mapper.Map<Operacione>(operacione);
                        entity.FechaOperacion = DateTime.Now.ToString("dd/MM/yyyy");
                        entity.Monto = entity.Monto * -1;
                        _context.Add(entity);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    return BadRequest("No se puede realizar la operación, saldo insuficiente");
                }
            }
            return BadRequest("el usuario no se cargo");
        }


        
    }

}


