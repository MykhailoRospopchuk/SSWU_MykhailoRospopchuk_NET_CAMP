using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.DeliveryOrderDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryOrdersController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public DeliveryOrdersController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DeliveryOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryOrderGetDto>>> GetDeliveryOrders()
        {
            if (_context.DeliveryOrders == null)
            {
                return NotFound();
            }
            var deliveryOrder = await _context.DeliveryOrders.ToListAsync();
            var deliveryOrderResult = _mapper.Map<IEnumerable<DeliveryOrderGetDto>>(deliveryOrder);
            return Ok(deliveryOrderResult);
        }

        // GET: api/DeliveryOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryOrderGetDto>> GetDeliveryOrder(int id)
        {
            if (_context.DeliveryOrders == null)
            {
                return NotFound();
            }
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);

            if (deliveryOrder == null)
            {
                return NotFound();
            }

            var deliveryOrderResult = _mapper.Map<DeliveryOrderGetDto>(deliveryOrder);
            return deliveryOrderResult;
        }

        // PUT: api/DeliveryOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryOrderGetDto>> PutDeliveryOrder(int id, DeliveryOrderGetDto deliveryOrderIncome)
        {
            var deliveryOrder = _mapper.Map<DeliveryOrder>(deliveryOrderIncome);

            if (id != deliveryOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var deliveryOrderResult = _mapper.Map<DeliveryOrderGetDto>(deliveryOrder);
            return deliveryOrderResult;
        }

        // POST: api/DeliveryOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryOrderPostDto>> PostDeliveryOrder(DeliveryOrderPostDto deliveryOrderIncome)
        {
            var deliveryOrder = _mapper.Map<DeliveryOrder>(deliveryOrderIncome);

            if (_context.DeliveryOrders == null)
            {
                return Problem("Entity set 'ArtisianContext.DeliveryOrders'  is null.");
            }
            _context.DeliveryOrders.Add(deliveryOrder);
            await _context.SaveChangesAsync();

            var deliveryOrderResult = _mapper.Map<DeliveryOrderPostDto>(deliveryOrder);
            return deliveryOrderResult;
        }

        // DELETE: api/DeliveryOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryOrder(int id)
        {
            if (_context.DeliveryOrders == null)
            {
                return NotFound();
            }
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);
            if (deliveryOrder == null)
            {
                return NotFound();
            }

            _context.DeliveryOrders.Remove(deliveryOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryOrderExists(int id)
        {
            return (_context.DeliveryOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
