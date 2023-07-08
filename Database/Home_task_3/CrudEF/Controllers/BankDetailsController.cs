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
    public class BankDetailsController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public BankDetailsController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/BankDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankDetail>>> GetBankDetails()
        {
          if (_context.BankDetails == null)
          {
              return NotFound();
          }
            return await _context.BankDetails.ToListAsync();
        }

        // GET: api/BankDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankDetail>> GetBankDetail(int id)
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

            return bankDetail;
        }

        // PUT: api/BankDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankDetail(int id, BankDetail bankDetail)
        {
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

            return NoContent();
        }

        // POST: api/BankDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankDetail>> PostBankDetail(BankDetail bankDetail)
        {
          if (_context.BankDetails == null)
          {
              return Problem("Entity set 'ArtisianContext.BankDetails'  is null.");
          }
            _context.BankDetails.Add(bankDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankDetail", new { id = bankDetail.Id }, bankDetail);
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
