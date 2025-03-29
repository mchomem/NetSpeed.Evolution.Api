namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IWeaknessRepository
{
    public Task<IEnumerable<Weakness>> CreateManyAsync(IEnumerable<Weakness> entities);
    public Task<IEnumerable<Weakness>> DeleteManyAsync(IEnumerable<Weakness> entities);
    public Task<IEnumerable<Weakness>> GetAllAsync(Expression<Func<Weakness, bool>> filter, IEnumerable<Expression<Func<Weakness, object>>>? includes = null);
    public Task<bool> CheckIfExists(Expression<Func<Weakness, bool>> filter);
}
