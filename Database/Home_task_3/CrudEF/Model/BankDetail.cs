using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class BankDetail
{
    public int Id { get; set; }

    public int DataArtisianId { get; set; }

    public string AccountCurrencyType { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public virtual DataArtisian DataArtisian { get; set; } = null!;
}
