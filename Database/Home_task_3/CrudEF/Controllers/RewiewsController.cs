using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.Rewiew;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewiewsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public RewiewsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Rewiews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RewiewGetDto>>> GetRewiews()
        {
          if (_context.Rewiews == null)
          {
              return NotFound();
          }
            var rewiew = await _context.Rewiews.ToListAsync();
            var rewiewResult = _mapper.Map< IEnumerable<RewiewGetDto>>(rewiew);
            return Ok(rewiewResult);
        }

        // GET: api/Rewiews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RewiewGetDto>> GetRewiew(int id)
        {
          if (_context.Rewiews == null)
          {
              return NotFound();
          }
            var rewiew = await _context.Rewiews.FindAsync(id);

            if (rewiew == null)
            {
                return NotFound();
            }

            var rewiewResult = _mapper.Map<RewiewGetDto>(rewiew);
            return rewiewResult;
        }

        // PUT: api/Rewiews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<RewiewGetDto>> PutRewiew(int id, RewiewGetDto rewiewIncome)
        {
            var rewiew = _mapper.Map<Rewiew>(rewiewIncome);

            if (id != rewiew.Id)
            {
                return BadRequest();
            }

            _context.Entry(rewiew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RewiewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var rewiewResult = _mapper.Map<RewiewGetDto>(rewiew);
            return rewiewResult;
        }

        // POST: api/Rewiews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RewiewGetDto>> PostRewiew(RewiewPostDto rewiewIncome)
        {
            var rewiew = _mapper.Map<Rewiew>(rewiewIncome);

            if (_context.Rewiews == null)
            {
                return Problem("Entity set 'ArtisianContext.Rewiews'  is null.");
            }
            _context.Rewiews.Add(rewiew);
            await _context.SaveChangesAsync();

            var rewiewResult = _mapper.Map<RewiewGetDto>(rewiew);
            return rewiewResult;
        }

        // DELETE: api/Rewiews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRewiew(int id)
        {
            if (_context.Rewiews == null)
            {
                return NotFound();
            }
            var rewiew = await _context.Rewiews.FindAsync(id);
            if (rewiew == null)
            {
                return NotFound();
            }

            _context.Rewiews.Remove(rewiew);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RewiewExists(int id)
        {
            return (_context.Rewiews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
