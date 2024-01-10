namespace Inventory.Persistence.Configurations;

public static class ConfigurePersistenceServices
{
    public static WebApplicationBuilder AddPersistenceServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<InventoryDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddDbContext<InventoryDbContext>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IBranchRepository, BranchRepository>();
        builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

        return builder;
    }
}
