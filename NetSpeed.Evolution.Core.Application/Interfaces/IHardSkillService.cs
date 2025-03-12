namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IHardSkillService
{
    public Task<bool> CheckIfExists(HardSkillFilter filter);
    public Task<HardSkillDto> CreateAsync(HardSkillInsertDto entity);
    public Task<HardSkillDto> DeleteAsync(long id);
    public Task<HardSkillDto> GetAsync(long id);
    public Task<IEnumerable<HardSkillDto>> GetAllAsync(HardSkillFilter filter, IEnumerable<string>? includes = null);
    public Task<HardSkillDto> UpdateAsync(long id, HardSkillUpdateDto entity);
}
