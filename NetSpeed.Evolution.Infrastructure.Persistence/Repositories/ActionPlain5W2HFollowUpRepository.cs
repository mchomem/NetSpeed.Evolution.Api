namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class ActionPlain5W2HFollowUpRepository : IActionPlain5W2HFollowUpRepository
{
    private readonly IRepositoryBase<ActionPlain5W2HFollowUp> _repositoryBase;

    public ActionPlain5W2HFollowUpRepository(IRepositoryBase<ActionPlain5W2HFollowUp> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<ActionPlain5W2HFollowUp, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<ActionPlain5W2HFollowUp> CreateAsync(ActionPlain5W2HFollowUp entity)
    {
        var actionPlain5W2HFollowUp = await _repositoryBase.CreateAsync(entity);
        return actionPlain5W2HFollowUp;
    }

    public async Task<ActionPlain5W2HFollowUp> DeleteAsync(ActionPlain5W2HFollowUp entity)
    {
        var actionPlain5W2HFollowUp = await _repositoryBase.DeleteAsync(entity);
        return actionPlain5W2HFollowUp;
    }

    public async Task<IEnumerable<ActionPlain5W2HFollowUp>> GetAllAsync(Expression<Func<ActionPlain5W2HFollowUp, bool>> filter, IEnumerable<Expression<Func<ActionPlain5W2HFollowUp, object>>>? includes = null)
    {
        var actionPlain5W2HFollowUps = await _repositoryBase.GetAllAsync(filter, includes);
        return actionPlain5W2HFollowUps;
    }

    public async Task<ActionPlain5W2HFollowUp> GetAsync(long id)
    {
        var actionPlain5W2HFollowUp = await _repositoryBase.GetAsync(id);
        return actionPlain5W2HFollowUp;
    }

    public async Task<ActionPlain5W2HFollowUp> UpdateAsync(ActionPlain5W2HFollowUp entity)
    {
        var actionPlain5W2HFollowUp = await _repositoryBase.UpdateAsync(entity);
        return actionPlain5W2HFollowUp;
    }
}
