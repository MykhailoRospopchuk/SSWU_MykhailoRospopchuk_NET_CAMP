using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class ContactArtisian
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int DataArtisianId { get; set; }

    public virtual DataArtisian DataArtisian { get; set; } = null!;
}
