namespace Inventory.Persistence.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly InventoryDbContext _context;

    public BranchRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Branch>> GetAll(string? search)
    {
        List<Branch> branches = new List<Branch>();

        if (!string.IsNullOrEmpty(search))
        {
            branches = await _context.Branches
                .Where(b => b.Name.Contains(search) || b.City.Contains(search) || b.Province.Contains(search) || b.Country.Contains(search))
                .ToListAsync();
        }
        else 
        {
            branches = await _context.Branches.ToListAsync();
        }

        return branches;
    }

    public async Task<Branch> GetById(Guid id)
    {
        var branch = await _context.Branches.FirstOrDefaultAsync(u => u.Id == id);
        return branch;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (branch != null)
            {
                return true;
            }
        }
        else
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id != id);
            if (branch != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(Branch model)
    {
        await _context.Branches.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> Update(Branch model)
    {
        _context.Branches.Update(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Branch model)
    {
        _context.Branches.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }
}
