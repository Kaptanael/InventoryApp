namespace Inventory.Persistence.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly InventoryDbContext _context;

    public WarehouseRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Warehouse>> GetAll()
    {
        var warehouses = await _context.Warehouses.ToListAsync();
        return warehouses;
    }

    public async Task<Warehouse> GetById(Guid id)
    {
        var warehouse = await _context.Warehouses.FirstOrDefaultAsync(u => u.Id == id);
        return warehouse;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (warehouse != null)
            {
                return true;
            }
        }
        else
        {
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id != id);
            if (warehouse != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(Warehouse model)
    {
        await _context.Warehouses.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> Update(Warehouse model)
    {
        _context.Warehouses.Update(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Warehouse model)
    {
        _context.Warehouses.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
}
