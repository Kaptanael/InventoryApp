﻿namespace Inventory.Application.Features;

public class MenuForListDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }    

    public bool Status { get; set; }

    public Guid? ParentMenuId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
    
}
