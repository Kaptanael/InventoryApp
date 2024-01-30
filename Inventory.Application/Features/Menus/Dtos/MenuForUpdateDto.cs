namespace Inventory.Application.Features;

public class MenuForUpdateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }    

    public bool Status { get; set; }

    public Guid? ParentMenuId { get; set; }

}
