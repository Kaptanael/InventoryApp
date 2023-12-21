namespace Inventory.Application.Contracts.Services;

public interface IUserService
{
    Task<int> GetUserId(string loginId, string password);

    Task<UserForListDto> GetUserById(int userId);

    Task<bool> IsActiveUser(int userId);
}
