namespace Inventory.Api.Controllers.V1;

[Route("api/v1/vendor")]
[ApiController]
public class VendorController : ControllerBase
{
    private readonly IVendorService _vendorService;

    public VendorController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<VendorForListDto>>> GetAllAsync()
    {
        return Ok(await _vendorService.GetAll());
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<VendorForListDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _vendorService.GetById(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] VendorForCreateDto request)
    {
        return Ok(await _vendorService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] VendorForUpdateDto request)
    {
        return Ok(await _vendorService.UpdateAsync(id, request));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _vendorService.DeleteAsync(id));
    }
}
