namespace Inventory.Application.Contracts.Services;

public interface IProductTypeService
{
    Task<List<ProductTypeForListDto>> GetAll();

    Task<ProductTypeForListDto> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<BaseCommandResponse> CreateAsync(ProductTypeForCreateDto request);

    Task<BaseCommandResponse> UpdateAsync(Guid id, ProductTypeForUpdateDto request);

    Task<BaseCommandResponse> DeleteAsync(Guid id);    
    
}