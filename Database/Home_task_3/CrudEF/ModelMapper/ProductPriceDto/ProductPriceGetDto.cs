using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.ProductPriceDto
{
    public class ProductPriceGetDto : BaseDto
    {
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Begin Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime BeginDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
