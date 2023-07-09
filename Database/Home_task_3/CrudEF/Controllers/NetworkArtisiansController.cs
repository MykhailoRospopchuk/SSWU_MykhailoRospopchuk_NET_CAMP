using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.NetworkArtisian;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public NetworkArtisiansController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/NetworkArtisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NetworkArtisianGetDto>>> GetNetworkArtisians()
        {
          if (_context.NetworkArtisians == null)
          {
              return NotFound();
          }
            var networkArtisian = await _context.NetworkArtisians.ToListAsync();
            var networkArtisianResult = _mapper.Map<IEnumerable<NetworkArtisianGetDto>>(networkArtisian);
            return Ok(networkArtisianResult);
        }

        // GET: api/NetworkArtisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NetworkArtisianGetDto>> GetNetworkArtisian(int id)
        {
          if (_context.NetworkArtisians == null)
          {
              return NotFound();
          }
            var networkArtisian = await _context.NetworkArtisians.FindAsync(id);

            if (networkArtisian == null)
            {
                return NotFound();
            }
            var networkArtisianResult = _mapper.Map<NetworkArtisianGetDto>(networkArtisian);
            return networkArtisianResult;
        }

        // PUT: api/NetworkArtisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<NetworkArtisianGetDto>> PutNetworkArtisian(int id, NetworkArtisianGetDto networkArtisianIncome)
        {
            var networkArtisian = _mapper.Map<NetworkArtisian>(networkArtisianIncome);

            if (id != networkArtisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(networkArtisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkArtisianExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var networkArtisianResult = _mapper.Map<NetworkArtisianGetDto>(networkArtisian);
            return networkArtisianResult;
        }

        // POST: api/NetworkArtisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NetworkArtisianGetDto>> PostNetworkArtisian(NetworkArtisianPostDto networkArtisianIncome)
        {
            var networkArtisian = _mapper.Map<NetworkArtisian>(networkArtisianIncome);
            if (_context.NetworkArtisians == null)
            {
                return Problem("Entity set 'ArtisianContext.NetworkArtisians'  is null.");
            }
            _context.NetworkArtisians.Add(networkArtisian);
            await _context.SaveChangesAsync();

            var networkArtisianResult = _mapper.Map<NetworkArtisianGetDto>(networkArtisian);
            return networkArtisianResult;
        }

        // DELETE: api/NetworkArtisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetworkArtisian(int id)
        {
            if (_context.NetworkArtisians == null)
            {
                return NotFound();
            }
            var networkArtisian = await _context.NetworkArtisians.FindAsync(id);
            if (networkArtisian == null)
            {
                return NotFound();
            }

            _context.NetworkArtisians.Remove(networkArtisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NetworkArtisianExists(int id)
        {
            return (_context.NetworkArtisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
