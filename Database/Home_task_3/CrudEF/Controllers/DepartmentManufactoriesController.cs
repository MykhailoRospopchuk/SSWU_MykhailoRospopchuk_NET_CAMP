using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.DepartmentManufactoryDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentManufactoriesController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public DepartmentManufactoriesController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DepartmentManufactories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentManufactoryGetDto>>> GetDepartmentManufactories()
        {
          if (_context.DepartmentManufactories == null)
          {
              return NotFound();
          }
            var departmentManufactory = await _context.DepartmentManufactories.ToListAsync();
            var departmentManufactoryResult = _mapper.Map<IEnumerable<DepartmentManufactoryGetDto>>(departmentManufactory);
            return Ok(departmentManufactoryResult);
        }

        // GET: api/DepartmentManufactories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentManufactoryGetDto>> GetDepartmentManufactory(int id)
        {
          if (_context.DepartmentManufactories == null)
          {
              return NotFound();
          }
            var departmentManufactory = await _context.DepartmentManufactories.FindAsync(id);

            if (departmentManufactory == null)
            {
                return NotFound();
            }

            var departmentManufactoryResult = _mapper.Map<DepartmentManufactoryGetDto>(departmentManufactory);
            return departmentManufactoryResult;
        }

        // PUT: api/DepartmentManufactories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentManufactoryGetDto>> PutDepartmentManufactory(int id, DepartmentManufactoryGetDto departmentManufactoryIncome)
        {
            var departmentManufactory = _mapper.Map<DepartmentManufactory>(departmentManufactoryIncome);

            if (id != departmentManufactory.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentManufactory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentManufactoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var departmentManufactoryResult = _mapper.Map<DepartmentManufactoryGetDto>(departmentManufactory);
            return departmentManufactoryResult;
        }

        // POST: api/DepartmentManufactories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentManufactoryGetDto>> PostDepartmentManufactory(DepartmentManufactoryPostDto departmentManufactoryIncome)
        {
            var departmentManufactory = _mapper.Map<DepartmentManufactory>(departmentManufactoryIncome);

            if (_context.DepartmentManufactories == null)
            {
                return Problem("Entity set 'ArtisianContext.DepartmentManufactories'  is null.");
            }
            _context.DepartmentManufactories.Add(departmentManufactory);
            await _context.SaveChangesAsync();

            var departmentManufactoryResult = _mapper.Map<DepartmentManufactoryGetDto>(departmentManufactory);
            return departmentManufactoryResult;
        }

        // DELETE: api/DepartmentManufactories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentManufactory(int id)
        {
            if (_context.DepartmentManufactories == null)
            {
                return NotFound();
            }
            var departmentManufactory = await _context.DepartmentManufactories.FindAsync(id);
            if (departmentManufactory == null)
            {
                return NotFound();
            }

            _context.DepartmentManufactories.Remove(departmentManufactory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentManufactoryExists(int id)
        {
            return (_context.DepartmentManufactories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
