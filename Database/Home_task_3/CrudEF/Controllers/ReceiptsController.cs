using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ReceiptDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ReceiptsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptGetDto>>> GetReceipts()
        {
            if (_context.Receipts == null)
            {
                return NotFound();
            }
            var receipt = await _context.Receipts.ToListAsync();
            var receiptResult = _mapper.Map< IEnumerable<ReceiptGetDto>>(receipt);
            return Ok(receiptResult);
        }

        // GET: api/Receipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptGetDto>> GetReceipt(int id)
        {
          if (_context.Receipts == null)
          {
              return NotFound();
          }
            var receipt = await _context.Receipts.FindAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            var receiptResult = _mapper.Map<ReceiptGetDto>(receipt);
            return receiptResult;
        }

        // PUT: api/Receipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ReceiptGetDto>> PutReceipt(int id, ReceiptGetDto receiptIncome)
        {
            var receipt = _mapper.Map<Receipt>(receiptIncome);

            if (id != receipt.Id)
            {
                return BadRequest();
            }

            _context.Entry(receipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var receiptResult = _mapper.Map<ReceiptGetDto>(receipt);
            return receiptResult;
        }

        // POST: api/Receipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReceiptGetDto>> PostReceipt(ReceiptPostDto receiptIncome)
        {
            var receipt = _mapper.Map<Receipt>(receiptIncome);
            if (_context.Receipts == null)
            {
                return Problem("Entity set 'ArtisianContext.Receipts'  is null.");
            }
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();

            var receiptResult = _mapper.Map<ReceiptGetDto>(receipt);
            return receiptResult;
        }

        // DELETE: api/Receipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            if (_context.Receipts == null)
            {
                return NotFound();
            }
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }

            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ReceiptExists(int id)
        {
            return (_context.Receipts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
