using AutoMapper;
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
        public IActionResult Get()
        {
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
                    usuario.Saldo += operacione.Monto;
                    if (usuario.Saldo > 0)
                    {
                        var subtotal = _mapper.Map<Cuenta>(usuario);
                        _context.Update(subtotal);
                        _context.SaveChanges();
                        var entity = _mapper.Map<Operacione>(operacione);
                        _context.Add(entity);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    return BadRequest("No se puede realizar la operación, saldo insuficiente");
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
                        _context.Add(entity);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    return BadRequest("No se puede realizar la operación, saldo insuficiente");
                }
            }
            return BadRequest("el usuario no se cargo");
        }


        //TODO: ver EL metodo edit Luego de la tabla vuelva a estar funcional

        /*
        // GET: Operaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacione = await _context.Operaciones.FindAsync(id);
            if (operacione == null)
            {
                return NotFound();
            }
            return Ok();
        }

 

        // GET: Operaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacione = await _context.Operaciones
                .Include(o => o.IdCuentaNavigation)
                .Include(o => o.IdOperacionNavigation)
                .FirstOrDefaultAsync(m => m.IdOperacion == id);
            if (operacione == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: Operaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operacione = await _context.Operaciones.FindAsync(id);
            _context.Operaciones.Remove(operacione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacioneExists(int id)
        {
            return _context.Operaciones.Any(e => e.IdOperacion == id);
        }*/
    }

}


