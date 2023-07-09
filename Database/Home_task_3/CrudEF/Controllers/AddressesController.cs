using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using CrudEF.ModelMapper.AddressDto;
using AutoMapper;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public AddressesController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressGetDto>>> GetAddresses()
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses.ToListAsync();
            var addressResult = _mapper.Map<IEnumerable<AddressGetDto>>(address);
            return Ok(addressResult);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressGetDto>> GetAddress(int id)
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }
            var addressResult = _mapper.Map<AddressGetDto>(address);

            return addressResult;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressGetDto>> PutAddress(int id, AddressGetDto addressIncome)
        {
            var address = _mapper.Map<Address>(addressIncome);

            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var addressResult = _mapper.Map<AddressGetDto>(address);
            return addressResult;
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressGetDto>> PostAddress(AddressPostDto addressIncome)
        {
            var address = _mapper.Map<Address>(addressIncome);
            if (_context.Addresses == null)
            {
                return Problem("Entity set 'ArtisianContext.Addresses'  is null.");
            }
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            var addressResult = _mapper.Map<AddressGetDto>(address);
            return addressResult;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AddressExists(int id)
        {
            return (_context.Addresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
