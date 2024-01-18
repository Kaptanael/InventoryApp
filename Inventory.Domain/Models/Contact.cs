using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class Contact
{
    public Guid Id { get; set; }

    public byte ContactType { get; set; }

    public byte CustomerSupplierType { get; set; }

    public Guid ContactId { get; set; }

    public Guid? CustomerGroupId { get; set; }

    public string Mobile { get; set; } = null!;

    public string? AlternateContactNumber { get; set; }

    public string? Landline { get; set; }

    public string Email { get; set; } = null!;

    public string? TaxNumber { get; set; }

    public decimal? OpeningBalance { get; set; }

    public string? PayTerm { get; set; }

    public decimal? CreditLimit { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool Status { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
