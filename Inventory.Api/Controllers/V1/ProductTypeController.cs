namespace Inventory.Api.Controllers.V1;

[Route("api/v1/ProductType")]
[ApiController]
public class ProductTypeController : ControllerBase
{
    private readonly IProductTypeService _productTypeService;

    public ProductTypeController(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }
    
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<ProductTypeForListDto>>> GetAllAsync()
    {
        return Ok(await _productTypeService.GetAll());
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<ProductTypeForListDto>> GetByIdAsync(Guid id)
    {
        return Ok(await _productTypeService.GetById(id));
    }

    [HttpPost("Create")]
    public async Task<ActionResult> CrteateAsync([FromBody] ProductTypeForCreateDto request)
    {
        return Ok(await _productTypeService.CreateAsync(request));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] ProductTypeForUpdateDto request)
    {
        return Ok(await _productTypeService.UpdateAsync(id, request));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _productTypeService.DeleteAsync(id));
    }
}
