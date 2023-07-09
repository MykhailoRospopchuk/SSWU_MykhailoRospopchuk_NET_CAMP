using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ContactArtisianDto
{
    public class ContactArtisianPostDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Data Artisian Id is required")]
        public int DataArtisianId { get; set; }
    }
}
