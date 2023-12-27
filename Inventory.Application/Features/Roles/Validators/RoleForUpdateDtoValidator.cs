namespace Inventory.Application.Features;

public class RoleForUpdateDtoValidator : AbstractValidator<RoleForUpdateDto>
{
    public IRoleRepository RoleRepository { get; set; }

    public RoleForUpdateDtoValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x)
           .Must(x => !IsExistRole(x.Name, x.Id))
           .WithMessage("Role already exist");
    }

    private bool IsExistRole(string name, Guid id)
    {
        return RoleRepository.IsExist(name, id).Result;
    }
}
