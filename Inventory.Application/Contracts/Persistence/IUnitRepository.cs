namespace Inventory.Application.Repositories;

public interface IUnitRepository
{
    Task<Guid> Create(Unit model);
    Task<bool> Delete(Unit model);
    Task<List<Unit>> GetAll();
    Task<Unit> GetById(Guid id);
    Task<bool> IsExist(string name, Guid? id = null);
    Task<bool> Update(Unit model);
}