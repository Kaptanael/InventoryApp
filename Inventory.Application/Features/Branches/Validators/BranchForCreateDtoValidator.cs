namespace Inventory.Application.Features;

public class BranchForCreateDtoValidator : AbstractValidator<BranchForCreateDto>
{
    private readonly IBranchRepository _branchRepository;

    public BranchForCreateDtoValidator(IServiceProvider serviceProvider)
    {
        _branchRepository = serviceProvider.GetService<IBranchRepository>();                   

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")            
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Description)
            .NotEmpty().WithMessage("{PropertyName} is required")
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

        RuleFor(x => x)
           .Must(x => !IsExistBranch(x.Name))
           .WithMessage("Role already exist");
    }

    private bool IsExistBranch(string name)
    {
        return _branchRepository.IsExist(name).Result;
    }
}
