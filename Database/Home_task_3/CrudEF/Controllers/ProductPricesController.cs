using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ProductPriceDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPricesController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ProductPricesController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProductPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPriceGetDto>>> GetProductPrices()
        {
          if (_context.ProductPrices == null)
          {
              return NotFound();
          }
            var productPrice = await _context.ProductPrices.ToListAsync();
            var productPriceResult = _mapper.Map< IEnumerable<ProductPriceGetDto>>(productPrice);
            return Ok(productPriceResult);
        }

        // GET: api/ProductPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPriceGetDto>> GetProductPrice(int id)
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

            var productPriceResult = _mapper.Map<ProductPriceGetDto>(productPrice);
            return productPriceResult;
        }

        // PUT: api/ProductPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductPriceGetDto>> PutProductPrice(int id, ProductPricePutDto productPriceIncome)
        {
            var productPrice = _mapper.Map<ProductPrice>(productPriceIncome);

            if (id != productPrice.Id)
            {
                return BadRequest();
            }

            var productFormDB = await _context.ProductPrices.FindAsync(productPrice.Id);

            productPrice.BeginDate = productFormDB.BeginDate;

            productFormDB.EndDate = productPrice.EndDate;
            productFormDB.Price = productPrice.Price;

            _context.Entry(productFormDB).State = EntityState.Modified;

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

            var productPriceResult = _mapper.Map<ProductPriceGetDto>(productFormDB);
            return productPriceResult;
        }

        // POST: api/ProductPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPriceGetDto>> PostProductPrice(ProductPricePostDto productPriceIncome)
        {
            var productPrice = _mapper.Map<ProductPrice>(productPriceIncome);

            if (_context.ProductPrices == null)
            {
                return Problem("Entity set 'ArtisianContext.ProductPrices'  is null.");
            }
            _context.ProductPrices.Add(productPrice);
            await _context.SaveChangesAsync();

            var productPriceResult = _mapper.Map<ProductPriceGetDto>(productPrice);
            return productPriceResult;
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
