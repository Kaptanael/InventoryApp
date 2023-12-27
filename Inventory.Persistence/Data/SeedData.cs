﻿using Microsoft.AspNetCore.Builder;

namespace Inventory.Persistence.Data;

public class SeedData
{
    public static Guid ADMIN_ROLE_ID = new Guid("17EAA0E3-4E95-4A6A-9466-3B601DFE0439");
    public static Guid MANAGER_ROLE_ID = new Guid("82D4C8E9-7981-4B7C-9023-7A90B5D9B70C");
    public static Guid SALE_ROLE_ID = new Guid("01E52044-DE7C-405A-A6B0-EA73B4D892CD");

    public static Guid ADMIN_USER_ID = new Guid("01E52044-DE7C-405A-A6B0-EA73B4D892CD");

    public static void PopulateDb(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        AddInitialData(serviceScope.ServiceProvider.GetService<InventoryDbContext>());
    }
    private static void AddInitialData(InventoryDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Role>()
                {
                    new Role { Id=ADMIN_ROLE_ID, Name = "Admin"},
                    new Role { Id= MANAGER_ROLE_ID, Name = "Manager"},
                    new Role { Id= SALE_ROLE_ID, Name = "Sale"}
                };

            context.Roles.AddRange(roles);            
        }

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
                        Password="123456",
                        Email = "test@test.com",
                        Mobile="01721525318",
                        IsActive=true,
                        CreatedBy = 1,
                        CreatedDate= DateTime.Now,
                        UserRoles = new List<UserRole>()
                        {
                            new UserRole { UserId = ADMIN_USER_ID, RoleId=ADMIN_ROLE_ID,}
                        }
                    }
                };

            context.Users.AddRange(users);            
        }

        context.SaveChanges();
    }
}