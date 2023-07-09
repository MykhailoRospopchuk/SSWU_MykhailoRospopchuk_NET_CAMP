using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ContactCustomerDto
{
    public class ContactCustomerGetDto : BaseDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Customer Id is required")]
        public int CustomerId { get; set; }
    }
}
