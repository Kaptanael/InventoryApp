namespace Inventory.Application.Features;

public class UserForUpdateDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }       

    public string Role { get; set; }
    public bool isActive { get; set; }
}
