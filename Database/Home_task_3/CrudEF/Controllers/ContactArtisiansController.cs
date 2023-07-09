using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ContactArtisianDto;
using CrudEF.ModelMapper.AddressDto;
using System.Net;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ContactArtisiansController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ContactArtisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactArtisianGetDto>>> GetContactArtisians()
        {
          if (_context.ContactArtisians == null)
          {
              return NotFound();
          }
            var contactArtisian = await _context.ContactArtisians.ToListAsync();
            var contactArtisianResult = _mapper.Map<IEnumerable<ContactArtisianGetDto>>(contactArtisian);
            return Ok(contactArtisianResult);
        }

        // GET: api/ContactArtisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactArtisianGetDto>> GetContactArtisian(long id)
        {
          if (_context.ContactArtisians == null)
          {
              return NotFound();
          }
            var contactArtisian = await _context.ContactArtisians.FindAsync(id);

            if (contactArtisian == null)
            {
                return NotFound();
            }
            var contactArtisianResult = _mapper.Map<ContactArtisianGetDto>(contactArtisian);
            return contactArtisianResult;
        }

        // PUT: api/ContactArtisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactArtisianGetDto>> PutContactArtisian(long id, ContactArtisianGetDto contactArtisianIncome)
        {
            var contactArtisian = _mapper.Map<ContactArtisian>(contactArtisianIncome);
            if (id != contactArtisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactArtisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactArtisianExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var contactArtisianResult = _mapper.Map<ContactArtisianGetDto>(contactArtisian);
            return Ok(contactArtisianResult);
        }

        // POST: api/ContactArtisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactArtisianGetDto>> PostContactArtisian(ContactArtisianPostDto contactArtisianIncome)
        {
            var contactArtisian = _mapper.Map<ContactArtisian>(contactArtisianIncome);
            if (_context.ContactArtisians == null)
            {
                return Problem("Entity set 'ArtisianContext.ContactArtisians'  is null.");
            }
            _context.ContactArtisians.Add(contactArtisian);
            await _context.SaveChangesAsync();

            var contactArtisianResult = _mapper.Map<ContactArtisianGetDto>(contactArtisian);
            return contactArtisianResult;
        }

        // DELETE: api/ContactArtisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactArtisian(long id)
        {
            if (_context.ContactArtisians == null)
            {
                return NotFound();
            }
            var contactArtisian = await _context.ContactArtisians.FindAsync(id);
            if (contactArtisian == null)
            {
                return NotFound();
            }

            _context.ContactArtisians.Remove(contactArtisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactArtisianExists(long id)
        {
            return (_context.ContactArtisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
