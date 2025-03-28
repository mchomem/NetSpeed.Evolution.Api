namespace NetSpeed.Evolution.Core.Application.Services;

public class SwotService : ISwotService
{
    private readonly ISwotRepository _swotRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICycleRepository _cycleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public SwotService(ISwotRepository swotRepository, IEmployeeRepository employeeRepository, ICycleRepository cycleRepository, IUserRepository userRepository, IMapper mapper)
    {
        _swotRepository = swotRepository;
        _employeeRepository = employeeRepository;
        _cycleRepository = cycleRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(SwotFilter filter)
    {
        var exists = await _swotRepository.CheckIfExists(x => x.EmployeeId == filter.EmployeeId && x.CycleId == filter.CycleId);
        return exists;
    }

    public async Task<SwotDto> CreateAsync(SwotInsertDto entity)
    {
        if (await CheckIfExists(new SwotFilter() { EmployeeId = entity.EmployeeId, CycleId = entity.CycleId }))
            throw new SwotAlreadyExistsException();

        var cycle = await _cycleRepository.GetAsync(entity.CycleId);
        var createdUser = await _userRepository.GetAsync(entity.CreatedById);
        var employee = await _employeeRepository.GetAsync(entity.EmployeeId);

        if (cycle is null)
            throw new CycleNotFoundException();

        if (!cycle.Active)
            throw new CycleInactiveException();

        if (createdUser is null)
            throw new UserNotFoundException("O usuário de criação do registro não existe");

        if(employee is null)
            throw new EmployeeNotFoundException();

        var strengths = _mapper.Map<IEnumerable<Strength>>(entity.Strengths).ToList();
        var opportunities = _mapper.Map<IEnumerable<Opportunity>>(entity.Opportunities).ToList();
        var weaknesses = _mapper.Map<IEnumerable<Weakness>>(entity.Weaknesses).ToList();
        var threats = _mapper.Map<IEnumerable<Threat>>(entity.Threats).ToList();

        var swot = new Swot(entity.EmployeeId, entity.CreatedById, strengths, opportunities, weaknesses, threats, entity.CycleId);
        return _mapper.Map<SwotDto>(await _swotRepository.CreateAsync(swot));
    }

    public async Task<SwotDto> GetAsync(long employeeId, long cycleId)
    {
        IEnumerable<Expression<Func<Swot, object>>> includes = new List<Expression<Func<Swot, object>>>()
        {
            x => x.Employee
            , x => x.CreatedBy
            , x => x.UpdatedBy
        };

        // TODO: verificar se vai trazer as propriedades relacionadas.
        var swot = await _swotRepository.GetAsync(x => x.EmployeeId == employeeId && x.CycleId == cycleId, includes);
        return _mapper.Map<SwotDto>(swot);
    }

    public async Task<SwotDto> UpdateAsync(long id, SwotUpdateDto entity)
    {
        var swot = await _swotRepository.GetAsync(id);
        var employee = await _employeeRepository.GetAsync(entity.EmployeeId);
        var updateUser = await _userRepository.GetAsync(entity.UpdatedById);
        var cycle = await _cycleRepository.GetAsync(entity.CycleId);

        if (swot is null)
            throw new SwotNotFoundException();

        if (employee is null)
            throw new SwotNotFoundException();

        if (updateUser is null)
            throw new UserNotFoundException("O usuário de atualização do registro não existe");

        if(cycle is null)
            throw new CycleNotFoundException();

        if (!cycle.Active)
            throw new CycleInactiveException();

        swot.Update(entity.EmployeeId, entity.UpdatedById, entity.Status);

        return _mapper.Map<SwotDto>(await _swotRepository.UpdateAsync(swot));
    }
}
