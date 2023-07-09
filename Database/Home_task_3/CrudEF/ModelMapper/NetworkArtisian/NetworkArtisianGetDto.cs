using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.NetworkArtisian
{
    public class NetworkArtisianGetDto : BaseDto
    {
        [Required(ErrorMessage = "Social Network required")]
        public string? SocialNetwork { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Descriptioon { get; set; }
        [Required(ErrorMessage = "Data Artisian Id is required")]
        public int DataArtisianId { get; set; }
    }
}
