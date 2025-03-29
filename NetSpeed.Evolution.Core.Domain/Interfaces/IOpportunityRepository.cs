namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IOpportunityRepository
{
    public Task<IEnumerable<Opportunity>> CreateManyAsync(IEnumerable<Opportunity> entities);
    public Task<IEnumerable<Opportunity>> DeleteManyAsync(IEnumerable<Opportunity> entities);
    public Task<IEnumerable<Opportunity>> GetAllAsync(Expression<Func<Opportunity, bool>> filter, IEnumerable<Expression<Func<Opportunity, object>>>? includes = null);
    public Task<bool> CheckIfExists(Expression<Func<Opportunity, bool>> filter);
}
