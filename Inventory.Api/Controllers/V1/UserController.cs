namespace Inventory.Api.Controllers.V1;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<UserForListDto>>> GetAllAsync()
    {
        return Ok(await _userService.GetAllUser());
    }
}
