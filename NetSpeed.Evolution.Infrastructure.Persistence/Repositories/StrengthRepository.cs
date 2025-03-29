namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class StrengthRepository : IStrengthRepository
{
    private readonly IRepositoryBase<Strength> _repositoryBase;

    public StrengthRepository(IRepositoryBase<Strength> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<Strength, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<IEnumerable<Strength>> CreateManyAsync(IEnumerable<Strength> entities)
    {
        var strengths = await _repositoryBase.CreateManyAsync(entities);
        return strengths;
    }

    public async Task<IEnumerable<Strength>> DeleteManyAsync(IEnumerable<Strength> entities)
    {
        var strengths = await _repositoryBase.DeleteManyAsync(entities);
        return strengths;
    }

    public async Task<IEnumerable<Strength>> GetAllAsync(Expression<Func<Strength, bool>> filter, IEnumerable<Expression<Func<Strength, object>>>? includes = null)
    {
        var strengths = await _repositoryBase.GetAllAsync(filter, includes);
        return strengths;
    }
}
