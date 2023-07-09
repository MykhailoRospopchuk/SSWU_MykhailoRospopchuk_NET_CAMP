using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.CustomerDto
{
    public class CustomerGetDto : BaseDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Address Id is required")]
        public int AddressId { get; set; }
    }
}
