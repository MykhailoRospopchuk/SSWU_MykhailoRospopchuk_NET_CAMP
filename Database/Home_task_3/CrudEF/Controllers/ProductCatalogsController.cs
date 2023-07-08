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
    public class ProductCatalogsController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public ProductCatalogsController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/ProductCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCatalog>>> GetProductCatalogs()
        {
          if (_context.ProductCatalogs == null)
          {
              return NotFound();
          }
            return await _context.ProductCatalogs.ToListAsync();
        }

        // GET: api/ProductCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCatalog>> GetProductCatalog(int id)
        {
          if (_context.ProductCatalogs == null)
          {
              return NotFound();
          }
            var productCatalog = await _context.ProductCatalogs.FindAsync(id);

            if (productCatalog == null)
            {
                return NotFound();
            }

            return productCatalog;
        }

        // PUT: api/ProductCatalogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCatalog(int id, ProductCatalog productCatalog)
        {
            if (id != productCatalog.Id)
            {
                return BadRequest();
            }

            _context.Entry(productCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCatalogExists(id))
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

        // POST: api/ProductCatalogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCatalog>> PostProductCatalog(ProductCatalog productCatalog)
        {
          if (_context.ProductCatalogs == null)
          {
              return Problem("Entity set 'ArtisianContext.ProductCatalogs'  is null.");
          }
            _context.ProductCatalogs.Add(productCatalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCatalog", new { id = productCatalog.Id }, productCatalog);
        }

        // DELETE: api/ProductCatalogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCatalog(int id)
        {
            if (_context.ProductCatalogs == null)
            {
                return NotFound();
            }
            var productCatalog = await _context.ProductCatalogs.FindAsync(id);
            if (productCatalog == null)
            {
                return NotFound();
            }

            _context.ProductCatalogs.Remove(productCatalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCatalogExists(int id)
        {
            return (_context.ProductCatalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
