namespace Inventory.Persistence.Repositories;

public interface IUserRepository
{
    Task<Guid> Insert(User user);    

    Task<Guid> Update(User user);    

    Task<Guid> Delete(User user);
    
    Task<User> GetUser(string userName, string password);

    Task<User> GetUser(Guid id);

    Task<bool> IsExistUsername(string username);

    Task<bool> IsExistEmail(string email);

    Task<bool> IsActiveUser(Guid id);
    
}
