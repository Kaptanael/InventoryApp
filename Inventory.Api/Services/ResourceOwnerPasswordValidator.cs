namespace Inventory.Api.Services;

public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly ILogger<ResourceOwnerPasswordValidator> _logger;
    private readonly IUserService _userService;

    public ResourceOwnerPasswordValidator(ILogger<ResourceOwnerPasswordValidator> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        try
        {
            //int userId = await _userService.GetUserId(context.UserName, context.Password);

            if (context.UserName == "kaptan" && context.Password== "12345678")
            {
                //context.Result = new GrantValidationResult(userId.ToString(), OidcConstants.AuthenticationMethods.Password);
                context.Result = new GrantValidationResult("kaptan", OidcConstants.AuthenticationMethods.Password);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

}
