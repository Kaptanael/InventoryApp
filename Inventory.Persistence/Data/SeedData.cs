namespace Inventory.Persistence.Data;

public class SeedData
{
    public static Guid ADMIN_ROLE_ID = new Guid("17EAA0E3-4E95-4A6A-9466-3B601DFE0439");
    public static Guid MANAGER_ROLE_ID = new Guid("82D4C8E9-7981-4B7C-9023-7A90B5D9B70C");
    public static Guid SALE_ROLE_ID = new Guid("01E52044-DE7C-405A-A6B0-EA73B4D892CD");

    public static Guid ADMIN_USER_ID = new Guid("01E52044-DE7C-405A-A6B0-EA73B4D892CD");

    public static Guid HOME_MENU_ID = new Guid("A8CB36D9-D016-44D2-81F5-EA0AC40F5F30");
    public static Guid BRANCH_MENU_ID = new Guid("AE090CC8-014C-40C2-AE07-4807566EBBFE");
    public static Guid WAREHOUSE_MENU_ID = new Guid("37AE13AA-8918-4222-801B-E46F8434FCA1");
    public static Guid PRODUCT_MENU_ID = new Guid("B05FED89-DB26-41A8-8EF2-52AF9862E749");
    public static Guid STOCK_MENU_ID = new Guid("BE8E20F8-3940-4F2C-829F-70AEA86BC21C");
    public static Guid VENDOR_MENU_ID = new Guid("DD7F8EE8-9601-45F4-9586-0F323715E86F");
    public static Guid ORDER_MENU_ID = new Guid("4DF6E904-03C0-443E-95A2-49AE9B987816");
    public static Guid CUSTOMER_MENU_ID = new Guid("182E1D96-E811-4E81-9B7C-A7FFC5426D2F");

    public static void PopulateDb(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        AddInitialData(serviceScope.ServiceProvider.GetService<InventoryDbContext>());
    }
    private static void AddInitialData(InventoryDbContext context)
    {
        //addRoles(context);
        //addUsers(context);
        //addMenus(context);
        //addProductTypes(context);
        //SaveChanges(context);
    }

    private static void addRoles(InventoryDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Role>()
                {
                    new Role { Id = ADMIN_ROLE_ID, Name = "Admin"},
                    new Role { Id = MANAGER_ROLE_ID, Name = "Manager"},
                    new Role { Id = SALE_ROLE_ID, Name = "Sale"}
                };

            context.Roles.AddRange(roles);
        }
    }

    private static void addUsers(InventoryDbContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<User>()
                {
                    new User
                    {
                        Id = ADMIN_USER_ID,
                        UserName = "admin",
                        FirstName = "Captain",
                        LastName = "Black",
                        Password = "123456",
                        Email = "test@test.com",
                        Mobile = "01721525318",
                        IsActive = true,
                        CreatedBy = ADMIN_USER_ID,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = ADMIN_USER_ID,
                        UpdatedDate = DateTime.Now,
                        UserRoles = new List<UserRole>()
                        {
                            new UserRole { UserId = ADMIN_USER_ID, RoleId = ADMIN_ROLE_ID,}
                        }
                    }
                };

            context.Users.AddRange(users);
        }
    }

    private static void addMenus(InventoryDbContext context)
    {
        if (!context.Menus.Any())
        {
            var menus = new List<Menu>()
                {
                    new Menu { Id = HOME_MENU_ID, Name = "Home"},
                    new Menu { Id = BRANCH_MENU_ID, Name = "Branch"},
                    new Menu { Id = PRODUCT_MENU_ID, Name = "Ware House"},
                    new Menu { Id = STOCK_MENU_ID, Name = "Stock"},
                    new Menu { Id = VENDOR_MENU_ID, Name = "Vendor"},
                    new Menu { Id = ORDER_MENU_ID, Name = "Order"},
                    new Menu { Id = CUSTOMER_MENU_ID, Name = "Customer"},
                };

            context.Menus.AddRange(menus);
        }
    }

    private static void addProductTypes(InventoryDbContext context)
    {
        if (!context.ProductTypes.Any())
        {
            var menus = new List<ProductType>()
                {
                    new ProductType { Name = "Skin Care", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Health Care", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Makeup", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Fragrances", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Beauty Tools", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Bath & Body", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Personal Care", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Men's Care", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                    new ProductType { Name = "Sexual Wellness", CreatedBy = ADMIN_USER_ID, CreatedDate = DateTime.Now, UpdatedBy = ADMIN_USER_ID, UpdatedDate = DateTime.Now},
                };

            context.ProductTypes.AddRange(menus);
        }
    }

    private static void SaveChanges(InventoryDbContext context)
    {
        context.SaveChanges();
    }
}
