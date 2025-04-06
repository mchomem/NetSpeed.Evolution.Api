namespace NetSpeed.Evolution.Core.Application.Services;

public class ActionPlain5W2HService : IActionPlain5W2HService
{
    private readonly IActionPlain5W2HRepository _actionPlain5W2HRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICycleRepository _cycleRepository;
    private readonly IMapper _mapper;

    public ActionPlain5W2HService(IActionPlain5W2HRepository actionPlain5W2HRepository
        , IEmployeeRepository employeeRepository
        , ICycleRepository cycleRepository
        , IMapper mapper)
    {
        _actionPlain5W2HRepository = actionPlain5W2HRepository;
        _employeeRepository = employeeRepository;
        _cycleRepository = cycleRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(ActionPlain5W2HFilter filter)
    {
        var exists = await _actionPlain5W2HRepository.CheckIfExists(x => x.EmployeeId == filter.EmployeeId && x.CycleId == filter.CycleId);
        return exists;
    }

    public async Task<ActionPlain5W2HDto> CreateAsync(ActionPlain5W2HInsertDto entity)
    {
        var employee = await _employeeRepository.GetAsync(entity.EmployeeId);
        var cycle = await _cycleRepository.GetAsync(entity.CycleId);

        if (employee is null)
            throw new EmployeeNotFoundException();

        if (cycle is null)
            throw new CycleNotFoundException();

        var actionPlain5W2H =
            new ActionPlain5W2H(
                entity.EmployeeId,
                entity.CycleId,
                entity.ImprovementPoint,
                entity.What,
                entity.Who,
                entity.Why,
                entity.Where,
                entity.When,
                entity.How,
                entity.HowMuch,
                entity.Observation);

        return _mapper.Map<ActionPlain5W2HDto>(await _actionPlain5W2HRepository.CreateAsync(actionPlain5W2H));
    }

    public async Task<IEnumerable<ActionPlain5W2HDto>> CreateManyAsync(IEnumerable<ActionPlain5W2HInsertDto> entities)
    {
        List<ActionPlain5W2H> actionPlain5W2HDtos = new List<ActionPlain5W2H>();

        foreach (var entity in entities)
        {
            var employee = await _employeeRepository.GetAsync(entity.EmployeeId);
            var cycle = await _cycleRepository.GetAsync(entity.CycleId);

            if (employee is null)
                throw new EmployeeNotFoundException();

            if (cycle is null)
                throw new CycleNotFoundException();

            actionPlain5W2HDtos.Add(
            new ActionPlain5W2H(
                entity.EmployeeId,
                entity.CycleId,
                entity.ImprovementPoint,
                entity.What,
                entity.Who,
                entity.Why,
                entity.Where,
                entity.When,
                entity.How,
                entity.HowMuch,
                entity.Observation));
        }

        var manyActionPlain5W2H = await _actionPlain5W2HRepository.CreateManyAsync(actionPlain5W2HDtos);
        return _mapper.Map<IEnumerable<ActionPlain5W2HDto>>(manyActionPlain5W2H);
    }

    public async Task<IEnumerable<ActionPlain5W2HDto>> GetAllAsync(ActionPlain5W2HFilter filter)
    {
        Expression<Func<ActionPlain5W2H, bool>> expressionFilter =
            x => (
                (!filter.Id.HasValue || x.Id == filter.Id.Value)
                && (!filter.EmployeeId.HasValue || x.EmployeeId == filter.EmployeeId.Value)
                && (!filter.CycleId.HasValue || x.CycleId == filter.CycleId.Value)
                && (!filter.StartCreatedAt.HasValue || x.CreatedAt >= filter.StartCreatedAt.Value)
                && (!filter.EndCreatedAt.HasValue || x.CreatedAt <= filter.EndCreatedAt.Value)
                && (!filter.StartUpdatedAt.HasValue || x.UpdatedAt >= filter.StartUpdatedAt.Value)
                && (!filter.EndUpdatedAt.HasValue || x.UpdatedAt >= filter.EndUpdatedAt.Value)
            );

        IEnumerable<Expression<Func<ActionPlain5W2H, object>>> includes = new List<Expression<Func<ActionPlain5W2H, object>>>()
        {
            x => x.Employee, x => x.Cycle
        };

        IEnumerable<ActionPlain5W2H> actionPlain5W2Hs = await _actionPlain5W2HRepository.GetAllAsync(expressionFilter, includes);

        if (actionPlain5W2Hs is null)
            throw new ActionPlain5W2HNotFoundException();

        return _mapper.Map<IEnumerable<ActionPlain5W2HDto>>(actionPlain5W2Hs);
    }

    public async Task<ActionPlain5W2HDto> GetAsync(long id)
    {
        IEnumerable<Expression<Func<ActionPlain5W2H, object>>> includes = new List<Expression<Func<ActionPlain5W2H, object>>>()
        {
            x => x.Employee, x => x.Cycle
        };

        var actionPlain5W2H = await _actionPlain5W2HRepository.GetAsync(x => x.Id == id, includes);

        if (actionPlain5W2H is null)
            throw new ActionPlain5W2HNotFoundException();

        return _mapper.Map<ActionPlain5W2HDto>(actionPlain5W2H);
    }

    public async Task<ActionPlain5W2HDto> UpdateAsync(long id, ActionPlain5W2HUpdateDto entity)
    {
        var actionPlain5W2H = await _actionPlain5W2HRepository.GetAsync(id);
        var employee = await _employeeRepository.GetAsync(entity.EmployeeId);
        var cycle = await _cycleRepository.GetAsync(entity.CycleId);

        if (actionPlain5W2H is null)
            throw new ActionPlain5W2HNotFoundException();

        if (employee is null)
            throw new EmployeeNotFoundException();

        if (cycle is null)
            throw new CycleNotFoundException();

        actionPlain5W2H.Update(           
                entity.EmployeeId,
                entity.ImprovementPoint,
                entity.What,
                entity.Who,
                entity.Why,
                entity.Where,
                entity.When,
                entity.How,
                entity.HowMuch,
                entity.Observation);

        var updatedActionPLain5W2H = await _actionPlain5W2HRepository.UpdateAsync(actionPlain5W2H);

        return _mapper.Map<ActionPlain5W2HDto>(updatedActionPLain5W2H);
    }
}
