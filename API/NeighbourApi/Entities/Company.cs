using System;
using System.Collections.Generic;

namespace NeighbourApi;

public partial class Company
{
    public int Id { get; set; }

    public long ColonyId { get; set; }

    public string Name { get; set; } = null!;

    public uint? NumbEmployees { get; set; }

    public ulong? Income { get; set; }

    public ulong? Outcome { get; set; }

    public uint? TypeofCompany { get; set; }

    public virtual Colony Colony { get; set; } = null!;

    public virtual TypeofCompany? TypeofCompanyNavigation { get; set; }
}
