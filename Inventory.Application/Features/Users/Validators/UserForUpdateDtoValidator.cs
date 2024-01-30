namespace Inventory.Application.Features;

public class UserForUpdateDtoValidator: AbstractValidator<UserForUpdateDto>
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
           .Must(x => !IsExistEmail(x.Email))
           .WithMessage("Email already exist");
    }

    private bool IsExistEmail(string email)
    {
        return _userRepository.IsExistEmail(email).Result;
    }
}
