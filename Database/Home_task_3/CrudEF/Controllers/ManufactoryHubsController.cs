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
    public class ManufactoryHubsController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public ManufactoryHubsController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/ManufactoryHubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufactoryHub>>> GetManufactoryHubs()
        {
          if (_context.ManufactoryHubs == null)
          {
              return NotFound();
          }
            return await _context.ManufactoryHubs.ToListAsync();
        }

        // GET: api/ManufactoryHubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufactoryHub>> GetManufactoryHub(int id)
        {
          if (_context.ManufactoryHubs == null)
          {
              return NotFound();
          }
            var manufactoryHub = await _context.ManufactoryHubs.FindAsync(id);

            if (manufactoryHub == null)
            {
                return NotFound();
            }

            return manufactoryHub;
        }

        // PUT: api/ManufactoryHubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufactoryHub(int id, ManufactoryHub manufactoryHub)
        {
            if (id != manufactoryHub.Id)
            {
                return BadRequest();
            }

            _context.Entry(manufactoryHub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufactoryHubExists(id))
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

        // POST: api/ManufactoryHubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManufactoryHub>> PostManufactoryHub(ManufactoryHub manufactoryHub)
        {
          if (_context.ManufactoryHubs == null)
          {
              return Problem("Entity set 'ArtisianContext.ManufactoryHubs'  is null.");
          }
            _context.ManufactoryHubs.Add(manufactoryHub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufactoryHub", new { id = manufactoryHub.Id }, manufactoryHub);
        }

        // DELETE: api/ManufactoryHubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufactoryHub(int id)
        {
            if (_context.ManufactoryHubs == null)
            {
                return NotFound();
            }
            var manufactoryHub = await _context.ManufactoryHubs.FindAsync(id);
            if (manufactoryHub == null)
            {
                return NotFound();
            }

            _context.ManufactoryHubs.Remove(manufactoryHub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufactoryHubExists(int id)
        {
            return (_context.ManufactoryHubs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
