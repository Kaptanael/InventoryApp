using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class Unit
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public bool AllowDecimal { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; }

    public virtual User UpdatedByNavigation { get; set; }
}
