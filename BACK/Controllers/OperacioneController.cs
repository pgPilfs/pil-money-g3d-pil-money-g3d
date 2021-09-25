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
        public OperacioneController(IOperacioneService OperacioneService, dev_pwContext context)
        {
            _context = context;
            _OperacioneService = OperacioneService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Operaciones = _context.Operaciones.ToList();
            return Ok(Operaciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperacion,IdCuenta,IdTipoOperacion,Destinatario,Monto,FechaOperacion")] Operacione operacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdCuenta"] = new SelectList(_context.Cuentas, "IdCuenta", "IdCuenta", operacione.IdCuenta);
            //ViewData["IdOperacion"] = new SelectList(_context.TipoOperacions, "IdTipoOperacion", "IdTipoOperacion", operacione.IdOperacion);
            //return View(operacione);

            return Ok();
        }


        //TODO: ver EL metodo edit Luego de la tabla vuelva a estar funcional


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
        }
    }

}


}
