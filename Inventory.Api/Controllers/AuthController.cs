namespace Recruitment.IdentityServer.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("Token")]
    public async Task<IActionResult> GetToken(TokenRequest request)
    {
        var tokenResponse = await _authService.GetToken(request.Username, request.Password);

        if (!tokenResponse.IsError)
        {
            return Ok(JsonConvert.DeserializeObject<TokenResponse>(tokenResponse.Raw));
        }
        else
        {
            return Ok(tokenResponse);
        }
    }

    [AllowAnonymous]
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> GetRefreshTokenByToken(RefreshTokenRequest request)
    {
        var tokenResponse = await _authService.GetRefreshTokenByToken(request.RefreshToken);

        if (!tokenResponse.IsError)
        {
            return Ok(JsonConvert.DeserializeObject<TokenResponse>(tokenResponse.Raw));
        }
        else
        {
            return Ok(tokenResponse);
        }
    }
}
