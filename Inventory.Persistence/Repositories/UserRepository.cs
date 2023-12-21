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
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.UserName == userName && u.Password == password); 
        return user;
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
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
}
