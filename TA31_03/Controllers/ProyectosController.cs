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
    public class ProyectosController : ControllerBase
    {
        private readonly ProyContext _context;

        public ProyectosController(ProyContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyectos>>> GetProyectosItems()
        {
          if (_context.ProyectosItems == null)
          {
              return NotFound();
          }
            return await _context.ProyectosItems.ToListAsync();
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyectos>> GetProyectos(int id)
        {
          if (_context.ProyectosItems == null)
          {
              return NotFound();
          }
            var proyectos = await _context.ProyectosItems.FindAsync(id);

            if (proyectos == null)
            {
                return NotFound();
            }

            return proyectos;
        }

        // PUT: api/Proyectos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectos(int id, Proyectos proyectos)
        {
            if (id != proyectos.Id)
            {
                return BadRequest();
            }

            _context.Entry(proyectos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(id))
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

        // POST: api/Proyectos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyectos>> PostProyectos(Proyectos proyectos)
        {
          if (_context.ProyectosItems == null)
          {
              return Problem("Entity set 'ProyContext.ProyectosItems'  is null.");
          }
            _context.ProyectosItems.Add(proyectos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectos", new { id = proyectos.Id }, proyectos);
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectos(int id)
        {
            if (_context.ProyectosItems == null)
            {
                return NotFound();
            }
            var proyectos = await _context.ProyectosItems.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }

            _context.ProyectosItems.Remove(proyectos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectosExists(int id)
        {
            return (_context.ProyectosItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
