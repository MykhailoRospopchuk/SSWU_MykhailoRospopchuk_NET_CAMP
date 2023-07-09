using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ArtisianDto
{
    public class ArtisianPostDto
    {
        [Required(ErrorMessage = "City is required")]
        public string Description { get; set; } = null!;
    }
}
