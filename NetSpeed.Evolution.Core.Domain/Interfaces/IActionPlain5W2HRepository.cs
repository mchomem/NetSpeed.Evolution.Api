namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IActionPlain5W2HRepository
{
    public Task<ActionPlain5W2H> CreateAsync(ActionPlain5W2H entity);
    public Task<IEnumerable<ActionPlain5W2H>> CreateManyAsync(IEnumerable<ActionPlain5W2H> entities);
    public Task<ActionPlain5W2H> GetAsync(long id);
    public Task<ActionPlain5W2H> GetAsync(Expression<Func<ActionPlain5W2H, bool>> filter, IEnumerable<Expression<Func<ActionPlain5W2H, object>>>? includes = null);
    public Task<IEnumerable<ActionPlain5W2H>> GetAllAsync(Expression<Func<ActionPlain5W2H, bool>> filter, IEnumerable<Expression<Func<ActionPlain5W2H, object>>>? includes = null);
    public Task<ActionPlain5W2H> UpdateAsync(ActionPlain5W2H entity);
    public Task<bool> CheckIfExists(Expression<Func<ActionPlain5W2H, bool>> filter);
}
