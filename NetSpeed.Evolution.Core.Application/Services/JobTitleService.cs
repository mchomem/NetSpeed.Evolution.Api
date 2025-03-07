namespace NetSpeed.Evolution.Core.Application.Services;

public class JobTitleService : IJobTitleService
{
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IMapper _mapper;

    public JobTitleService(IJobTitleRepository jobTitleRepository, IMapper mapper)
    {
        _jobTitleRepository = jobTitleRepository;
        _mapper = mapper;
    }

    public async Task<JobTitleDto> CreateAsync(JobTitleInsertDto entity)
    {
        var jobTitle = new JobTitle(entity.Name);
        return _mapper.Map<JobTitleDto>(await _jobTitleRepository.CreateAsync(jobTitle));
    }

    public async Task<JobTitleDto> DeleteAsync(long id)
    {
        var jobTitle = await _jobTitleRepository.GetAsync(id);

        if (jobTitle is null)
            throw new JobTitleNotFoundException();

        jobTitle.Delete();

        return _mapper.Map<JobTitleDto>(await _jobTitleRepository.UpdateAsync(jobTitle));
    }

    public async Task<IEnumerable<JobTitleDto>> GetAllAsync(JobTitleFilter filter, IEnumerable<string>? includes = null)
    {
        Expression<Func<JobTitle, bool>> expressionFilter =
            x => (
                (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name))
                && (!x.IsDeleted)
            );

        IEnumerable<JobTitle> jobTitles = await _jobTitleRepository.GetAllAsync(expressionFilter, includes);
        return _mapper.Map<IEnumerable<JobTitleDto>>(jobTitles);
    }

    public async Task<JobTitleDto> GetAsync(long id)
    {
        var jobTitle = await _jobTitleRepository.GetAsync(id);
        return _mapper.Map<JobTitleDto>(jobTitle);
    }

    public async Task<JobTitleDto> UpdateAsync(long id, JobTitleUpdateDto entity)
    {
        var jobTitle = await _jobTitleRepository.GetAsync(entity.Id);

        if (jobTitle is null)
            throw new JobTitleNotFoundException();

        jobTitle.Update(entity.Name);

        return _mapper.Map<JobTitleDto>(await _jobTitleRepository.UpdateAsync(jobTitle));
    }
}
