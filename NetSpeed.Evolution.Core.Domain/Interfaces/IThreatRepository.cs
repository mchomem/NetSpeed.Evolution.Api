namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IThreatRepository
{
    public Task<IEnumerable<Threat>> CreateManyAsync(IEnumerable<Threat> entities);
    public Task<IEnumerable<Threat>> DeleteManyAsync(IEnumerable<Threat> entities);
    public Task<IEnumerable<Threat>> GetAllAsync(Expression<Func<Threat, bool>> filter, IEnumerable<Expression<Func<Threat, object>>>? includes = null);
    public Task<bool> CheckIfExists(Expression<Func<Threat, bool>> filter);
}
