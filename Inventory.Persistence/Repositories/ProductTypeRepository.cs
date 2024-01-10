namespace Inventory.Persistence.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly InventoryDbContext _context;

    public ProductTypeRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductType>> GetAll()
    {
        var productTypes = await _context.ProductTypes.ToListAsync();
        return productTypes;
    }

    public async Task<ProductType> GetById(Guid id)
    {
        var productType = await _context.ProductTypes.FirstOrDefaultAsync(u => u.Id == id);
        return productType;
    }

    public async Task<bool> IsExist(string name, Guid? id = null)
    {
        if (id == null)
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper());
            if (productType != null)
            {
                return true;
            }
        }
        else
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(u => u.Name.ToUpper() == name.Trim().ToUpper() && u.Id != id);
            if (productType != null)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<Guid> Create(ProductType model)
    {
        await _context.ProductTypes.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> Update(ProductType model)
    {
        _context.ProductTypes.Update(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(ProductType model)
    {
        _context.ProductTypes.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

}
