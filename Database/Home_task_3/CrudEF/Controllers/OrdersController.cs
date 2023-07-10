using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.OrderDto;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public OrdersController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGetDto>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            //var order = await _context.Orders.ToListAsync();
            var order = await _context.Orders.Include(c => c.Customer).ThenInclude(a => a.Address).ToListAsync();
            var orderResult = _mapper.Map< IEnumerable<OrderGetDto>>(order);
            return Ok(orderResult);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetDto>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderResult = _mapper.Map<OrderGetDto>(order);
            return orderResult;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderGetDto>> PutOrder(int id, OrderPutDto orderIncome)
        {
            var order = _mapper.Map<Order>(orderIncome);

            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var orderResult = _mapper.Map<OrderGetDto>(order);
            return orderResult;
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderGetDto>> PostOrder(OrderPostDto orderIncome)
        {

            var order = _mapper.Map<Order>(orderIncome);
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ArtisianContext.Orders'  is null.");
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderResult = _mapper.Map<OrderGetDto>(order);
            return orderResult;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
