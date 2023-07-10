using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ManufactoryHub;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactoryHubsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ManufactoryHubsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ManufactoryHubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufactoryHubGetDto>>> GetManufactoryHubs()
        {
          if (_context.ManufactoryHubs == null)
          {
              return NotFound();
          }
            var manufactoryHub = await _context.ManufactoryHubs.ToListAsync();
            var manufactoryHubResult = _mapper.Map<IEnumerable<ManufactoryHubGetDto>>(manufactoryHub);
            return Ok(manufactoryHubResult);
        }

        // GET: api/ManufactoryHubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufactoryHubGetDto>> GetManufactoryHub(int id)
        {
          if (_context.ManufactoryHubs == null)
          {
              return NotFound();
          }
            var manufactoryHub = await _context.ManufactoryHubs.FindAsync(id);

            if (manufactoryHub == null)
            {
                return NotFound();
            }

            var manufactoryHubResult = _mapper.Map<ManufactoryHubGetDto>(manufactoryHub);
            return manufactoryHubResult;
        }

        // PUT: api/ManufactoryHubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ManufactoryHubGetDto>> PutManufactoryHub(int id, ManufactoryHubGetDto manufactoryHubIncome)
        {
            var manufactoryHub = _mapper.Map<ManufactoryHub>(manufactoryHubIncome);

            if (id != manufactoryHub.Id)
            {
                return BadRequest();
            }

            _context.Entry(manufactoryHub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufactoryHubExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var manufactoryHubResult = _mapper.Map<ManufactoryHubGetDto>(manufactoryHub);
            return manufactoryHubResult;
        }

        // POST: api/ManufactoryHubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManufactoryHubGetDto>> PostManufactoryHub(ManufactoryHubPostDto manufactoryHubIncome)
        {
            var manufactoryHub = _mapper.Map<ManufactoryHub>(manufactoryHubIncome);
            if (_context.ManufactoryHubs == null)
            {
                return Problem("Entity set 'ArtisianContext.ManufactoryHubs'  is null.");
            }
            _context.ManufactoryHubs.Add(manufactoryHub);
            await _context.SaveChangesAsync();

            var manufactoryHubResult = _mapper.Map<ManufactoryHubGetDto>(manufactoryHub);
            return manufactoryHubResult;
        }

        // DELETE: api/ManufactoryHubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufactoryHub(int id)
        {
            if (_context.ManufactoryHubs == null)
            {
                return NotFound();
            }
            var manufactoryHub = await _context.ManufactoryHubs.FindAsync(id);
            if (manufactoryHub == null)
            {
                return NotFound();
            }

            _context.ManufactoryHubs.Remove(manufactoryHub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufactoryHubExists(int id)
        {
            return (_context.ManufactoryHubs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
