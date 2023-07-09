using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.BankDetail;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public BankDetailsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BankDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankDetailGetDto>>> GetBankDetails()
        {
          if (_context.BankDetails == null)
          {
              return NotFound();
          }
            var bankDetail =  await _context.BankDetails.ToListAsync();
            var bankDetailResult = _mapper.Map<IEnumerable<BankDetailGetDto>>(bankDetail);
            return Ok(bankDetailResult);
        }

        // GET: api/BankDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankDetailGetDto>> GetBankDetail(int id)
        {
          if (_context.BankDetails == null)
          {
              return NotFound();
          }
            var bankDetail = await _context.BankDetails.FindAsync(id);

            if (bankDetail == null)
            {
                return NotFound();
            }

            var bankDetailResult = _mapper.Map<BankDetailGetDto>(bankDetail);

            return bankDetailResult;
        }

        // PUT: api/BankDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<BankDetailGetDto>> PutBankDetail(int id, BankDetailGetDto bankDetailIncome)
        {
            var bankDetail = _mapper.Map<BankDetail>(bankDetailIncome);

            if (id != bankDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(bankDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var bankDetailResult = _mapper.Map<BankDetailGetDto>(bankDetail);
            return bankDetailResult;
        }

        // POST: api/BankDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankDetailGetDto>> PostBankDetail(BankDetailPostDto bankDetailIncome)
        {
            var bankDetail = _mapper.Map<BankDetail>(bankDetailIncome);
            if (_context.BankDetails == null)
            {
                return Problem("Entity set 'ArtisianContext.BankDetails'  is null.");
            }
            _context.BankDetails.Add(bankDetail);
            await _context.SaveChangesAsync();

            var bankDetailResult = _mapper.Map<BankDetailGetDto>(bankDetail);

            return bankDetailResult;
        }

        // DELETE: api/BankDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankDetail(int id)
        {
            if (_context.BankDetails == null)
            {
                return NotFound();
            }
            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail == null)
            {
                return NotFound();
            }

            _context.BankDetails.Remove(bankDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankDetailExists(int id)
        {
            return (_context.BankDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
