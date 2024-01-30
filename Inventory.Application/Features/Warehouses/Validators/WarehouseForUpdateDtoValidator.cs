namespace Inventory.Application.Features;

public class WarehouseForUpdateDtoValidator : AbstractValidator<WarehouseForUpdateDto>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseForUpdateDtoValidator(IServiceProvider serviceProvider)
    {
        _warehouseRepository = serviceProvider.GetService<IWarehouseRepository>();

        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(a => a.BranchId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")            
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.StreetAddress)
            .NotEmpty().WithMessage("{PropertyName} is required")            
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");

        RuleFor(a => a.City)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Province)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Country)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Status).
            Must(x => x == false || x == true).WithMessage("{PropertyName} is required");

        RuleFor(x => x)
           .Must(x => !IsExistWarehouse(x.Name, x.Id))
           .WithMessage("Role already exist");
    }

    private bool IsExistWarehouse(string name, Guid id)
    {
        return _warehouseRepository.IsExist(name, id).Result;
    }
}
