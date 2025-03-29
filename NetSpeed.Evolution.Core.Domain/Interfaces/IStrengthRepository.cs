namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IStrengthRepository
{
    public Task<IEnumerable<Strength>> CreateManyAsync(IEnumerable<Strength> entities);
    public Task<IEnumerable<Strength>> DeleteManyAsync(IEnumerable<Strength> entities);
    public Task<IEnumerable<Strength>> GetAllAsync(Expression<Func<Strength, bool>> filter, IEnumerable<Expression<Func<Strength, object>>>? includes = null);
    public Task<bool> CheckIfExists(Expression<Func<Strength, bool>> filter);
}
