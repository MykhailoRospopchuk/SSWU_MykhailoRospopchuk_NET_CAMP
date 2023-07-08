using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Method { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
