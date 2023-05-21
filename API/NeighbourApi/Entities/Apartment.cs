using System;
using System.Collections.Generic;

namespace NeighbourApi;

public partial class Apartment
{
    public long Id { get; set; }

    public int? ApartmentNumber { get; set; }

    public int? LivingSize { get; set; }

    public int? NumberOfRooms { get; set; }

    public int? NumberofTenants { get; set; }

    public long? MonthlyRent { get; set; }

    public long BuildingNumber { get; set; }

    public string BuildingLetter { get; set; } = null!;

    public virtual Building Building { get; set; } = null!;

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
