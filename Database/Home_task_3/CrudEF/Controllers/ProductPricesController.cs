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
    public class ProductPricesController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public ProductPricesController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/ProductPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> GetProductPrices()
        {
          if (_context.ProductPrices == null)
          {
              return NotFound();
          }
            return await _context.ProductPrices.ToListAsync();
        }

        // GET: api/ProductPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPrice>> GetProductPrice(int id)
        {
          if (_context.ProductPrices == null)
          {
              return NotFound();
          }
            var productPrice = await _context.ProductPrices.FindAsync(id);

            if (productPrice == null)
            {
                return NotFound();
            }

            return productPrice;
        }

        // PUT: api/ProductPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPrice(int id, ProductPrice productPrice)
        {
            if (id != productPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(productPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPriceExists(id))
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

        // POST: api/ProductPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPrice>> PostProductPrice(ProductPrice productPrice)
        {
          if (_context.ProductPrices == null)
          {
              return Problem("Entity set 'ArtisianContext.ProductPrices'  is null.");
          }
            _context.ProductPrices.Add(productPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPrice", new { id = productPrice.Id }, productPrice);
        }

        // DELETE: api/ProductPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPrice(int id)
        {
            if (_context.ProductPrices == null)
            {
                return NotFound();
            }
            var productPrice = await _context.ProductPrices.FindAsync(id);
            if (productPrice == null)
            {
                return NotFound();
            }

            _context.ProductPrices.Remove(productPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductPriceExists(int id)
        {
            return (_context.ProductPrices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
