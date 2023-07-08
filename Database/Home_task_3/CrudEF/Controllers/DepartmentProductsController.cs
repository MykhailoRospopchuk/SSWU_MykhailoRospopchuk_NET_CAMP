using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentProductsController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public DepartmentProductsController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentProduct>>> GetDepartmentProducts()
        {
          if (_context.DepartmentProducts == null)
          {
              return NotFound();
          }
            return await _context.DepartmentProducts.ToListAsync();
        }

        // GET: api/DepartmentProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentProduct>> GetDepartmentProduct(int id)
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

            return departmentProduct;
        }

        // PUT: api/DepartmentProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentProduct(int id, DepartmentProduct departmentProduct)
        {
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

            return NoContent();
        }

        // POST: api/DepartmentProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentProduct>> PostDepartmentProduct(DepartmentProduct departmentProduct)
        {
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

            return CreatedAtAction("GetDepartmentProduct", new { id = departmentProduct.DepartmentId }, departmentProduct);
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
