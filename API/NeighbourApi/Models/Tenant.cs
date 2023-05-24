namespace NeighbourApi.Models;

public partial class Tenant
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public long? IncomeYear { get; set; }

    public long? IncomeMonth { get; set; }

    public long? ApartmentId { get; set; }

    public virtual Apartment? Apartment { get; set; }
}
