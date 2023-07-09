using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.BankDetail
{
    public class BankDetailPostDto
    {
        [Required(ErrorMessage = "Data Artisian Id is required")]
        public int DataArtisianId { get; set; }
        [Required(ErrorMessage = "Account Currency Type is required")]
        public string AccountCurrencyType { get; set; } = null!;
        [Required(ErrorMessage = "AccountNumber is required")]
        public string AccountNumber { get; set; } = null!;
    }
}
