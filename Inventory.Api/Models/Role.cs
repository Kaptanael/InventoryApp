using System;
using System.Collections.Generic;

namespace Inventory.Api.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
