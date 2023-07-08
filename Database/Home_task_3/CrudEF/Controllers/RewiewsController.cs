using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewiewsController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public RewiewsController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/Rewiews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rewiew>>> GetRewiews()
        {
          if (_context.Rewiews == null)
          {
              return NotFound();
          }
            return await _context.Rewiews.ToListAsync();
        }

        // GET: api/Rewiews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rewiew>> GetRewiew(int id)
        {
          if (_context.Rewiews == null)
          {
              return NotFound();
          }
            var rewiew = await _context.Rewiews.FindAsync(id);

            if (rewiew == null)
            {
                return NotFound();
            }

            return rewiew;
        }

        // PUT: api/Rewiews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRewiew(int id, Rewiew rewiew)
        {
            if (id != rewiew.Id)
            {
                return BadRequest();
            }

            _context.Entry(rewiew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RewiewExists(id))
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

        // POST: api/Rewiews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rewiew>> PostRewiew(Rewiew rewiew)
        {
          if (_context.Rewiews == null)
          {
              return Problem("Entity set 'ArtisianContext.Rewiews'  is null.");
          }
            _context.Rewiews.Add(rewiew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRewiew", new { id = rewiew.Id }, rewiew);
        }

        // DELETE: api/Rewiews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRewiew(int id)
        {
            if (_context.Rewiews == null)
            {
                return NotFound();
            }
            var rewiew = await _context.Rewiews.FindAsync(id);
            if (rewiew == null)
            {
                return NotFound();
            }

            _context.Rewiews.Remove(rewiew);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RewiewExists(int id)
        {
            return (_context.Rewiews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
