using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.DepartmentProductDto
{
    public class DepartmentProductPostDto
    {
        [Required(ErrorMessage = "Department Id is required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "In Produces is required")]
        public bool InProduces { get; set; }
        [Required(ErrorMessage = "Count Product is required")]
        public int CountProduct { get; set; }
    }
}
