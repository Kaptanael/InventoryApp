using System;
using System.Collections.Generic;

namespace Inventory.Persistence.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}
