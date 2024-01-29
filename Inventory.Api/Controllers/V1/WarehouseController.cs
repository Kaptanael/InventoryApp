namespace Inventory.Api.Controllers.V1;

[Route("api/v1/warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<WarehouseForListDto>>> GetAllAsync()
    {
        return Ok(await _warehouseService.GetAll());
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<WarehouseForListDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _warehouseService.GetById(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] WarehouseForCreateDto request)
    {
        return Ok(await _warehouseService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] WarehouseForUpdateDto request)
    {
        return Ok(await _warehouseService.UpdateAsync(id, request));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _warehouseService.DeleteAsync(id));
    }
}
