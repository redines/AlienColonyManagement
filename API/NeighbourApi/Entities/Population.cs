using System;
using System.Collections.Generic;

namespace NeighbourApi;

public partial class Population
{
    public long Id { get; set; }

    public long? ColonyId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string? Occupation { get; set; }

    public int? Income { get; set; }

    public virtual Colony? Colony { get; set; }
}
