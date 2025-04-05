namespace NetSpeed.Evolution.Core.Application.Services;

public class ActionPlain5W2HFollowUpService : IActionPlain5W2HFollowUpService
{
    private readonly IActionPlain5W2HFollowUpRepository _actionPlain5W2HFollowUpRepository;
    private readonly IMapper _mapper;

    public ActionPlain5W2HFollowUpService(IActionPlain5W2HFollowUpRepository actionPlain5W2HFollowUpRepository, IMapper mapper)
    {
        _actionPlain5W2HFollowUpRepository = actionPlain5W2HFollowUpRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(ActionPlain5W2HFollowUpFilter filter)
    {
        var exists = await _actionPlain5W2HFollowUpRepository.CheckIfExists(x => x.ActionPlain5W2HId == filter.ActionPlain5W2HId);
        return exists;
    }

    public async Task<ActionPlain5W2HFollowUpDto> CreateAsync(ActionPlain5W2HFollowUpInsertDto entity)
    {
        if (await CheckIfExists(new ActionPlain5W2HFollowUpFilter() { ActionPlain5W2HId = entity.ActionPlain5W2HId }))
            throw new ActionPlain5W2HFollowUpAlreadyExistsException();

        var department = new ActionPlain5W2HFollowUp(entity.ActionPlain5W2HId, entity.Annotation);
        return _mapper.Map<ActionPlain5W2HFollowUpDto>(await _actionPlain5W2HFollowUpRepository.CreateAsync(department));
    }

    public async Task<ActionPlain5W2HFollowUpDto> DeleteAsync(long id)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpRepository.GetAsync(id);

        if (actionPlain5W2HFollowUp is null)
            throw new ActionPlain5W2HFollowUpNotFoundException();
        
        return _mapper.Map<ActionPlain5W2HFollowUpDto>(await _actionPlain5W2HFollowUpRepository.DeleteAsync(actionPlain5W2HFollowUp));
    }

    public async Task<IEnumerable<ActionPlain5W2HFollowUpDto>> GetAllAsync(ActionPlain5W2HFollowUpFilter filter)
    {
        Expression<Func<ActionPlain5W2HFollowUp, bool>> expressionFilter =
            x => (
                (!filter.Id.HasValue || x.Id == filter.Id.Value)
                && (!filter.ActionPlain5W2HId.HasValue || x.Id == filter.ActionPlain5W2HId.Value)
                && (!filter.CreatedById.HasValue || x.Id == filter.CreatedById.Value)
                && (!filter.UpdatedById.HasValue || x.Id == filter.UpdatedById.Value)
            );

        IEnumerable<ActionPlain5W2HFollowUp> departments = await _actionPlain5W2HFollowUpRepository.GetAllAsync(expressionFilter);

        if (departments is null)
            throw new ActionPlain5W2HFollowUpNotFoundException();

        return _mapper.Map<IEnumerable<ActionPlain5W2HFollowUpDto>>(departments);
    }

    public async Task<ActionPlain5W2HFollowUpDto> GetAsync(long id)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpRepository.GetAsync(id);

        if (actionPlain5W2HFollowUp is null)
            throw new ActionPlain5W2HFollowUpNotFoundException();

        return _mapper.Map<ActionPlain5W2HFollowUpDto>(actionPlain5W2HFollowUp);
    }

    public async Task<ActionPlain5W2HFollowUpDto> UpdateAsync(long id, ActionPlain5W2HFollowUpUpdateDto entity)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpRepository.GetAsync(id);

        if (actionPlain5W2HFollowUp is null)
            throw new ActionPlain5W2HFollowUpNotFoundException();

        if (await CheckIfExists(new ActionPlain5W2HFollowUpFilter() { ActionPlain5W2HId = entity.ActionPlain5W2HId }))
            throw new DepartmentAlreadyExistsException();

        actionPlain5W2HFollowUp.Update(entity.ActionPlain5W2HId, entity.Annotation);
        return _mapper.Map<ActionPlain5W2HFollowUpDto>(await _actionPlain5W2HFollowUpRepository.UpdateAsync(actionPlain5W2HFollowUp));
    }
}
