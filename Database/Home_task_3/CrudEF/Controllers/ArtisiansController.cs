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
    public class ArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public ArtisiansController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/Artisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artisian>>> GetArtisians()
        {
          if (_context.Artisians == null)
          {
              return NotFound();
          }
            return await _context.Artisians.ToListAsync();
        }

        // GET: api/Artisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artisian>> GetArtisian(int id)
        {
          if (_context.Artisians == null)
          {
              return NotFound();
          }
            var artisian = await _context.Artisians.FindAsync(id);

            if (artisian == null)
            {
                return NotFound();
            }

            return artisian;
        }

        // PUT: api/Artisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtisian(int id, Artisian artisian)
        {
            if (id != artisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(artisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtisianExists(id))
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

        // POST: api/Artisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artisian>> PostArtisian(Artisian artisian)
        {
          if (_context.Artisians == null)
          {
              return Problem("Entity set 'ArtisianContext.Artisians'  is null.");
          }
            _context.Artisians.Add(artisian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtisian", new { id = artisian.Id }, artisian);
        }

        // DELETE: api/Artisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtisian(int id)
        {
            if (_context.Artisians == null)
            {
                return NotFound();
            }
            var artisian = await _context.Artisians.FindAsync(id);
            if (artisian == null)
            {
                return NotFound();
            }

            _context.Artisians.Remove(artisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtisianExists(int id)
        {
            return (_context.Artisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
