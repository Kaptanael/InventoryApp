namespace Inventory.Persistence.Repositories;

public interface IRoleRepository
{
    Task<Guid> Add(Role role);

    Task<bool> Delete(Role role);

    Task<Role> Get(Guid id);

    Task<List<Role>> GetAll();

    Task<bool> Update(Role role);

}
