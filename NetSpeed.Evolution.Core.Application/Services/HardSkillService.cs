namespace NetSpeed.Evolution.Core.Application.Services;

public class HardSkillService : IHardSkillService
{
    private readonly IHardSkillRepository _hardSkillRepository;
    private readonly IMapper _mapper;

    public HardSkillService(IHardSkillRepository hardSkillRepository, IMapper mapper)
    {
        _hardSkillRepository = hardSkillRepository;
        _mapper = mapper;
    }

    public async Task<HardSkillDto> CreateAsync(HardSkillInsertDto entity)
    {
        var hardSkill = new HardSkill(entity.Name);
        return _mapper.Map<HardSkillDto>(await _hardSkillRepository.CreateAsync(hardSkill));
    }

    public async Task<HardSkillDto> DeleteAsync(long id)
    {
        var hardSkill = await _hardSkillRepository.GetAsync(id);

        if (hardSkill is null)
            throw new HardSkillNotFoundException();

        hardSkill.Delete();

        return _mapper.Map<HardSkillDto>(await _hardSkillRepository.UpdateAsync(hardSkill));
    }

    public async Task<IEnumerable<HardSkillDto>> GetAllAsync(HardSkillFilter filter, IEnumerable<string>? includes = null)
    {
        Expression<Func<HardSkill, bool>> expressionFilter =
            x => (
                (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name))
                && (!x.IsDeleted)
            );

        IEnumerable<HardSkill> hardSkills = await _hardSkillRepository.GetAllAsync(expressionFilter, includes);
        return _mapper.Map<IEnumerable<HardSkillDto>>(hardSkills);
    }

    public async Task<HardSkillDto> GetAsync(long id)
    {
        var hardSkill = await _hardSkillRepository.GetAsync(id);
        return _mapper.Map<HardSkillDto>(hardSkill);
    }

    public async Task<HardSkillDto> UpdateAsync(long id, HardSkillUpdateDto entity)
    {
        var hardSkill = await _hardSkillRepository.GetAsync(entity.Id);

        if (hardSkill is null)
            throw new HardSkillNotFoundException();

        hardSkill.Update(entity.Name);

        return _mapper.Map<HardSkillDto>(await _hardSkillRepository.UpdateAsync(hardSkill));
    }
}
