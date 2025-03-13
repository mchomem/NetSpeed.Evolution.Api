namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class EmployeeHardSkillRepository : IEmployeeHardSkillRepository
{
    private readonly IRepositoryBase<EmployeeHardSkill> _repositoryBase;

    public EmployeeHardSkillRepository(IRepositoryBase<EmployeeHardSkill> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<EmployeeHardSkill, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<EmployeeHardSkill> CreateAsync(EmployeeHardSkill entity)
    {
        var employeeHardSkill = await _repositoryBase.CreateAsync(entity);
        return employeeHardSkill;
    }

    public async Task<EmployeeHardSkill> DeleteAsync(EmployeeHardSkill entity)
    {
        var employeeHardSkill = await _repositoryBase.DeleteAsync(entity);
        return employeeHardSkill;
    }

    public async Task<IEnumerable<EmployeeHardSkill>> GetAllAsync(Expression<Func<EmployeeHardSkill, bool>> filter, IEnumerable<string>? includes = null)
    {
        var employeeHardSkills = await _repositoryBase.GetAllAsync(filter, includes);
        return employeeHardSkills;
    }

    public async Task<EmployeeHardSkill> GetAsync(long id)
    {
        var employeeHardSkill = await _repositoryBase.GetAsync(id);
        return employeeHardSkill;
    }

    public async Task<EmployeeHardSkill> GetAsync(Expression<Func<EmployeeHardSkill, bool>> filter, IEnumerable<string>? includes = null)
    {
        var employeeHardSkill = await _repositoryBase.GetAsync(filter, includes);
        return employeeHardSkill;
    }

    public async Task<EmployeeHardSkill> UpdateAsync(EmployeeHardSkill entity)
    {
        var employeeHardSkill = await _repositoryBase.UpdateAsync(entity);
        return employeeHardSkill;
    }
}
