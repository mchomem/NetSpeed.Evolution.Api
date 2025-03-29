namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class WeaknessRepository : IWeaknessRepository
{
    private readonly IRepositoryBase<Weakness> _repositoryBase;

    public WeaknessRepository(IRepositoryBase<Weakness> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<Weakness, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<IEnumerable<Weakness>> CreateManyAsync(IEnumerable<Weakness> entities)
    {
        var weaknesses = await _repositoryBase.CreateManyAsync(entities);
        return weaknesses;
    }

    public async Task<IEnumerable<Weakness>> DeleteManyAsync(IEnumerable<Weakness> entities)
    {
        var weaknesses = await _repositoryBase.DeleteManyAsync(entities);
        return weaknesses;
    }

    public async Task<IEnumerable<Weakness>> GetAllAsync(Expression<Func<Weakness, bool>> filter, IEnumerable<Expression<Func<Weakness, object>>>? includes = null)
    {
        var weaknesses = await _repositoryBase.GetAllAsync(filter, includes);
        return weaknesses;
    }
}
