namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IJobTitleService
{
    public Task<JobTitleDto> CreateAsync(JobTitleInsertDto entity);
    public Task<JobTitleDto> DeleteAsync(long id);
    public Task<JobTitleDto> GetAsync(long id);
    public Task<IEnumerable<JobTitleDto>> GetAllAsync(JobTitleFilter filter, IEnumerable<string>? includes = null);
    public Task<JobTitleDto> UpdateAsync(long id, JobTitleUpdateDto entity);
}
