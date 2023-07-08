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
    public class DepartmentManufactoriesController : ControllerBase
    {
        private readonly ArtisianContext _context;

        public DepartmentManufactoriesController(ArtisianContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentManufactories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentManufactory>>> GetDepartmentManufactories()
        {
          if (_context.DepartmentManufactories == null)
          {
              return NotFound();
          }
            return await _context.DepartmentManufactories.ToListAsync();
        }

        // GET: api/DepartmentManufactories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentManufactory>> GetDepartmentManufactory(int id)
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

            return departmentManufactory;
        }

        // PUT: api/DepartmentManufactories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentManufactory(int id, DepartmentManufactory departmentManufactory)
        {
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

            return NoContent();
        }

        // POST: api/DepartmentManufactories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentManufactory>> PostDepartmentManufactory(DepartmentManufactory departmentManufactory)
        {
          if (_context.DepartmentManufactories == null)
          {
              return Problem("Entity set 'ArtisianContext.DepartmentManufactories'  is null.");
          }
            _context.DepartmentManufactories.Add(departmentManufactory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentManufactory", new { id = departmentManufactory.Id }, departmentManufactory);
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
