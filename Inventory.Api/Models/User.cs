namespace Inventory.Api.Models;

public class User
{
    public int UserId { get; set; }
    public string LoginId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Mobile { get; set; }    
    public bool? IsActive { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int TimeOut { get; set; }    
    
}
