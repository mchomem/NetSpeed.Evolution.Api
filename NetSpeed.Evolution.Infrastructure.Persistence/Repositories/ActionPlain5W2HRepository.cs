namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class ActionPlain5W2HRepository : IActionPlain5W2HRepository
{
    private readonly IRepositoryBase<ActionPlain5W2H> _repositoryBase;

    public ActionPlain5W2HRepository(IRepositoryBase<ActionPlain5W2H> repositoryBase)
    {        
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<ActionPlain5W2H, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<ActionPlain5W2H> CreateAsync(ActionPlain5W2H entity)
    {
        var actionPlain5W2H = await _repositoryBase.CreateAsync(entity);
        return actionPlain5W2H;
    }

    public async Task<IEnumerable<ActionPlain5W2H>> CreateManyAsync(IEnumerable<ActionPlain5W2H> entities)
    {
        var actionPlains5W2H = await _repositoryBase.CreateManyAsync(entities);
        return actionPlains5W2H;
    }

    public async Task<IEnumerable<ActionPlain5W2H>> GetAllAsync(Expression<Func<ActionPlain5W2H, bool>> filter, IEnumerable<Expression<Func<ActionPlain5W2H, object>>>? includes = null)
    {
        var actionPlains5W2H = await _repositoryBase.GetAllAsync(filter, includes);
        return actionPlains5W2H;
    }

    public async Task<ActionPlain5W2H> GetAsync(long id)
    {
        var actionPlain5W2H = await _repositoryBase.GetAsync(id);
        return actionPlain5W2H;
    }

    public async Task<ActionPlain5W2H> GetAsync(Expression<Func<ActionPlain5W2H, bool>> filter, IEnumerable<Expression<Func<ActionPlain5W2H, object>>>? includes = null)
    {
        var actionPlain5W2H = await _repositoryBase.GetAsync(filter, includes);
        return actionPlain5W2H;
    }

    public async Task<ActionPlain5W2H> UpdateAsync(ActionPlain5W2H entity)
    {
        var actionPlain5W2H = await _repositoryBase.UpdateAsync(entity);
        return actionPlain5W2H;
    }
}
