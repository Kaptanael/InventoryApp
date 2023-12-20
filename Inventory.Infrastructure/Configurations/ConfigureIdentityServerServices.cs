namespace Inventory.Infrastructure.Configurations;

public static class IdentityServerServices
{
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
}
