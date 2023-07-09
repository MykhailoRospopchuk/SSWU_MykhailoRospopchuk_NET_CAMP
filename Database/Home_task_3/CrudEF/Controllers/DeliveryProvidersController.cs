using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.DeliveryProviderDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryProvidersController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public DeliveryProvidersController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DeliveryProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryProviderGetDto>>> GetDeliveryProviders()
        {
          if (_context.DeliveryProviders == null)
          {
              return NotFound();
          }
            var deliveryProvider = await _context.DeliveryProviders.ToListAsync();
            var deliveryProviderResult = _mapper.Map< IEnumerable<DeliveryProviderGetDto>>(deliveryProvider);
            return Ok(deliveryProviderResult);
        }

        // GET: api/DeliveryProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryProviderGetDto>> GetDeliveryProvider(int id)
        {
          if (_context.DeliveryProviders == null)
          {
              return NotFound();
          }
            var deliveryProvider = await _context.DeliveryProviders.FindAsync(id);

            if (deliveryProvider == null)
            {
                return NotFound();
            }

            var deliveryProviderResult = _mapper.Map<DeliveryProviderGetDto>(deliveryProvider);
            return deliveryProviderResult;
        }

        // PUT: api/DeliveryProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryProviderGetDto>> PutDeliveryProvider(int id, DeliveryProviderGetDto deliveryProviderIncome)
        {
            var deliveryProvider = _mapper.Map<DeliveryProvider>(deliveryProviderIncome);

            if (id != deliveryProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryProviderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var deliveryProviderResult = _mapper.Map<DeliveryProviderGetDto>(deliveryProvider);
            return deliveryProviderResult;
        }

        // POST: api/DeliveryProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryProviderGetDto>> PostDeliveryProvider(DeliveryProviderPostDto deliveryProviderIncome)
        {
            var deliveryProvider = _mapper.Map<DeliveryProvider>(deliveryProviderIncome);

            if (_context.DeliveryProviders == null)
            {
                return Problem("Entity set 'ArtisianContext.DeliveryProviders'  is null.");
            }
            _context.DeliveryProviders.Add(deliveryProvider);
            await _context.SaveChangesAsync();

            var deliveryProviderResult = _mapper.Map<DeliveryProviderGetDto>(deliveryProvider);
            return deliveryProviderResult;
        }

        // DELETE: api/DeliveryProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryProvider(int id)
        {
            if (_context.DeliveryProviders == null)
            {
                return NotFound();
            }
            var deliveryProvider = await _context.DeliveryProviders.FindAsync(id);
            if (deliveryProvider == null)
            {
                return NotFound();
            }

            _context.DeliveryProviders.Remove(deliveryProvider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryProviderExists(int id)
        {
            return (_context.DeliveryProviders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
