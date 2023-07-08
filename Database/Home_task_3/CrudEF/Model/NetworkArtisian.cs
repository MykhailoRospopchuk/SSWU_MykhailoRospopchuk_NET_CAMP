using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class NetworkArtisian
{
    public int Id { get; set; }

    public string? SocialNetwork { get; set; }

    public string? Descriptioon { get; set; }

    public int DataArtisianId { get; set; }

    public virtual DataArtisian DataArtisian { get; set; } = null!;
}
