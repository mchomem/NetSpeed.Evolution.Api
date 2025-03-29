namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface ISwotRepository
{
    public Task<Swot> CreateAsync(Swot entity);
    public Task<Swot> DeleteAsync(Swot entity);
    public Task<Swot> GetAsync(long id);
    public Task<Swot> GetAsync(Expression<Func<Swot, bool>> filter, IEnumerable<Expression<Func<Swot, object>>>? includes = null);
    public Task<IEnumerable<Swot>> GetAllAsync(Expression<Func<Swot, bool>> filter, IEnumerable<Expression<Func<Swot, object>>>? includes = null);
    public Task<Swot> UpdateAsync(Swot entity);
    public Task<bool> CheckIfExists(Expression<Func<Swot, bool>> filter);
}
