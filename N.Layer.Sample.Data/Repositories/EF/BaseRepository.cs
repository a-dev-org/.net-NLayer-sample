using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N.Layer.Sample.Data.Entities;
using N.Layer.Sample.Data.Repositories.Interfaces;

namespace N.Layer.Sample.Data.Repositories.EF;

public class BaseRepository<TEntity>(NLayerDbContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await _dbSet.ToListAsync();

    public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where) =>
        await _dbSet.Where(where).ToListAsync();

    public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

    public void Remove(TEntity entity) => _dbSet.Remove(entity);

    public async Task<int> CommitChangesAsync() => await context.SaveChangesAsync();
}