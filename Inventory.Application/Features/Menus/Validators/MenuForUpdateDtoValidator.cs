namespace Inventory.Application.Features;

public class MenuForUpdateDtoValidator : AbstractValidator<MenuForUpdateDto>
{
    private readonly IMenuRepository _menuRepository;

    public MenuForUpdateDtoValidator(IServiceProvider serviceProvider)
    {
        _menuRepository = serviceProvider.GetService<IMenuRepository>();

        RuleFor(a => a.Id)
           .NotEmpty().WithMessage("{PropertyName} is required");           

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")            
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");       

        RuleFor(x => x)
           .Must(x => !IsExistMenu(x.Name))
           .WithMessage("Menu already exist");
    }

    private bool IsExistMenu(string name)
    {
        return _menuRepository.IsExist(name).Result;
    }
}
