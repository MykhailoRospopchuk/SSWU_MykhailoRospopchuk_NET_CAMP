using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.AddressDto
{
    public class AddressGetDto : BaseDto
    {
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } = null!;
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = null!;
        [Required(ErrorMessage = "PostalCode is required")]
        public string PostalCode { get; set; } = null!;
    }
}
