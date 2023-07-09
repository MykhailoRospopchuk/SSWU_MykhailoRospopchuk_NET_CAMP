using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper
{
    public class BaseDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
