namespace Inventory.Persistence.Repositories;

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

    public async Task<Role> Get(Guid id)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(u => u.Id == id);
        return role;
    }

    public async Task<Guid> Add(Role role)
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
