using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.PaymentDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public PaymentsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentGetDto>>> GetPayments()
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.ToListAsync();
            var paymentResult = _mapper.Map< IEnumerable<PaymentGetDto>>(payment);
            return Ok(paymentResult);
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentGetDto>> GetPayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            var paymentResult = _mapper.Map<PaymentGetDto>(payment);
            return paymentResult;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentGetDto>> PutPayment(int id, PaymentPutDto paymentIncome)
        {
            var payment = _mapper.Map<Payment>(paymentIncome);

            if (id != payment.Id)
            {
                return BadRequest();
            }

            payment.Date = DateTime.Now;

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var paymentResult = _mapper.Map<PaymentGetDto>(payment);
            return paymentResult;
        }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentGetDto>> PostPayment(PaymentPostDto paymentIncome)
        {
            var payment = _mapper.Map<Payment>(paymentIncome);

            if (_context.Payments == null)
            {
                return Problem("Entity set 'ArtisianContext.Payments'  is null.");
            }

            payment.Date = DateTime.Now;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            var paymentResult = _mapper.Map<PaymentGetDto>(payment);
            return paymentResult;
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return (_context.Payments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
