namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IEmployeeHardSkillRepository
{
    public Task<EmployeeHardSkill> CreateAsync(EmployeeHardSkill entity);
    public Task<EmployeeHardSkill> DeleteAsync(EmployeeHardSkill entity);
    public Task<EmployeeHardSkill> GetAsync(long id);
    public Task<EmployeeHardSkill> GetAsync(Expression<Func<EmployeeHardSkill, bool>> filter, IEnumerable<Expression<Func<EmployeeHardSkill, object>>>? includes = null);
    public Task<IEnumerable<EmployeeHardSkill>> GetAllAsync(Expression<Func<EmployeeHardSkill, bool>> filter, IEnumerable<Expression<Func<EmployeeHardSkill, object>>>? includes = null);
    public Task<EmployeeHardSkill> UpdateAsync(EmployeeHardSkill entity);
    public Task<bool> CheckIfExists(Expression<Func<EmployeeHardSkill, bool>> filter);
}
