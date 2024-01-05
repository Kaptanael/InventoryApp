namespace Inventory.Application.Repositories;

public interface IWarehouseRepository
{    
    Task<List<Warehouse>> GetAll();

    Task<Warehouse> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<Guid> Create(Warehouse model);
    
    Task<bool> Update(Warehouse model);

    Task<bool> Delete(Warehouse model);
}