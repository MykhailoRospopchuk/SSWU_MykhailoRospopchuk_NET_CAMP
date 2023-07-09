using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.DataArtisianDto
{
    public class DataArtisianPostDto : BaseDto
    {
        public string? Description { get; set; }
        [Required(ErrorMessage = "Address Id is required")]
        public int AddressId { get; set; }

        public string? Name { get; set; }
    }
}
