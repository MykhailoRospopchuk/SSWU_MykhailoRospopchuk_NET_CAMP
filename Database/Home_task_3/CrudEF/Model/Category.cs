using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; } = new List<ProductCatalog>();
}
