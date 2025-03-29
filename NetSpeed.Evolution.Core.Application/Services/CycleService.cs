namespace NetSpeed.Evolution.Core.Application.Services;

public class CycleService : ICycleService
{
    private readonly ICycleRepository _cycleRepository;
    private readonly IMapper _mapper;

    public CycleService(ICycleRepository cycleRepository, IMapper mapper)
    {
        _cycleRepository = cycleRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(CycleFilter filter)
    {
        var exists = await _cycleRepository.CheckIfExists(x => x.Year.Equals(filter.Active) && x.Active);
        return exists;
    }

    public async Task<CycleDto> CreateAsync(CycleInsertDto entity)
    {
        if (await CheckIfExists(new CycleFilter() { Year = entity.Year }))
            throw new CycleAlreadyExistsException();

        var cycle = new Cycle(entity.Year);
        return _mapper.Map<CycleDto>(cycle);
    }

    public async Task<IEnumerable<CycleDto>> GetAllAsync(CycleFilter filter)
    {
        Expression<Func<Cycle, bool>> expressionFilter =
            x => (
                (!filter.Id.HasValue || x.Id == filter.Id.Value)
                && (!filter.Year.HasValue || x.Id == filter.Year.Value)
                && (!filter.Active.HasValue || x.Active == filter.Active.Value)
            );

        IEnumerable<Cycle> cycles = await _cycleRepository.GetAllAsync(expressionFilter);
        return _mapper.Map<IEnumerable<CycleDto>>(cycles);
    }

    public async Task<CycleDto> GetAsync(long id)
    {
        var cycle = await _cycleRepository.GetAsync(id);
        return _mapper.Map<CycleDto>(cycle);
    }

    public async Task<CycleDto> UpdateAsync(long id, CycleUpdateDto entity)
    {
        var cycle = await _cycleRepository.GetAsync(id);

        if (cycle is null)
            throw new CycleNotFoundException();

        if (await CheckIfExists(new CycleFilter() { Year = entity.Year }))
            throw new CycleAlreadyExistsException();

        cycle.Update(entity.Year);
        return _mapper.Map<CycleDto>(await _cycleRepository.UpdateAsync(cycle));
    }

    public async Task<CycleDto> DeactivateAsync(long id)
    {
        var cycle = await _cycleRepository.GetAsync(id);

        if (cycle is null)
            throw new CycleNotFoundException();

        cycle.Deactivate();

        var updatedCycle = await _cycleRepository.UpdateAsync(cycle);

        return _mapper.Map<CycleDto>(updatedCycle);
    }
}
