using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.EmployeeDto
{
    public class EmployeeGetDto : BaseDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Email { get; set; }
        [Required(ErrorMessage = "Department Id is required")]
        public int DepartmentId { get; set; }
    }
}
