using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ProductPriceDto
{
    public class ProductPricePutDto : BaseDto
    {
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
