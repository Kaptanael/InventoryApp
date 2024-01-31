using System;
using System.Collections.Generic;

namespace Inventory.Domain.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<Branch> BranchCreatedByNavigations { get; set; } = new List<Branch>();

    public virtual ICollection<Branch> BranchUpdatedByNavigations { get; set; } = new List<Branch>();

    public virtual ICollection<Contact> ContactCreatedByNavigations { get; set; } = new List<Contact>();

    public virtual Contact? ContactIdNavigation { get; set; }

    public virtual ICollection<ProductSubType> ProductSubTypeCreatedByNavigations { get; set; } = new List<ProductSubType>();

    public virtual ICollection<ProductSubType> ProductSubTypeUpdatedByNavigations { get; set; } = new List<ProductSubType>();

    public virtual ICollection<ProductType> ProductTypeCreatedByNavigations { get; set; } = new List<ProductType>();

    public virtual ICollection<ProductType> ProductTypeUpdatedByNavigations { get; set; } = new List<ProductType>();

    public virtual ICollection<Unit> UnitCreatedByNavigations { get; set; } = new List<Unit>();

    public virtual ICollection<Unit> UnitUpdatedByNavigations { get; set; } = new List<Unit>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<Variation> VariationCreatedByNavigations { get; set; } = new List<Variation>();

    public virtual ICollection<Variation> VariationUpdatedByNavigations { get; set; } = new List<Variation>();

    public virtual ICollection<Vendor> VendorCreatedByNavigations { get; set; } = new List<Vendor>();

    public virtual ICollection<Vendor> VendorUpdatedByNavigations { get; set; } = new List<Vendor>();

    public virtual ICollection<Warehouse> WarehouseCreatedByNavigations { get; set; } = new List<Warehouse>();

    public virtual ICollection<Warehouse> WarehouseUpdatedByNavigations { get; set; } = new List<Warehouse>();
}
