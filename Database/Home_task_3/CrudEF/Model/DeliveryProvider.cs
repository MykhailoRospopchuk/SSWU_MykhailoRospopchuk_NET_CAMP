using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class DeliveryProvider
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();
}
