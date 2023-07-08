using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class ManufactoryHub
{
    public int Id { get; set; }

    public int ArtisianId { get; set; }

    public int AddressId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;

    public virtual Artisian Artisian { get; set; } = null!;

    public virtual ICollection<DepartmentManufactory> DepartmentManufactories { get; set; } = new List<DepartmentManufactory>();
}
