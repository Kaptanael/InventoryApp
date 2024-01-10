using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Barcode { get; set; }

    public string SerialNumber { get; set; }

    public Guid ProductTypeId { get; set; }

    public Guid MeasureUnitId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
}
