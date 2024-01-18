namespace Inventory.Application.Features;

public class BranchForCreateDto
{   

    public string Name { get; set; }

    public string Description { get; set; }

    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public string Country { get; set; }

    public bool? Status { get; set; }

}
