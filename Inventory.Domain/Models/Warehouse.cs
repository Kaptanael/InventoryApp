using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class Warehouse
{
    public Guid Id { get; set; }

    public Guid BranchId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public bool Status { get; set; }

    public string Country { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
