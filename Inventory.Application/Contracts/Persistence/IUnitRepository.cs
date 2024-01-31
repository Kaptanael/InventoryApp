namespace Inventory.Application.Contracts.Persistence;

public interface IUnitRepository
{    
    Task<List<Unit>> GetAll();

    Task<Unit> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<Guid> Create(Unit model);

    Task<bool> Delete(Unit model);

    Task<bool> Update(Unit model);
}