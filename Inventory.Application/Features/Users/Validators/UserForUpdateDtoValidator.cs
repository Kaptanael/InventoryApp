namespace Inventory.Application.Features;

public class UserForUpdateDtoValidator : AbstractValidator<UserForUpdateDto>
{
    private readonly IUserRepository _userRepository;

    public UserForUpdateDtoValidator(IServiceProvider serviceProvider)
    {
        _userRepository = serviceProvider.GetService<IUserRepository>();

        RuleFor(a => a.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(a => a.Mobile)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters");

        RuleFor(x => x)
           .Must(x => !IsExistEmailExceptMe(x.Email, x.Id))
           .WithMessage("Email already exist");
    }

    private bool IsExistEmailExceptMe(string email, string id)
    {
        return _userRepository.IsExistEmailExceptMe(email,new Guid(id)).Result;
    }
}
