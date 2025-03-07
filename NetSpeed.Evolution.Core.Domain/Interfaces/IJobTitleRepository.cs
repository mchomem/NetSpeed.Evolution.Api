namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IJobTitleRepository
{
    public Task<JobTitle> CreateAsync(JobTitle entity);
    public Task<JobTitle> DeleteAsync(JobTitle entity);
    public Task<JobTitle> GetAsync(long id);
    public Task<IEnumerable<JobTitle>> GetAllAsync(Expression<Func<JobTitle, bool>> filter, IEnumerable<string>? includes = null);
    public Task<JobTitle> UpdateAsync(JobTitle entity);
}
