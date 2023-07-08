using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class DataArtisian
{
    public int ArtisianId { get; set; }

    public string? Description { get; set; }

    public int AddressId { get; set; }

    public string? Name { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Artisian Artisian { get; set; } = null!;

    public virtual ICollection<BankDetail> BankDetails { get; set; } = new List<BankDetail>();

    public virtual ICollection<ContactArtisian> ContactArtisians { get; set; } = new List<ContactArtisian>();

    public virtual ICollection<NetworkArtisian> NetworkArtisians { get; set; } = new List<NetworkArtisian>();
}
