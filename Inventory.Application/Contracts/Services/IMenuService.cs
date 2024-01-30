namespace Inventory.Application.Contracts.Services
{
    public interface IMenuService
    {
        Task<BaseCommandResponse> CreateAsync(MenuForCreateDto request);
        Task<BaseCommandResponse> DeleteAsync(Guid id);
        Task<List<MenuForListDto>> GetAll();
        Task<MenuForListDto> GetById(Guid id);
        Task<bool> IsExist(string name, Guid? id = null);
        Task<BaseCommandResponse> UpdateAsync(Guid id, MenuForUpdateDto request);
    }
}