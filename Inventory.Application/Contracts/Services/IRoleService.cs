namespace Inventory.Application.Features
{
    public interface IRoleService
    {
        Task<List<RoleForListDto>> GetAll();

        Task<RoleForListDto> GetById(Guid id);

        Task<bool> IsExist(string name, Guid? id = null);

        Task<BaseCommandResponse> CreateAsync(RoleForCreateDto request);
        
        Task<BaseCommandResponse> UpdateAsync(Guid id, RoleForUpdateDto request);

        Task<BaseCommandResponse> DeleteAsync(Guid id);
    }
}