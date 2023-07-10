
namespace CrudEF.Model;

public partial class ProductCatalog
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Availability { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<DepartmentProduct> DepartmentProducts { get; set; } = new List<DepartmentProduct>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();

    public virtual ICollection<Rewiew> Rewiews { get; set; } = new List<Rewiew>();
}
