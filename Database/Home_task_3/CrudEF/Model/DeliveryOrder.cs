using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class DeliveryOrder
{
    public int Id { get; set; }

    public int ShippingAddressId { get; set; }

    public int DeliveryAddressId { get; set; }

    public string? Comment { get; set; }

    public int DeliveryProviderId { get; set; }

    public virtual Address DeliveryAddress { get; set; } = null!;

    public virtual DeliveryProvider DeliveryProvider { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Address ShippingAddress { get; set; } = null!;
}
