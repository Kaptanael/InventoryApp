namespace Inventory.Application.Features;

public class WarehouseForCreateDtoValidator : AbstractValidator<WarehouseForCreateDto>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseForCreateDtoValidator(IServiceProvider serviceProvider)
    {
        _warehouseRepository = serviceProvider.GetService<IWarehouseRepository>();

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

        RuleFor(x => x)
           .Must(x => !IsExistWarehouse(x.Name))
           .WithMessage("Role already exist");
    }

    private bool IsExistWarehouse(string name)
    {
        return _warehouseRepository.IsExist(name).Result;
    }
}
