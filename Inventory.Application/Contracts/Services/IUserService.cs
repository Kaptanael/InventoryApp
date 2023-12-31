﻿namespace Inventory.Application.Contracts.Services;

public interface IUserService
{
    Task<BaseCommandResponse> CreateAsync(UserForCreateDto request);

    Task<UserForListDto> GetUser(string userName, string password);

    Task<UserForListDto> GetUser(Guid id);

    Task<bool> IsActiveUser(Guid id);
}
