using Inventory.Api.Models;

namespace Inventory.Api.Services;

public interface IUserService
{
    Task<int> GetUserId(string loginId, string password);

    Task<User> GetUserById(int userId);

    Task<bool> IsActiveUser(int userId);
}
