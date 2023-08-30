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
    public class CientificosController : ControllerBase
    {
        private readonly CientContext _context;

        public CientificosController(CientContext context)
        {
            _context = context;
        }

        // GET: api/Cientificos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientificos>>> GetCientificosItems()
        {
          if (_context.CientificosItems == null)
          {
              return NotFound();
          }
            return await _context.CientificosItems.ToListAsync();
        }

        // GET: api/Cientificos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientificos>> GetCientificos(int id)
        {
          if (_context.CientificosItems == null)
          {
              return NotFound();
          }
            var cientificos = await _context.CientificosItems.FindAsync(id);

            if (cientificos == null)
            {
                return NotFound();
            }

            return cientificos;
        }

        // PUT: api/Cientificos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientificos(int id, Cientificos cientificos)
        {
            if (id != cientificos.Id)
            {
                return BadRequest();
            }

            _context.Entry(cientificos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CientificosExists(id))
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

        // POST: api/Cientificos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cientificos>> PostCientificos(Cientificos cientificos)
        {
          if (_context.CientificosItems == null)
          {
              return Problem("Entity set 'CientContext.CientificosItems'  is null.");
          }
            _context.CientificosItems.Add(cientificos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCientificos", new { id = cientificos.Id }, cientificos);
        }

        // DELETE: api/Cientificos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCientificos(int id)
        {
            if (_context.CientificosItems == null)
            {
                return NotFound();
            }
            var cientificos = await _context.CientificosItems.FindAsync(id);
            if (cientificos == null)
            {
                return NotFound();
            }

            _context.CientificosItems.Remove(cientificos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CientificosExists(int id)
        {
            return (_context.CientificosItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
