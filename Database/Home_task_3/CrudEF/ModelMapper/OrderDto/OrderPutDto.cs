using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.OrderDto
{
    public class OrderPutDto : BaseDto
    {
        [Required(ErrorMessage = "Customer Id is required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Order Date is required")]
        public string OrderDate { get; set; } = null!;
        [Required(ErrorMessage = "Delivery Id is required")]
        public int DeliveryId { get; set; }
    }
}
