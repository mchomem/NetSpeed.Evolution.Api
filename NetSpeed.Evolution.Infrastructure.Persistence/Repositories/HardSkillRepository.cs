namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class HardSkillRepository : IHardSkillRepository
{
    private readonly IRepositoryBase<HardSkill> _repositoryBase;

    public HardSkillRepository(IRepositoryBase<HardSkill> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<HardSkill> CreateAsync(HardSkill entity)
    {
        var hardSkill = await _repositoryBase.CreateAsync(entity);
        return hardSkill;
    }

    public async Task<HardSkill> DeleteAsync(HardSkill entity)
    {
        var hardSkill = await _repositoryBase.DeleteAsync(entity);
        return hardSkill;
    }

    public async Task<IEnumerable<HardSkill>> GetAllAsync(Expression<Func<HardSkill, bool>> filter, IEnumerable<string>? includes = null)
    {
        var hardSkills = await _repositoryBase.GetAllAsync(filter, includes);
        return hardSkills;
    }

    public async Task<HardSkill> GetAsync(long id)
    {
        var hardSkill = await _repositoryBase.GetAsync(id);
        return hardSkill;
    }

    public async Task<HardSkill> UpdateAsync(HardSkill entity)
    {
        var hardSkill = await _repositoryBase.UpdateAsync(entity);
        return hardSkill;
    }

    public async Task<bool> CheckIfExists(Expression<Func<HardSkill, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }
}
