using System;
using System.Collections.Generic;

namespace NeighbourApi;

public partial class Building
{
    public long BuildingNumber { get; set; }

    public string BuildingLetter { get; set; } = null!;

    public DateTime? LastTimeServiced { get; set; }

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
}
