using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.PaymentMethodDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public PaymentMethodsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodGetDto>>> GetPaymentMethods()
        {
          if (_context.PaymentMethods == null)
          {
              return NotFound();
          }
            var paymentMethod = await _context.PaymentMethods.ToListAsync();
            var paymentMethodResult = _mapper.Map< IEnumerable<PaymentMethodGetDto>>(paymentMethod);
            return Ok(paymentMethodResult);
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodGetDto>> GetPaymentMethod(int id)
        {
          if (_context.PaymentMethods == null)
          {
              return NotFound();
          }
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            var paymentMethodResult = _mapper.Map<PaymentMethodGetDto>(paymentMethod);
            return paymentMethodResult;
        }

        // PUT: api/PaymentMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentMethodGetDto>> PutPaymentMethod(int id, PaymentMethodGetDto paymentMethodIncome)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodIncome);

            if (id != paymentMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var paymentMethodResult = _mapper.Map<PaymentMethodGetDto>(paymentMethod);
            return paymentMethodResult;
        }

        // POST: api/PaymentMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentMethodGetDto>> PostPaymentMethod(PaymentMethodPostDto paymentMethodIncome)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodIncome);

            if (_context.PaymentMethods == null)
            {
                return Problem("Entity set 'ArtisianContext.PaymentMethods'  is null.");
            }
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();

            var paymentMethodResult = _mapper.Map<PaymentMethodGetDto>(paymentMethod);
            return paymentMethodResult;
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            if (_context.PaymentMethods == null)
            {
                return NotFound();
            }
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentMethodExists(int id)
        {
            return (_context.PaymentMethods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
