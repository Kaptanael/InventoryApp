﻿using TokenResponse = IdentityModel.Client.TokenResponse;

namespace Inventory.Api.Services;

public interface IAuthenticationService
{
    Task<TokenResponse> GetRefreshTokenByToken(string refreshToken);
    Task<TokenResponse> GetToken(string username, string password);
}