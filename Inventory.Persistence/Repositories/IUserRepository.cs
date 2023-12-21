namespace Inventory.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> GetUser(string userName, string password);

    Task<User> GetUser(Guid id);

    Task<bool> IsActiveUser(Guid id);
}
