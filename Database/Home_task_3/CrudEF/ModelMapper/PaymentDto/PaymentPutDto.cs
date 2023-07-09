using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.PaymentDto
{
    public class PaymentPutDto : BaseDto
    {
        [Required(ErrorMessage = "Amount is required")]
        public int PaymentMethodId { get; set; }
        [Required(ErrorMessage = "Is Successful is required")]
        public bool IsSuccessful { get; set; }
        [Required(ErrorMessage = "Receip Id is required")]
        public int ReceipId { get; set; }
    }
}
