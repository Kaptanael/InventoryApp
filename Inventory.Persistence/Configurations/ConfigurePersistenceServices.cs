namespace Inventory.Persistence.Configurations;

public static class ConfigurePersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<InventoryDbContext>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
