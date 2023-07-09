using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.CustomerDiscountDto
{
    public class CustomerDiscountPostDto
    {
        [Required(ErrorMessage = "Discount is required")]
        public decimal Discount { get; set; }
    }
}
