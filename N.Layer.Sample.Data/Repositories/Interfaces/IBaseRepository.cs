using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using N.Layer.Sample.Data.Entities;

namespace N.Layer.Sample.Data.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);

    public Task<TEntity?> GetByIdAsync(int id);

    public Task AddAsync(TEntity entity);

    public void Remove(TEntity entity);

    public Task<int> CommitChangesAsync();
}