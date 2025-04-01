namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class CycleRepository : ICycleRepository
{
    private readonly IRepositoryBase<Cycle> _repositoryBase;

    public CycleRepository(IRepositoryBase<Cycle> repositoryBase)
    {
        _repositoryBase = repositoryBase;        
    }

    public async Task<bool> CheckIfExists(Expression<Func<Cycle, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<Cycle> CreateAsync(Cycle entity)
    {
        var cycle = await _repositoryBase.CreateAsync(entity);
        return cycle;
    }

    public async Task<IEnumerable<Cycle>> GetAllAsync(Expression<Func<Cycle, bool>> filter, IEnumerable<Expression<Func<Cycle, object>>>? includes = null)
    {
        var cycles = await _repositoryBase.GetAllAsync(filter, includes);
        return cycles;
    }

    public async Task<Cycle> GetAsync(long id)
    {
        var cycle = await _repositoryBase.GetAsync(id);
        return cycle;
    }

    public async Task<Cycle> UpdateAsync(Cycle entity)
    {
        var cycle = await _repositoryBase.UpdateAsync(entity);
        return cycle;
    }
}
