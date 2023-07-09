using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ReceiptDto
{
    public class ReceiptPostDto : BaseDto
    {
        [Required(ErrorMessage = "Total Amount is required")]
        public decimal TotalAmount { get; set; }
        [Required(ErrorMessage = "Customer Discount Id is required")]
        public int CustomerDiscountId { get; set; }
        [Required(ErrorMessage = "Amount To Pay is required")]
        public decimal AmountToPay { get; set; }
    }
}
