namespace Inventory.Application.Contracts.Services
{
    public interface IVendorService
    {
        Task<List<VendorForListDto>> GetAll();

        Task<VendorForListDto> GetById(Guid id);

        Task<bool> IsExist(string name, Guid? id = null);

        Task<BaseCommandResponse> CreateAsync(VendorForCreateDto request);        

        Task<BaseCommandResponse> UpdateAsync(Guid id, VendorForUpdateDto request);

        Task<BaseCommandResponse> DeleteAsync(Guid id);
    }
}