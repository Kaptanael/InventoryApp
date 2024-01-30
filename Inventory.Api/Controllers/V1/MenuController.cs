namespace Inventory.Api.Controllers.V1;

[Route("api/v1/Menu")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService roleService)
    {
        _menuService = roleService;
    }
    
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<MenuForListDto>>> GetAllAsync()
    {
        return Ok(await _menuService.GetAll());
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<MenuForListDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _menuService.GetById(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] MenuForCreateDto request)
    {
        return Ok(await _menuService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] MenuForUpdateDto request)
    {
        return Ok(await _menuService.UpdateAsync(id, request));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _menuService.DeleteAsync(id));
    }
}
