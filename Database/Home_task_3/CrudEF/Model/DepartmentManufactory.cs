using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class DepartmentManufactory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ManufactoryId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<DepartmentProduct> DepartmentProducts { get; set; } = new List<DepartmentProduct>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ManufactoryHub Manufactory { get; set; } = null!;
}
