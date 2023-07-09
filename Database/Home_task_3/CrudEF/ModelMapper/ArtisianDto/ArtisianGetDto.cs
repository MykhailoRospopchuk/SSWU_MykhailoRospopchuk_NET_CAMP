using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ArtisianDto
{
    public class ArtisianGetDto : BaseDto
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
    }
}
