namespace Inventory.Application.Contracts.Services
{
    public interface IBranchService
    {        
        Task<List<BranchForListDto>> GetAll(string? search);

        Task<BranchForListDto> GetById(Guid id);

        Task<bool> IsExist(string name, Guid? id = null);

        Task<BaseCommandResponse> CreateAsync(BranchForCreateDto request);

        Task<BaseCommandResponse> UpdateAsync(Guid id, BranchForUpdateDto request);

        Task<BaseCommandResponse> DeleteAsync(Guid id);        
    }
}