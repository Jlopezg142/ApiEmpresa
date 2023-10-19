using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.models;

namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly Conexiones _context;

        public PuestosController(Conexiones context)
        {
            _context = context;
        }

        // GET: api/Puestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puestos>>> GetPuestos()
        {
          if (_context.Puestos == null)
          {
              return NotFound();
          }
            return await _context.Puestos.ToListAsync();
        }

        // GET: api/Puestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puestos>> GetPuestos(short id)
        {
          if (_context.Puestos == null)
          {
              return NotFound();
          }
            var puestos = await _context.Puestos.FindAsync(id);

            if (puestos == null)
            {
                return NotFound();
            }

            return puestos;
        }

        // PUT: api/Puestos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuestos(short id, Puestos puestos)
        {
            if (id != puestos.idpuesto)
            {
                return BadRequest();
            }

            _context.Entry(puestos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestosExists(id))
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

        // POST: api/Puestos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puestos>> PostPuestos(Puestos puestos)
        {
          if (_context.Puestos == null)
          {
              return Problem("Entity set 'Conexiones.Puestos'  is null.");
          }
            _context.Puestos.Add(puestos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuestos", new { id = puestos.idpuesto }, puestos);
        }

        // DELETE: api/Puestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuestos(short id)
        {
            if (_context.Puestos == null)
            {
                return NotFound();
            }
            var puestos = await _context.Puestos.FindAsync(id);
            if (puestos == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puestos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuestosExists(short id)
        {
            return (_context.Puestos?.Any(e => e.idpuesto == id)).GetValueOrDefault();
        }
    }
}
