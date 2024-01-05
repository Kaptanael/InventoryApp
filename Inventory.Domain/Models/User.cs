using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }

    public bool IsActive { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<Warehouse> WarehouseCreatedByNavigations { get; set; } = new List<Warehouse>();

    public virtual ICollection<Warehouse> WarehouseUpdatedByNavigations { get; set; } = new List<Warehouse>();
}
