using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class ProductType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Status { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ProductSubType? ProductSubType { get; set; }

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
