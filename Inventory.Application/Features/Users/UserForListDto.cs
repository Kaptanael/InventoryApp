﻿namespace Inventory.Application.Features;

public class UserForListDto
{
    public int UserId { get; set; }
    public string LoginId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Password { get; set; } 
    public string Email { get; set; } 
    public string Mobile { get; set; }
    public bool? IsActive { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int TimeOut { get; set; }
}
