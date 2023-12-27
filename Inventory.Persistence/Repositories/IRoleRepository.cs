namespace Inventory.Persistence.Repositories;

public interface IRoleRepository
{    
    Task<Role> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<List<Role>> GetAll();

    Task<Guid> Create(Role role);    

    Task<bool> Update(Role role);

    Task<bool> Delete(Role role);

}
