namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IHardSkillRepository
{
    public Task<HardSkill> CreateAsync(HardSkill entity);
    public Task<HardSkill> DeleteAsync(HardSkill entity);
    public Task<HardSkill> GetAsync(long id);
    public Task<IEnumerable<HardSkill>> GetAllAsync(Expression<Func<HardSkill, bool>> filter, IEnumerable<string>? includes = null);
    public Task<HardSkill> UpdateAsync(HardSkill entity);
    public Task<bool> CheckIfExists(Expression<Func<HardSkill, bool>> filter);
}
