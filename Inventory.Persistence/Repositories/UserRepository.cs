﻿
using Inventory.Application.Features;

namespace Inventory.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly InventoryDbContext _context;

    public UserRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUser(string userName, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        return user;
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<UserWithRoleDto> GetUserWithRole(Guid id)
    {
        UserWithRoleDto user = null;
        user = await (from u in _context.Users
                      join role in _context.UserRoles
                      on u.Id equals role.UserId
                      where u.Id == id
                      select (new UserWithRoleDto
                      {
                          Id = u.Id,
                          UserName = u.UserName,
                          FirstName = u.FirstName,
                          LastName = u.LastName,
                          Email = u.Email,
                          Mobile = u.Mobile,
                          IsActive = u.IsActive,
                          RoleId = role.RoleId
                      })
                ).FirstOrDefaultAsync();
        //var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<bool> IsExistUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user != null)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> IsExistEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> IsExistEmailExceptMe(string email, Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Id != id);
        if (user != null)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> IsActiveUser(Guid id)
    {
        bool isActive = false;
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user != null)
        {
            isActive = user.IsActive;
        }
        return isActive;
    }

    public async Task<Guid> Insert(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<Guid> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<Guid> Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<List<User>> GetAllUser()
    {
        var user = await _context.Users.ToListAsync();
        return user;
    }

    public async Task<Guid> DeleteUserRole(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
        return userRole.UserId;
    }
}
