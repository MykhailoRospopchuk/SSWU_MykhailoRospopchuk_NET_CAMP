using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string OrderDate { get; set; } = null!;

    public int DeliveryId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual DeliveryOrder Delivery { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Receipt? Receipt { get; set; }
}
