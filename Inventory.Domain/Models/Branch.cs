using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class Branch
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public string Country { get; set; }

    public bool? Status { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; }

    public virtual User UpdatedByNavigation { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
