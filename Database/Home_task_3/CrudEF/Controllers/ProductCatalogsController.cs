using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ProductCatalog;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ProductCatalogsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProductCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCatalogGetDto>>> GetProductCatalogs()
        {
          if (_context.ProductCatalogs == null)
          {
              return NotFound();
          }
            var productCatalog = await _context.ProductCatalogs.ToListAsync();
            var productCatalogResult = _mapper.Map< IEnumerable<ProductCatalogGetDto>>(productCatalog);
            return Ok(productCatalogResult);
        }

        // GET: api/ProductCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCatalogGetDto>> GetProductCatalog(int id)
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

            var productCatalogResult = _mapper.Map<ProductCatalogGetDto>(productCatalog);
            return productCatalogResult;
        }

        // PUT: api/ProductCatalogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCatalogGetDto>> PutProductCatalog(int id, ProductCatalogGetDto productCatalogIncome)
        {
            var productCatalog = _mapper.Map<ProductCatalog>(productCatalogIncome);

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

            var productCatalogResult = _mapper.Map<ProductCatalogGetDto>(productCatalog);
            return productCatalogResult;
        }

        // POST: api/ProductCatalogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCatalogGetDto>> PostProductCatalog(ProductCatalogPostDto productCatalogIncome)
        {
            var productCatalog = _mapper.Map<ProductCatalog>(productCatalogIncome);

            if (_context.ProductCatalogs == null)
            {
                return Problem("Entity set 'ArtisianContext.ProductCatalogs'  is null.");
            }
            _context.ProductCatalogs.Add(productCatalog);
            await _context.SaveChangesAsync();

            var productCatalogResult = _mapper.Map<ProductCatalogGetDto>(productCatalog);
            return productCatalogResult;
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
