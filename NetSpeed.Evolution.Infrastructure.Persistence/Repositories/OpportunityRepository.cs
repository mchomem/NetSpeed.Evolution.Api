namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class OpportunityRepository : IOpportunityRepository
{
    private readonly IRepositoryBase<Opportunity> _repositoryBase;

    public OpportunityRepository(IRepositoryBase<Opportunity> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<Opportunity, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<IEnumerable<Opportunity>> CreateManyAsync(IEnumerable<Opportunity> entities)
    {
        var opportunities = await _repositoryBase.CreateManyAsync(entities);
        return opportunities;
    }

    public async Task<IEnumerable<Opportunity>> DeleteManyAsync(IEnumerable<Opportunity> entities)
    {
        var opportunities = await _repositoryBase.DeleteManyAsync(entities);
        return opportunities;
    }

    public async Task<IEnumerable<Opportunity>> GetAllAsync(Expression<Func<Opportunity, bool>> filter, IEnumerable<Expression<Func<Opportunity, object>>>? includes = null)
    {
        var opportunities = await _repositoryBase.GetAllAsync(filter, includes);
        return opportunities;
    }
}
