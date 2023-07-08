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
    public class DataArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public DataArtisiansController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/DataArtisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataArtisian>>> GetDataArtisians()
        {
          if (_context.DataArtisians == null)
          {
              return NotFound();
          }
            return await _context.DataArtisians.ToListAsync();
        }

        // GET: api/DataArtisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataArtisian>> GetDataArtisian(int id)
        {
          if (_context.DataArtisians == null)
          {
              return NotFound();
          }
            var dataArtisian = await _context.DataArtisians.FindAsync(id);

            if (dataArtisian == null)
            {
                return NotFound();
            }

            return dataArtisian;
        }

        // PUT: api/DataArtisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataArtisian(int id, DataArtisian dataArtisian)
        {
            if (id != dataArtisian.ArtisianId)
            {
                return BadRequest();
            }

            _context.Entry(dataArtisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataArtisianExists(id))
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

        // POST: api/DataArtisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataArtisian>> PostDataArtisian(DataArtisian dataArtisian)
        {
          if (_context.DataArtisians == null)
          {
              return Problem("Entity set 'ArtisianContext.DataArtisians'  is null.");
          }
            _context.DataArtisians.Add(dataArtisian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataArtisian", new { id = dataArtisian.ArtisianId }, dataArtisian);
        }

        // DELETE: api/DataArtisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataArtisian(int id)
        {
            if (_context.DataArtisians == null)
            {
                return NotFound();
            }
            var dataArtisian = await _context.DataArtisians.FindAsync(id);
            if (dataArtisian == null)
            {
                return NotFound();
            }

            _context.DataArtisians.Remove(dataArtisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataArtisianExists(int id)
        {
            return (_context.DataArtisians?.Any(e => e.ArtisianId == id)).GetValueOrDefault();
        }
    }
}
