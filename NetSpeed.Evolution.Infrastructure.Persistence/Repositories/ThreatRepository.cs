namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class ThreatRepository : IThreatRepository
{
    private readonly IRepositoryBase<Threat> _repositoryBase;

    public ThreatRepository(IRepositoryBase<Threat> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<Threat, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<IEnumerable<Threat>> CreateManyAsync(IEnumerable<Threat> entities)
    {
        var threats = await _repositoryBase.CreateManyAsync(entities);
        return threats;
    }

    public async Task<IEnumerable<Threat>> DeleteManyAsync(IEnumerable<Threat> entities)
    {
        var threats = await _repositoryBase.DeleteManyAsync(entities);
        return threats;
    }

    public async Task<IEnumerable<Threat>> GetAllAsync(Expression<Func<Threat, bool>> filter, IEnumerable<Expression<Func<Threat, object>>>? includes = null)
    {
        var threats = await _repositoryBase.GetAllAsync(filter, includes);
        return threats;
    }
}
