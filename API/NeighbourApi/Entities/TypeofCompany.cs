using System;
using System.Collections.Generic;

namespace NeighbourApi;

public partial class TypeofCompany
{
    public uint Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
