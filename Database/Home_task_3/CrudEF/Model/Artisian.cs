using System;
using System.Collections.Generic;

namespace CrudEF.Model;

public partial class Artisian
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual DataArtisian? DataArtisian { get; set; }

    public virtual ICollection<ManufactoryHub> ManufactoryHubs { get; set; } = new List<ManufactoryHub>();
}
