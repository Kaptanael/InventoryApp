namespace Inventory.Application.Features;

public class MenuForCreateDto
{
    public string Name { get; set; }    

    public bool Status { get; set; }

    public Guid? ParentMenuId { get; set; }

}
