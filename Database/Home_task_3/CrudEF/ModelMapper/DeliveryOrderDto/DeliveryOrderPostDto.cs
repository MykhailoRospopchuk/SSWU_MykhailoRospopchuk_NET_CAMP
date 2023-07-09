using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.DeliveryOrderDto
{
    public class DeliveryOrderPostDto
    {
        [Required(ErrorMessage = "Shipping Address Id is required")]
        public int ShippingAddressId { get; set; }
        [Required(ErrorMessage = "Delivery Address Id is required")]
        public int DeliveryAddressId { get; set; }

        public string? Comment { get; set; }
        [Required(ErrorMessage = "Delivery Provider Id is required")]
        public int DeliveryProviderId { get; set; }
    }
}
