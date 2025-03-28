namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface ICycleRepository
{
    public Task<Cycle> CreateAsync(Cycle entity);
    public Task<Cycle> GetAsync(long id);
    public Task<IEnumerable<Cycle>> GetAllAsync(Expression<Func<Cycle, bool>> filter, IEnumerable<Expression<Func<Cycle, object>>>? includes = null);
    public Task<Cycle> UpdateAsync(Cycle entity);
    public Task<bool> CheckIfExists(Expression<Func<Cycle, bool>> filter);
}
