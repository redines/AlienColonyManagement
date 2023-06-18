using System;
using System.Collections.Generic;

namespace NeighbourApi;

public partial class Colony
{
    public long Id { get; set; }

    public string ColonyName { get; set; } = null!;

    public long MaxPopulation { get; set; }

    public long? WaterConsumption { get; set; }

    public long? EnergyConsumption { get; set; }

    public long? FoodConsumption { get; set; }

    public long? Income { get; set; }

    public long? Outcome { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Population> Populations { get; set; } = new List<Population>();
}
