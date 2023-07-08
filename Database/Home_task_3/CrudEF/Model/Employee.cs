using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int DepartmentId { get; set; }

    public virtual DepartmentManufactory Department { get; set; } = null!;
}
