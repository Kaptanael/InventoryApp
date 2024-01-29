namespace Inventory.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly InventoryDbContext _context;

    public MenuRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Menu>> GetAll()
    {
        var menus = await _context.Menus.ToListAsync();
        return menus;
    }

    public async Task<Menu> GetById(Guid id)
    {
        var menu = await _context.Menus.FirstOrDefaultAsync(u => u.Id == id);
        return menu;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (menu != null)
            {
                return true;
            }
        }
        else
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id != id);
            if (menu != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(Menu model)
    {
        await _context.Menus.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> Update(Menu model)
    {
        _context.Menus.Update(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Menu model)
    {
        _context.Menus.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

}
