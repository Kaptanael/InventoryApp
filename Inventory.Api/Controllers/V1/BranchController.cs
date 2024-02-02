namespace Inventory.Api.Controllers.V1;

[Route("api/v1/branch")]
[ApiController]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<BranchForListDto>>> GetAllAsync(string? search)
    {
        return Ok(await _branchService.GetAll(search));
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<BranchForListDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _branchService.GetById(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] BranchForCreateDto request)
    {
        return Ok(await _branchService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] BranchForUpdateDto request)
    {
        return Ok(await _branchService.UpdateAsync(id, request));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _branchService.DeleteAsync(id));
    }
}
