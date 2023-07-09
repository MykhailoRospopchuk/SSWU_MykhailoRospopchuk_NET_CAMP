
namespace CrudEF.Model;

public partial class CustomerDiscount
{
    public int Id { get; set; }

    public decimal Discount { get; set; }

    public virtual Customer IdNavigation { get; set; } = null!;

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
