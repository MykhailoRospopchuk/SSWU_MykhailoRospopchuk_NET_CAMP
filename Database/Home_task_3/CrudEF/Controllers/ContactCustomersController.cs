using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ContactCustomerDto;
using CrudEF.ModelMapper.AddressDto;
using System.Net;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCustomersController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ContactCustomersController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ContactCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactCustomerGetDto>>> GetContactCustomers()
        {
          if (_context.ContactCustomers == null)
          {
              return NotFound();
          }
            var contactCustomer = await _context.ContactCustomers.ToListAsync();
            var contactCustomerResult = _mapper.Map<IEnumerable<ContactCustomerGetDto>>(contactCustomer);
            return Ok(contactCustomerResult);
        }

        // GET: api/ContactCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactCustomerGetDto>> GetContactCustomer(int id)
        {
          if (_context.ContactCustomers == null)
          {
              return NotFound();
          }
            var contactCustomer = await _context.ContactCustomers.FindAsync(id);

            if (contactCustomer == null)
            {
                return NotFound();
            }

            var contactCustomerResult = _mapper.Map<ContactCustomerGetDto>(contactCustomer);
            return contactCustomerResult;
        }

        // PUT: api/ContactCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactCustomerGetDto>> PutContactCustomer(int id, ContactCustomerGetDto contactCustomerIncome)
        {
            var contactCustomer = _mapper.Map<ContactCustomer>(contactCustomerIncome);
            if (id != contactCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactCustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var contactCustomerResult = _mapper.Map<ContactCustomerGetDto>(contactCustomer);
            return contactCustomerResult;
        }

        // POST: api/ContactCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactCustomerGetDto>> PostContactCustomer(ContactCustomerPostDto contactCustomerIncome)
        {
            var contactCustomer = _mapper.Map<ContactCustomer>(contactCustomerIncome);
            if (_context.ContactCustomers == null)
            {
                return Problem("Entity set 'ArtisianContext.ContactCustomers'  is null.");
            }
            _context.ContactCustomers.Add(contactCustomer);
            await _context.SaveChangesAsync();

            var contactCustomerResult = _mapper.Map<ContactCustomerGetDto>(contactCustomer);
            return contactCustomerResult;
        }

        // DELETE: api/ContactCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactCustomer(int id)
        {
            if (_context.ContactCustomers == null)
            {
                return NotFound();
            }
            var contactCustomer = await _context.ContactCustomers.FindAsync(id);
            if (contactCustomer == null)
            {
                return NotFound();
            }

            _context.ContactCustomers.Remove(contactCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactCustomerExists(int id)
        {
            return (_context.ContactCustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
