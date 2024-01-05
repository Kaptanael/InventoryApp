namespace Inventory.Application.Features;

public class WarehouseForUpdateDto
{
    public Guid Id { get; set; }

    public Guid BranchId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public string Country { get; set; }
    
}
