namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class JobTitleRepository : IJobTitleRepository
{
    private readonly IRepositoryBase<JobTitle> _repositoryBase;

    public JobTitleRepository(IRepositoryBase<JobTitle> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<JobTitle> CreateAsync(JobTitle entity)
    {
        var jobTitle = await _repositoryBase.CreateAsync(entity);
        return jobTitle;
    }

    public async Task<JobTitle> DeleteAsync(JobTitle entity)
    {
        var jobTitle = await _repositoryBase.DeleteAsync(entity);
        return jobTitle;
    }

    public async Task<IEnumerable<JobTitle>> GetAllAsync(Expression<Func<JobTitle, bool>> filter, IEnumerable<string>? includes = null)
    {
        var jobTitles = await _repositoryBase.GetAllAsync(filter, includes);
        return jobTitles;
    }

    public async Task<JobTitle> GetAsync(long id)
    {
        var jobTitles = await _repositoryBase.GetAsync(id);
        return jobTitles;
    }

    public async Task<JobTitle> UpdateAsync(JobTitle entity)
    {
        var jobTitles = await _repositoryBase.UpdateAsync(entity);
        return jobTitles;
    }

    public async Task<bool> CheckIfExists(Expression<Func<JobTitle, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }
}
