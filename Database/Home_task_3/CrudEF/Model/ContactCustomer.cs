using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class ContactCustomer
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
