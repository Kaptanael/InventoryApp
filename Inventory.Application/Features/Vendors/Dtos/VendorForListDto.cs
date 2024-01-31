namespace Inventory.Application.Features;

public class VendorForListDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string BusinessSize { get; set; } = null!;

    public string? Description { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool? Status { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
}
