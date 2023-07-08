using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class DepartmentProduct
{
    public int DepartmentId { get; set; }

    public int ProductId { get; set; }

    public bool InProduces { get; set; }

    public int CountProduct { get; set; }

    public virtual DepartmentManufactory Department { get; set; } = null!;

    public virtual ProductCatalog Product { get; set; } = null!;
}
