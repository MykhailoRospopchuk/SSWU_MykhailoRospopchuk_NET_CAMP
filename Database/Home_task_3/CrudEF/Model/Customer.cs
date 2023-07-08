using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<ContactCustomer> ContactCustomers { get; set; } = new List<ContactCustomer>();

    public virtual CustomerDiscount? CustomerDiscount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Rewiew> Rewiews { get; set; } = new List<Rewiew>();
}
