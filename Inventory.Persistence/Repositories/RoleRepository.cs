﻿namespace Inventory.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly InventoryDbContext _context;

    public RoleRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetAll()
    {
        var roles = await _context.Roles.ToListAsync();
        return roles;
    }

    public async Task<Role> GetById(Guid id)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(u => u.Id == id);
        return role;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (role != null)
            {
                return true;
            }
        }
        else 
        {
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id !=id);
            if (role != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
        return role.Id;
    }

    public async Task<bool> Update(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Role role)
    {
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }

}
