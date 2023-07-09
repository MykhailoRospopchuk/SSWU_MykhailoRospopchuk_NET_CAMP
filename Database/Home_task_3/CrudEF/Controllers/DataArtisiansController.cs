using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.DataArtisianDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataArtisiansController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public DataArtisiansController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DataArtisians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataArtisianGetDto>>> GetDataArtisians()
        {
          if (_context.DataArtisians == null)
          {
              return NotFound();
          }
            var dataArtisian =  await _context.DataArtisians.ToListAsync();
            var dataArtisianResult = _mapper.Map<IEnumerable<DataArtisianGetDto>>(dataArtisian);
            return Ok(dataArtisianResult);
        }

        // GET: api/DataArtisians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataArtisianGetDto>> GetDataArtisian(int id)
        {
          if (_context.DataArtisians == null)
          {
              return NotFound();
          }
            var dataArtisian = await _context.DataArtisians.FindAsync(id);

            if (dataArtisian == null)
            {
                return NotFound();
            }

            var dataArtisianResult = _mapper.Map<DataArtisianGetDto>(dataArtisian);
            return dataArtisianResult;
        }

        // PUT: api/DataArtisians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DataArtisianGetDto>> PutDataArtisian(int id, DataArtisianGetDto dataArtisianIncome)
        {
            var dataArtisian = _mapper.Map<DataArtisian>(dataArtisianIncome);

            if (id != dataArtisian.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataArtisian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataArtisianExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var dataArtisianResult = _mapper.Map<DataArtisianGetDto>(dataArtisian);
            return dataArtisianResult;
        }

        // POST: api/DataArtisians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataArtisianGetDto>> PostDataArtisian(DataArtisianPostDto dataArtisianIncome)
        {
            var dataArtisian = _mapper.Map<DataArtisian>(dataArtisianIncome);
            if (_context.DataArtisians == null)
            {
                return Problem("Entity set 'ArtisianContext.DataArtisians'  is null.");
            }
            _context.DataArtisians.Add(dataArtisian);
            await _context.SaveChangesAsync();

            var dataArtisianResult = _mapper.Map<DataArtisianGetDto>(dataArtisian);
            return dataArtisianResult;
        }

        // DELETE: api/DataArtisians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataArtisian(int id)
        {
            if (_context.DataArtisians == null)
            {
                return NotFound();
            }
            var dataArtisian = await _context.DataArtisians.FindAsync(id);
            if (dataArtisian == null)
            {
                return NotFound();
            }

            _context.DataArtisians.Remove(dataArtisian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataArtisianExists(int id)
        {
            return (_context.DataArtisians?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
