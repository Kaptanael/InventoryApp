namespace Inventory.Application.Features;

public class ProductTypeForUpdateDtoValidator : AbstractValidator<ProductTypeForUpdateDto>
{
    private readonly IRoleRepository _productTypeRepository;

    public ProductTypeForUpdateDtoValidator(IServiceProvider serviceProvider)
    {
        _productTypeRepository = serviceProvider.GetService<IRoleRepository>();

        RuleFor(a => a.Id)
           .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Description)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Status).
            Must(x => x == false || x == true).WithMessage("{PropertyName} is required");

        RuleFor(x => x)
           .Must(x => !IsExistProductType(x.Name, x.Id))
           .WithMessage("Product type already exist");
    }

    private bool IsExistProductType(string name, Guid id)
    {
        return _productTypeRepository.IsExist(name, id).Result;
    }
}
