using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class ProductPrice
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ProductCatalog Product { get; set; } = null!;
}
