using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDiscountsController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public CustomerDiscountsController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDiscounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDiscount>>> GetCustomerDiscounts()
        {
          if (_context.CustomerDiscounts == null)
          {
              return NotFound();
          }
            return await _context.CustomerDiscounts.ToListAsync();
        }

        // GET: api/CustomerDiscounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDiscount>> GetCustomerDiscount(int id)
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

            return customerDiscount;
        }

        // PUT: api/CustomerDiscounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDiscount(int id, CustomerDiscount customerDiscount)
        {
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

            return NoContent();
        }

        // POST: api/CustomerDiscounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDiscount>> PostCustomerDiscount(CustomerDiscount customerDiscount)
        {
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

            return CreatedAtAction("GetCustomerDiscount", new { id = customerDiscount.Id }, customerDiscount);
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
