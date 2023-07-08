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
    public class NetworkArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public NetworkArtisiansController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/NetworkArtisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NetworkArtisian>>> GetNetworkArtisians()
        {
          if (_context.NetworkArtisians == null)
          {
              return NotFound();
          }
            return await _context.NetworkArtisians.ToListAsync();
        }

        // GET: api/NetworkArtisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NetworkArtisian>> GetNetworkArtisian(int id)
        {
          if (_context.NetworkArtisians == null)
          {
              return NotFound();
          }
            var networkArtisian = await _context.NetworkArtisians.FindAsync(id);

            if (networkArtisian == null)
            {
                return NotFound();
            }

            return networkArtisian;
        }

        // PUT: api/NetworkArtisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetworkArtisian(int id, NetworkArtisian networkArtisian)
        {
            if (id != networkArtisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(networkArtisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkArtisianExists(id))
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

        // POST: api/NetworkArtisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NetworkArtisian>> PostNetworkArtisian(NetworkArtisian networkArtisian)
        {
          if (_context.NetworkArtisians == null)
          {
              return Problem("Entity set 'ArtisianContext.NetworkArtisians'  is null.");
          }
            _context.NetworkArtisians.Add(networkArtisian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNetworkArtisian", new { id = networkArtisian.Id }, networkArtisian);
        }

        // DELETE: api/NetworkArtisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetworkArtisian(int id)
        {
            if (_context.NetworkArtisians == null)
            {
                return NotFound();
            }
            var networkArtisian = await _context.NetworkArtisians.FindAsync(id);
            if (networkArtisian == null)
            {
                return NotFound();
            }

            _context.NetworkArtisians.Remove(networkArtisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NetworkArtisianExists(int id)
        {
            return (_context.NetworkArtisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
