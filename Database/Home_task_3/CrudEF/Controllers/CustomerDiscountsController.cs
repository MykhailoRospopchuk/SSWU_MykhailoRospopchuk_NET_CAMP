using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.CustomerDiscountDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDiscountsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public CustomerDiscountsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CustomerDiscounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDiscountGetDto>>> GetCustomerDiscounts()
        {
            if (_context.CustomerDiscounts == null)
            {
                return NotFound();
            }
            var discount =  await _context.CustomerDiscounts.ToListAsync();
            var discountResult = _mapper.Map<IEnumerable<CustomerDiscountGetDto>>(discount);
            return Ok(discountResult);
        }

        // GET: api/CustomerDiscounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDiscountGetDto>> GetCustomerDiscount(int id)
        {
            if (_context.CustomerDiscounts == null)
            {
                return NotFound();
            }
            var customerDiscount = await _context.CustomerDiscounts.FindAsync(id);

            if (customerDiscount == null)
            {
                return NotFound();
            }

            var customerDiscountResult = _mapper.Map<CustomerDiscountGetDto>(customerDiscount);
            return customerDiscountResult;
        }

        // PUT: api/CustomerDiscounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDiscountGetDto>> PutCustomerDiscount(int id, CustomerDiscountGetDto customerDiscountIncome)
        {
            var customerDiscount = _mapper.Map<CustomerDiscount>(customerDiscountIncome);
            if (id != customerDiscount.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerDiscount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDiscountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var customerDiscountResult = _mapper.Map<CustomerDiscountGetDto>(customerDiscount);
            return customerDiscountResult;
        }

        // POST: api/CustomerDiscounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDiscountGetDto>> PostCustomerDiscount(CustomerDiscountPostDto customerDiscountIncome)
        {
            var customerDiscount = _mapper.Map<CustomerDiscount>(customerDiscountIncome);
            if (_context.CustomerDiscounts == null)
            {
                return Problem("Entity set 'ArtisianContext.CustomerDiscounts'  is null.");
            }
            _context.CustomerDiscounts.Add(customerDiscount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerDiscountExists(customerDiscount.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            var customerDiscountResult = _mapper.Map<CustomerDiscountGetDto>(customerDiscount);
            return customerDiscountResult;
        }

        // DELETE: api/CustomerDiscounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDiscount(int id)
        {
            if (_context.CustomerDiscounts == null)
            {
                return NotFound();
            }
            var customerDiscount = await _context.CustomerDiscounts.FindAsync(id);
            if (customerDiscount == null)
            {
                return NotFound();
            }

            _context.CustomerDiscounts.Remove(customerDiscount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDiscountExists(int id)
        {
            return (_context.CustomerDiscounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
