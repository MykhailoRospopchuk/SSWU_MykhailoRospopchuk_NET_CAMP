using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.DeliveryProviderDto
{
    public class DeliveryProviderPostDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
