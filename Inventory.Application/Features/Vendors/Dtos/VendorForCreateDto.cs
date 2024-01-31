namespace Inventory.Application.Features;

public class VendorForCreateDto
{
    public string Name { get; set; } = null!;

    public string BusinessSize { get; set; } = null!;

    public string? Description { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool? Status { get; set; }    

}
