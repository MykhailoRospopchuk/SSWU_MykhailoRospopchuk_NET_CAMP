using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.ArtisianDto;
using CrudEF.ModelMapper.AddressDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public ArtisiansController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Artisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtisianGetDto>>> GetArtisians()
        {
            if (_context.Artisians == null)
            {
                return NotFound();
            }
            var artisian = await _context.Artisians.ToListAsync();
            var artisianResult = _mapper.Map<IEnumerable<ArtisianGetDto>>(artisian);
            return Ok(artisianResult);
        }

        // GET: api/Artisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtisianGetDto>> GetArtisian(int id)
        {
          if (_context.Artisians == null)
          {
              return NotFound();
          }
            var artisian = await _context.Artisians.FindAsync(id);

            if (artisian == null)
            {
                return NotFound();
            }

            var artisianResult = _mapper.Map<ArtisianGetDto>(artisian);
            return artisianResult;
        }

        // PUT: api/Artisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ArtisianGetDto>> PutArtisian(int id, ArtisianGetDto artisianIncome)
        {
            var artisian = _mapper.Map<Artisian>(artisianIncome);

            if (id != artisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(artisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtisianExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var artisianResult = _mapper.Map<ArtisianGetDto>(artisian);
            return artisianResult;
        }

        // POST: api/Artisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtisianGetDto>> PostArtisian(ArtisianPostDto artisianIncome)
        {
            var artisian = _mapper.Map<Artisian>(artisianIncome);
            if (_context.Artisians == null)
            {
                return Problem("Entity set 'ArtisianContext.Artisians'  is null.");
            }
            _context.Artisians.Add(artisian);
            await _context.SaveChangesAsync();

            var artisianResult = _mapper.Map<ArtisianGetDto>(artisian);
            return artisianResult;
        }

        // DELETE: api/Artisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtisian(int id)
        {
            if (_context.Artisians == null)
            {
                return NotFound();
            }
            var artisian = await _context.Artisians.FindAsync(id);
            if (artisian == null)
            {
                return NotFound();
            }

            _context.Artisians.Remove(artisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtisianExists(int id)
        {
            return (_context.Artisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
