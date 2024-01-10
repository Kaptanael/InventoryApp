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

        RuleFor(x => x)
           .Must(x => !IsExistProductType(x.Name))
           .WithMessage("Product type already exist");
    }

    private bool IsExistProductType(string name)
    {
        return _productTypeRepository.IsExist(name).Result;
    }
}
