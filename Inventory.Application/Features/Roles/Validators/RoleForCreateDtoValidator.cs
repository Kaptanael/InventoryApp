using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Application.Features;

public class RoleForCreateDtoValidator : AbstractValidator<RoleForCreateDto>
{
    private readonly IRoleRepository _roleRepository;

    public RoleForCreateDtoValidator(IServiceProvider serviceProvider)
    {
        _roleRepository = serviceProvider.GetService<IRoleRepository>();

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
        //var serviceProvider = new ServiceCollection().BuildServiceProvider().GetRequiredService<IServiceProvider>();
        //var roleRepository = serviceProvider.GetService<IRoleRepository>();

        return _roleRepository.IsExist(name).Result;
    }
}
