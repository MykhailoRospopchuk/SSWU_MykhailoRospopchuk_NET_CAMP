using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.Rewiew
{
    public class RewiewGetDto : BaseDto
    {
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Customer Id is required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; } = null!;
    }
}
