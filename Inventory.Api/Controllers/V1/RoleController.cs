namespace Inventory.Api.Controllers.V1;

[Route("api/v1/role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<RoleForListDto>>> GetAllAsync()
    {
        return Ok(await _roleService.GetAll());
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<RoleForListDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _roleService.GetById(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] RoleForCreateDto request)
    {
        return Ok(await _roleService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] RoleForUpdateDto request)
    {
        return Ok(await _roleService.UpdateAsync(id, request));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _roleService.DeleteAsync(id));
    }
}
