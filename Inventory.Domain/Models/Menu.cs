using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class Menu
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? ParentMenuId { get; set; }

    public virtual ICollection<Menu> InverseParentMenu { get; set; } = new List<Menu>();

    public virtual Menu? ParentMenu { get; set; }
}
