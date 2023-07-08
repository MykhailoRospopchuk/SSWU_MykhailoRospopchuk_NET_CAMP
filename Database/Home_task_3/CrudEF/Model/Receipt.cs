using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Receipt
{
    public int Id { get; set; }

    public decimal TotalAmount { get; set; }

    public int CustomerDiscountId { get; set; }

    public decimal AmountToPay { get; set; }

    public virtual CustomerDiscount CustomerDiscount { get; set; } = null!;

    public virtual Order IdNavigation { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
