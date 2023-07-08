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
    public class DeliveryProvidersController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public DeliveryProvidersController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryProvider>>> GetDeliveryProviders()
        {
          if (_context.DeliveryProviders == null)
          {
              return NotFound();
          }
            return await _context.DeliveryProviders.ToListAsync();
        }

        // GET: api/DeliveryProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryProvider>> GetDeliveryProvider(int id)
        {
          if (_context.DeliveryProviders == null)
          {
              return NotFound();
          }
            var deliveryProvider = await _context.DeliveryProviders.FindAsync(id);

            if (deliveryProvider == null)
            {
                return NotFound();
            }

            return deliveryProvider;
        }

        // PUT: api/DeliveryProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryProvider(int id, DeliveryProvider deliveryProvider)
        {
            if (id != deliveryProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryProviderExists(id))
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

        // POST: api/DeliveryProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryProvider>> PostDeliveryProvider(DeliveryProvider deliveryProvider)
        {
          if (_context.DeliveryProviders == null)
          {
              return Problem("Entity set 'ArtisianContext.DeliveryProviders'  is null.");
          }
            _context.DeliveryProviders.Add(deliveryProvider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryProvider", new { id = deliveryProvider.Id }, deliveryProvider);
        }

        // DELETE: api/DeliveryProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryProvider(int id)
        {
            if (_context.DeliveryProviders == null)
            {
                return NotFound();
            }
            var deliveryProvider = await _context.DeliveryProviders.FindAsync(id);
            if (deliveryProvider == null)
            {
                return NotFound();
            }

            _context.DeliveryProviders.Remove(deliveryProvider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryProviderExists(int id)
        {
            return (_context.DeliveryProviders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
