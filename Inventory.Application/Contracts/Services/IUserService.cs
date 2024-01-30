namespace Inventory.Application.Contracts.Services;

public interface IUserService
{
    Task<BaseCommandResponse> CreateAsync(UserForCreateDto request);
    Task<BaseCommandResponse> UpdateAsync(Guid guid, UserForUpdateDto request);

    Task<UserForListDto> GetUser(string userName, string password);

    Task<UserForListDto> GetUser(Guid id);

    Task<bool> IsActiveUser(Guid id);

    Task<List<UserForListDto>> GetAllUser();
    Task<Guid> CreateUserRoleAsync(UserRole userRole);
    Task<Guid> DeleteUserRoleAsync(UserRole userRole);
}
