using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEF.DB;
using CrudEF.Model;
using AutoMapper;
using CrudEF.ModelMapper.OrderItem;

namespace CrudEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly ArtisianContext _context;
        private readonly IMapper _mapper;

        public OrderItemsController(ArtisianContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemGetDto>>> GetOrderItems()
        {
          if (_context.OrderItems == null)
          {
              return NotFound();
          }
            var orderItem = await _context.OrderItems.ToListAsync();
            var orderItemResult = _mapper.Map<IEnumerable<OrderItemGetDto>>(orderItem);
            return Ok(orderItemResult);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemGetDto>> GetOrderItem(int id)
        {
          if (_context.OrderItems == null)
          {
              return NotFound();
          }
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            var orderItemResult = _mapper.Map<OrderItemGetDto>(orderItem);
            return orderItemResult;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItemGetDto>> PutOrderItem(int id, OrderItemGetDto orderItemIncome)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemIncome);

            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var orderItemResult = _mapper.Map<OrderItemGetDto>(orderItem);
            return orderItemResult;
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItemGetDto>> PostOrderItem(OrderItemPostDto orderItemIncome)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemIncome);

            if (_context.OrderItems == null)
            {
                return Problem("Entity set 'ArtisianContext.OrderItems'  is null.");
            }
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            var orderItemResult = _mapper.Map<OrderItemGetDto>(orderItem);
            return orderItemResult;
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            if (_context.OrderItems == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return (_context.OrderItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
