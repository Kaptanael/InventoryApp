using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class RoleMenu
{
    public Guid RoleId { get; set; }

    public Guid MenuId { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
