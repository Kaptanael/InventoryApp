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


    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<UserWithRoleDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _userService.GetUserWithRole(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] UserForCreateDto request)
    {
        return Ok(await _userService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UserForUpdateDto request)
    {
        return Ok(await _userService.UpdateAsync(id, request));
    }
}
