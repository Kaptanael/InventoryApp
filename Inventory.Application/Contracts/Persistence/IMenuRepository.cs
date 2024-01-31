namespace Inventory.Application.Contracts.Persistence;

public interface IMenuRepository
{   
    Task<List<Menu>> GetAll();

    Task<Menu> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<Guid> Create(Menu model);

    Task<bool> Update(Menu model);

    Task<bool> Delete(Menu model);
}