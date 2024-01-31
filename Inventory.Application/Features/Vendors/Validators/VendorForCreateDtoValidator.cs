namespace Inventory.Application.Features;

public class VendorForCreateDtoValidator : AbstractValidator<VendorForCreateDto>
{
    private readonly IVendorRepository _vendorRepository;

    public VendorForCreateDtoValidator(IServiceProvider serviceProvider)
    {
        _vendorRepository = serviceProvider.GetService<IVendorRepository>();                   

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")            
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.BusinessSize)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Description)            
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");        

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
           .Must(x => !IsExistVendor(x.Name))
           .WithMessage("Vendor already exist");
    }

    private bool IsExistVendor(string name)
    {
        return _vendorRepository.IsExist(name).Result;
    }
}
