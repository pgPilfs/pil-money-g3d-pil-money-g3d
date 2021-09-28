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
        public OperacioneController(IOperacioneService OperacioneService, dev_pwContext context, IMapper mapper)
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
        public async Task<IActionResult> Create(OperacioneModel operacione)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Operacione>(operacione);
                await _context.Operaciones.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           

            
        }

        // GET: Operaciones/Delete/5
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var operacione = await _context.Operaciones.Where(x=>x.IdOperacion==id).FirstOrDefaultAsync();
            _context.Operaciones.Remove(operacione);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool OperacioneExists(int id)
        {
            return _context.Operaciones.Any(e => e.IdOperacion == id);
        }
    }

}


