namespace Inventory.Application.Contracts.Persistence
{
    public interface IVendorRepository
    {        
        Task<List<Vendor>> GetAll();

        Task<Vendor> GetById(Guid id);

        Task<bool> IsExist(string name, Guid? id = null);

        Task<Guid> Create(Vendor model);        

        Task<bool> Update(Vendor model);

        Task<bool> Delete(Vendor model);
    }
}