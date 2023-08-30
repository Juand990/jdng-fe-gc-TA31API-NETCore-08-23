using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA31_03.Modelo;

namespace TA31_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignadoAController : ControllerBase
    {
        private readonly CientContext _context;

        public AsignadoAController(CientContext context)
        {
            _context = context;
        }

        // GET: api/AsignadoA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignadoA>>> GetAsignadoA()
        {
          if (_context.AsignadoA == null)
          {
              return NotFound();
          }
            return await _context.AsignadoA.ToListAsync();
        }

        // GET: api/AsignadoA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignadoA>> GetAsignadoA(int id)
        {
          if (_context.AsignadoA == null)
          {
              return NotFound();
          }
            var asignadoA = await _context.AsignadoA.FindAsync(id);

            if (asignadoA == null)
            {
                return NotFound();
            }

            return asignadoA;
        }

        // PUT: api/AsignadoA/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignadoA(int id, AsignadoA asignadoA)
        {
            if (id != asignadoA.Id)
            {
                return BadRequest();
            }

            _context.Entry(asignadoA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignadoAExists(id))
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

        // POST: api/AsignadoA
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignadoA>> PostAsignadoA(AsignadoA asignadoA)
        {
          if (_context.AsignadoA == null)
          {
              return Problem("Entity set 'CientContext.AsignadoA'  is null.");
          }
            _context.AsignadoA.Add(asignadoA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignadoA", new { id = asignadoA.Id }, asignadoA);
        }

        // DELETE: api/AsignadoA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignadoA(int id)
        {
            if (_context.AsignadoA == null)
            {
                return NotFound();
            }
            var asignadoA = await _context.AsignadoA.FindAsync(id);
            if (asignadoA == null)
            {
                return NotFound();
            }

            _context.AsignadoA.Remove(asignadoA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignadoAExists(int id)
        {
            return (_context.AsignadoA?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
