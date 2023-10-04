using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CargasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cargas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargaFamiliar>>> GetTblCargas()
        {
          if (_context.TblCargas == null)
          {
              return NotFound();
          }
            return await _context.TblCargas.ToListAsync();
        }

        // GET: api/Cargas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargaFamiliar>> GetCargaFamiliar(string id)
        {
          if (_context.TblCargas == null)
          {
              return NotFound();
          }
            var cargaFamiliar = await _context.TblCargas.FindAsync(id);

            if (cargaFamiliar == null)
            {
                return NotFound();
            }

            return cargaFamiliar;
        }

        // PUT: api/Cargas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargaFamiliar(string id, CargaFamiliar cargaFamiliar)
        {
            if (id != cargaFamiliar.Rut)
            {
                return BadRequest();
            }

            _context.Entry(cargaFamiliar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargaFamiliarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cargas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CargaFamiliar>> PostCargaFamiliar(CargaFamiliar cargaFamiliar)
        {
          if (_context.TblCargas == null)
          {
              return Problem("Entity set 'AppDbContext.TblCargas'  is null.");
          }
            _context.TblCargas.Add(cargaFamiliar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CargaFamiliarExists(cargaFamiliar.Rut))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCargaFamiliar", new { id = cargaFamiliar.Rut }, cargaFamiliar);
        }

        // DELETE: api/Cargas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargaFamiliar(string id)
        {
            if (_context.TblCargas == null)
            {
                return NotFound();
            }
            var cargaFamiliar = await _context.TblCargas.FindAsync(id);
            if (cargaFamiliar == null)
            {
                return NotFound();
            }

            _context.TblCargas.Remove(cargaFamiliar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargaFamiliarExists(string id)
        {
            return (_context.TblCargas?.Any(e => e.Rut == id)).GetValueOrDefault();
        }
    }
}
