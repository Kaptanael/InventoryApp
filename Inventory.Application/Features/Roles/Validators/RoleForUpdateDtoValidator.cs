namespace Inventory.Application.Features;

public class RoleForUpdateDtoValidator : AbstractValidator<RoleForUpdateDto>
{
    private readonly IRoleRepository _roleRepository;

    public RoleForUpdateDtoValidator(IServiceProvider serviceProvider)
    {
        _roleRepository = serviceProvider.GetService<IRoleRepository>();

        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("{PropertyName} is required");           

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")            
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x)
           .Must(x => !IsExistRole(x.Name, x.Id))
           .WithMessage("Role already exist");
    }

    private bool IsExistRole(string name, Guid id)
    {
        return _roleRepository.IsExist(name, id).Result;
    }
}
