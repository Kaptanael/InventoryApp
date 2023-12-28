namespace Inventory.Infrastructure.Configurations;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    public static WebApplicationBuilder AddIdentityServerServicesFromAppSettings(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityServer()
        .AddSigningCredential(new X509Certificate2(Path.Combine("idsrv3test.pfx"), "idsrv3test"))
        .AddInMemoryApiResources(builder.Configuration.GetSection("IdentityServer:ApiResources"))
        .AddInMemoryApiScopes(builder.Configuration.GetSection("IdentityServer:ApiScopes"))
        .AddInMemoryClients(builder.Configuration.GetSection("IdentityServer:Clients"))
        .AddCustomUserStore();
        return builder;
    }

    public static WebApplicationBuilder AddIdentityServerServicesFromClass(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityServer()
        .AddSigningCredential(new X509Certificate2(Path.Combine("idsrv3test.pfx"), "idsrv3test"))
        .AddInMemoryApiResources(Resources.GetApiResources())
        .AddInMemoryApiScopes(Scopes.GetScopes())
        .AddInMemoryClients(Clients.GetClients())
        .AddCustomUserStore();
        return builder;
    }

    public static WebApplicationBuilder AddIdentityAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(
                IdentityServerAuthenticationDefaults.AuthenticationScheme,
                options => {
                    options.Authority = builder.Configuration["IdentityServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.Audience = builder.Configuration["IdentityServer:ApiName"];
                    options.TokenValidationParameters.ValidateIssuer = false;
                    //options.TokenValidationParameters.ValidIssuers = new[]
                    //{
                    //    builder.Configuration["IdentityServer:ValidIssuer"]
                    //};
                },
                null
            );

        return builder;
    }
}
