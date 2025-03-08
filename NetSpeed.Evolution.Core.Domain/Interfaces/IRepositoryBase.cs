namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    public Task<TEntity> CreateAsync(TEntity entity);
    public Task<TEntity> DeleteAsync(TEntity entity);
    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<string>? includes = null);
    public Task<TEntity> GetAsync(long id);
    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<string>? includes = null);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<bool> CheckIfExists(Expression<Func<TEntity, bool>> filter);
}
