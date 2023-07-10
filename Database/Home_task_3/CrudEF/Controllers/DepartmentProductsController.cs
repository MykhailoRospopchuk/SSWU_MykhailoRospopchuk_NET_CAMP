using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.DepartmentProductDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentProductsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public DepartmentProductsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DepartmentProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentProductGetDto>>> GetDepartmentProducts()
        {
          if (_context.DepartmentProducts == null)
          {
              return NotFound();
          }
            var departmentProduct = await _context.DepartmentProducts.ToListAsync();
            var departmentProductResult = _mapper.Map<IEnumerable<DepartmentProductGetDto>>(departmentProduct);
            return Ok(departmentProductResult);
        }

        // GET: api/DepartmentProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentProductGetDto>> GetDepartmentProduct(int id)
        {
          if (_context.DepartmentProducts == null)
          {
              return NotFound();
          }
            var departmentProduct = await _context.DepartmentProducts.FindAsync(id);

            if (departmentProduct == null)
            {
                return NotFound();
            }

            var departmentProductResult = _mapper.Map<DepartmentProductGetDto>(departmentProduct);
            return departmentProductResult;
        }

        // PUT: api/DepartmentProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentProductGetDto>> PutDepartmentProduct(int id, DepartmentProductGetDto departmentProductIncome)
        {
            var departmentProduct = _mapper.Map<DepartmentProduct>(departmentProductIncome);

            if (id != departmentProduct.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(departmentProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var departmentProductResult = _mapper.Map<DepartmentProductGetDto>(departmentProduct);
            return departmentProductResult;
        }

        // POST: api/DepartmentProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentProductGetDto>> PostDepartmentProduct(DepartmentProductPostDto departmentProductIncome)
        {
            var departmentProduct = _mapper.Map<DepartmentProduct>(departmentProductIncome);

            if (_context.DepartmentProducts == null)
            {
                return Problem("Entity set 'ArtisianContext.DepartmentProducts'  is null.");
            }
            _context.DepartmentProducts.Add(departmentProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentProductExists(departmentProduct.DepartmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var departmentProductResult = _mapper.Map<DepartmentProductGetDto>(departmentProduct);
            return departmentProductResult;
        }

        // DELETE: api/DepartmentProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentProduct(int id)
        {
            if (_context.DepartmentProducts == null)
            {
                return NotFound();
            }
            var departmentProduct = await _context.DepartmentProducts.FindAsync(id);
            if (departmentProduct == null)
            {
                return NotFound();
            }

            _context.DepartmentProducts.Remove(departmentProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentProductExists(int id)
        {
            return (_context.DepartmentProducts?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}
