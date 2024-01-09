namespace Inventory.Application.Contracts.Services
{
    public interface IWarehouseService
    {        
        Task<List<WarehouseForListDto>> GetAll();

        Task<WarehouseForListDto> GetById(Guid id);

        Task<bool> IsExist(string name, Guid? id = null);

        Task<BaseCommandResponse> CreateAsync(WarehouseForCreateDto request);        

        Task<BaseCommandResponse> UpdateAsync(Guid id, WarehouseForUpdateDto request);

        Task<BaseCommandResponse> DeleteAsync(Guid id);
    }
}