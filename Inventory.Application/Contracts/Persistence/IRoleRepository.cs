namespace Inventory.Application.Repositories;

public interface IRoleRepository
{    
    Task<Role> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<List<Role>> GetAll();

    Task<Guid> Create(Role model);    

    Task<bool> Update(Role model);

    Task<bool> Delete(Role model);

}
