using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.DepartmentManufactoryDto
{
    public class DepartmentManufactoryPostDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Manufactory Id is required")]
        public int ManufactoryId { get; set; }

        public string? Description { get; set; }
    }
}
