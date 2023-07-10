using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ManufactoryHub
{
    public class ManufactoryHubPostDto
    {
        [Required(ErrorMessage = "Artisian Id is required")]
        public int ArtisianId { get; set; }
        [Required(ErrorMessage = "Address Id is required")]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
    }
}
