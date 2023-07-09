using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.DeliveryProviderDto
{
    public class DeliveryProviderGetDto : BaseDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
