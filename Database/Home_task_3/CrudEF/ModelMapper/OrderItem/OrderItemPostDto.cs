using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.OrderItem
{
    public class OrderItemPostDto
    {
        [Required(ErrorMessage = "Order Id is required")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public short Quantity { get; set; }
    }
}
