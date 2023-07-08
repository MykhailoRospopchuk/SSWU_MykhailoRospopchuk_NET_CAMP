using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Rewiew
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public string Comment { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ProductCatalog Product { get; set; } = null!;
}
