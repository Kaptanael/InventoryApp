﻿namespace Inventory.Application.Contracts.Persistence;

public interface IBranchRepository
{   
    Task<List<Branch>> GetAll(string? search);

    Task<Branch> GetById(Guid id);

    Task<bool> IsExist(string name, Guid? id = null);

    Task<Guid> Create(Branch model);

    Task<bool> Update(Branch model);

    Task<bool> Delete(Branch model);
}
