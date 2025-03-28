namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class SwotRepository : ISwotRepository
{
    private readonly IRepositoryBase<Swot> _repositoryBase;
    private readonly AppDbContext _appDbContext;

    public SwotRepository(IRepositoryBase<Swot> repositoryBase, AppDbContext appDbContext)
    {
        _repositoryBase = repositoryBase;
        _appDbContext = appDbContext;
    }

    public async Task<bool> CheckIfExists(Expression<Func<Swot, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<Swot> CreateAsync(Swot entity)
    {
        using var transaction = await _appDbContext.Database.BeginTransactionAsync();

        try
        {
            var swot = await _repositoryBase.CreateAsync(entity);

            // TODO: trocar por implementações de repositóries isolados (padronização no projeto)
            await _appDbContext.Strength.AddRangeAsync(entity.Strengths);
            await _appDbContext.Opportunity.AddRangeAsync(entity.Opportunities);
            await _appDbContext.Weakness.AddRangeAsync(entity.Weaknesses);
            await _appDbContext.Threat.AddRangeAsync(entity.Threats);
            await _appDbContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return swot;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();

            throw;
        }
    }

    public async Task<Swot> DeleteAsync(Swot entity)
    {
        var swot = await _repositoryBase.DeleteAsync(entity);
        return swot;
    }

    public async Task<IEnumerable<Swot>> GetAllAsync(Expression<Func<Swot, bool>> filter, IEnumerable<Expression<Func<Swot, object>>>? includes = null)
    {
        var swots = await _repositoryBase.GetAllAsync(filter, includes);
        return swots;
    }

    public async Task<Swot> GetAsync(long id)
    {
        var swot = await _repositoryBase.GetAsync(id);
        return swot;
    }

    public async Task<Swot> GetAsync(Expression<Func<Swot, bool>> filter, IEnumerable<Expression<Func<Swot, object>>>? includes = null)
    {
        var swot = await _repositoryBase.GetAsync(filter, includes);
        return swot;
    }

    public async Task<Swot> UpdateAsync(Swot entity)
    {
        var swot = await _repositoryBase.UpdateAsync(entity);
        return swot;
    }
}
