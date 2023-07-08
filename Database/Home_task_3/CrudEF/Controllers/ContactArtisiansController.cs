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
    public class ContactArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public ContactArtisiansController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/ContactArtisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactArtisian>>> GetContactArtisians()
        {
          if (_context.ContactArtisians == null)
          {
              return NotFound();
          }
            return await _context.ContactArtisians.ToListAsync();
        }

        // GET: api/ContactArtisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactArtisian>> GetContactArtisian(long id)
        {
          if (_context.ContactArtisians == null)
          {
              return NotFound();
          }
            var contactArtisian = await _context.ContactArtisians.FindAsync(id);

            if (contactArtisian == null)
            {
                return NotFound();
            }

            return contactArtisian;
        }

        // PUT: api/ContactArtisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactArtisian(long id, ContactArtisian contactArtisian)
        {
            if (id != contactArtisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactArtisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactArtisianExists(id))
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

        // POST: api/ContactArtisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactArtisian>> PostContactArtisian(ContactArtisian contactArtisian)
        {
          if (_context.ContactArtisians == null)
          {
              return Problem("Entity set 'ArtisianContext.ContactArtisians'  is null.");
          }
            _context.ContactArtisians.Add(contactArtisian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactArtisian", new { id = contactArtisian.Id }, contactArtisian);
        }

        // DELETE: api/ContactArtisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactArtisian(long id)
        {
            if (_context.ContactArtisians == null)
            {
                return NotFound();
            }
            var contactArtisian = await _context.ContactArtisians.FindAsync(id);
            if (contactArtisian == null)
            {
                return NotFound();
            }

            _context.ContactArtisians.Remove(contactArtisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactArtisianExists(long id)
        {
            return (_context.ContactArtisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
