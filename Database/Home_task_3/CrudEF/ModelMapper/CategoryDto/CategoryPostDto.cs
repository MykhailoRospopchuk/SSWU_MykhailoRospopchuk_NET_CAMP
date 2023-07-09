using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.CategoryDto
{
    public class CategoryPostDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
    }
}
