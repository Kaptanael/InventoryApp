namespace Inventory.Persistence.Repositories;

public class VendorRepository : IVendorRepository
{
    private readonly InventoryDbContext _context;

    public VendorRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vendor>> GetAll()
    {
        var vendors = await _context.Vendors.ToListAsync();
        return vendors;
    }

    public async Task<Vendor> GetById(Guid id)
    {
        var vendor = await _context.Vendors.FirstOrDefaultAsync(u => u.Id == id);
        return vendor;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (vendor != null)
            {
                return true;
            }
        }
        else
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id != id);
            if (vendor != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(Vendor model)
    {
        await _context.Vendors.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> Update(Vendor model)
    {
        _context.Vendors.Update(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Vendor model)
    {
        _context.Vendors.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
}
