using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.CategoryDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetCategories()
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            var category = await _context.Categories.ToListAsync();
            var categoryResult = _mapper.Map<IEnumerable<CategoryGetDto>>(category);
            return Ok(categoryResult);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetDto>> GetCategory(int id)
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryResult = _mapper.Map<CategoryGetDto>(category);
            return categoryResult;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryGetDto>> PutCategory(int id, CategoryGetDto categoryIncome)
        {
            var category = _mapper.Map<Category>(categoryIncome);

            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var categoryResult = _mapper.Map<CategoryGetDto>(category);
            return categoryResult;
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryGetDto>> PostCategory(CategoryPostDto categoryIncome)
        {
            var category = _mapper.Map<Category>(categoryIncome);
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ArtisianContext.Categories'  is null.");
            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryResult = _mapper.Map<CategoryGetDto>(category);
            return categoryResult;
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
