namespace NetSpeed.Evolution.Core.Application.Services;

public class EmployeeHardSkillService : IEmployeeHardSkillService
{
    private readonly IEmployeeHardSkillRepository _employeeHardSkillRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHardSkillRepository _hardSkillRepository;
    private readonly IMapper _mapper;

    public EmployeeHardSkillService(IEmployeeHardSkillRepository employeeHardSkillRepository
        , IEmployeeRepository employeeRepository
        , IHardSkillRepository hardSkillRepository
        , IMapper mapper)
    {
        _employeeHardSkillRepository = employeeHardSkillRepository;
        _employeeRepository = employeeRepository;
        _hardSkillRepository = hardSkillRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(EmployeeHardSkillFilter filter)
    {
        var exists = await _employeeHardSkillRepository.CheckIfExists(x => x.EmployeeId == filter.EmployeeId && x.HardSkillId == filter.HardSkillId);
        return exists;
    }

    public async Task<EmployeeHardSkillDto> CreateAsync(EmployeeHardSkillInsertDto entity)
    {
        var employee = await _employeeRepository.GetAsync(entity.EmployeeId);
        var hardSkill = await _hardSkillRepository.GetAsync(entity.HardSkillId);

        if (employee is null)
            throw new EmployeeNotFoundException();

        if (hardSkill is null)
            throw new HardSkillNotFoundException();

        if (await CheckIfExists(new EmployeeHardSkillFilter() { EmployeeId = entity.EmployeeId, HardSkillId = entity.HardSkillId }))
            throw new EmployeeHardSkillAlreadyExistsException();

        var employeeHardSkill = new EmployeeHardSkill(entity.EmployeeId, entity.HardSkillId, entity.Level);
        return _mapper.Map<EmployeeHardSkillDto>(await _employeeHardSkillRepository.CreateAsync(employeeHardSkill));
    }

    public async Task<EmployeeHardSkillDto> DeleteAsync(long employeeId, long hardSkillId)
    {
        var employeeHardSkill = await _employeeHardSkillRepository.GetAsync(x => x.EmployeeId == employeeId && x.HardSkillId == hardSkillId);

        if (employeeHardSkill is null)
            throw new EmployeeHardSkillNotFoundException();

        return _mapper.Map<EmployeeHardSkillDto>(await _employeeHardSkillRepository.DeleteAsync(employeeHardSkill));
    }

    public async Task<IEnumerable<EmployeeHardSkillDto>> GetAllAsync(EmployeeHardSkillFilter filter)
    {
        Expression<Func<EmployeeHardSkill, bool>> expressionFilter =
            x => (
                (!filter.EmployeeId.HasValue || x.EmployeeId == filter.EmployeeId.Value)
                && (!filter.HardSkillId.HasValue || x.HardSkillId == filter.HardSkillId.Value)
                && (!filter.Level.HasValue || x.Level == filter.Level.Value)
            );
        
        IEnumerable<Expression<Func<EmployeeHardSkill, object>>> includes = new List<Expression<Func<EmployeeHardSkill, object>>>()
        { 
            x => x.Employee, x => x.HardSkill
        };

        IEnumerable<EmployeeHardSkill> employeeHardSkills = await _employeeHardSkillRepository.GetAllAsync(expressionFilter, includes);
        return _mapper.Map<IEnumerable<EmployeeHardSkillDto>>(employeeHardSkills);
    }

    public async Task<EmployeeHardSkillDto> GetAsync(long employeeId, long hardSkillId)
    {
        IEnumerable<Expression<Func<EmployeeHardSkill, object>>> includes = new List<Expression<Func<EmployeeHardSkill, object>>>()
        {
            x => x.Employee, x => x.HardSkill
        };
        var employeeHardSkill = await _employeeHardSkillRepository.GetAsync(x => x.EmployeeId == employeeId && x.HardSkillId == hardSkillId, includes);
        return _mapper.Map<EmployeeHardSkillDto>(employeeHardSkill);
    }

    public async Task<EmployeeHardSkillDto> UpdateAsync(long employeeId, long hardSkillId, EmployeeHardSkillUpdateDto entity)
    {
        var employeeHardSkill = await _employeeHardSkillRepository.GetAsync(x => x.EmployeeId == employeeId && x.HardSkillId == hardSkillId);
        var employee = await _employeeRepository.GetAsync(entity.EmployeeId);
        var hardSkill = await _hardSkillRepository.GetAsync(entity.HardSkillId);

        if (employee is null)
            throw new EmployeeNotFoundException();

        if (hardSkill is null)
            throw new HardSkillNotFoundException();

        if (employeeHardSkill is null)
            throw new EmployeeHardSkillNotFoundException();

        if (await CheckIfExists(new EmployeeHardSkillFilter() { EmployeeId = entity.EmployeeId, HardSkillId = entity.HardSkillId }))
            throw new EmployeeHardSkillAlreadyExistsException();

        employeeHardSkill.Update(entity.Level);

        return _mapper.Map<EmployeeHardSkillDto>(await _employeeHardSkillRepository.UpdateAsync(employeeHardSkill));
    }
}
