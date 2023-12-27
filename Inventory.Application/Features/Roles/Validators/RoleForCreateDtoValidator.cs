namespace Inventory.Application.Features;

public class RoleForCreateDtoValidator : AbstractValidator<RoleForCreateDto>
{
    public IRoleRepository RoleRepository { get; set; }

    public RoleForCreateDtoValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x)
           .Must(x => !IsExistRole(x.Name))
           .WithMessage("Role already exist");
    }

    private bool IsExistRole(string name)
    {
        return RoleRepository.IsExist(name).Result;
    }
}
