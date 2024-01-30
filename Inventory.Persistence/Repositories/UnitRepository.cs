namespace Inventory.Persistence.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly InventoryDbContext _context;

    public UnitRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Unit>> GetAll()
    {
        var units = await _context.Units.ToListAsync();
        return units;
    }

    public async Task<Unit> GetById(Guid id)
    {
        var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);
        return unit;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var unit = await _context.Units.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (unit != null)
            {
                return true;
            }
        }
        else
        {
            var unit = await _context.Units.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id != id);
            if (unit != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(Unit model)
    {
        await _context.Units.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> Update(Unit model)
    {
        _context.Units.Update(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Unit model)
    {
        _context.Units.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

}
