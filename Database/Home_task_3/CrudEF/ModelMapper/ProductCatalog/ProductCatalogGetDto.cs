using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ProductCatalog
{
    public class ProductCatalogGetDto : BaseDto
    {
        [Required(ErrorMessage = "Category Id is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Availability is required")]
        public bool Availability { get; set; }
    }
}
