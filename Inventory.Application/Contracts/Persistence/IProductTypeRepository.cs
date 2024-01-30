namespace Inventory.Application.Repositories;

public interface IProductTypeRepository
{   
    Task<List<ProductType>> GetAll();
    
    Task<ProductType> GetById(Guid id);
    
    Task<bool> IsExist(string name, Guid? id = null);

    Task<Guid> Create(ProductType model);

    Task<bool> Update(ProductType model);

    Task<bool> Delete(ProductType model);
}