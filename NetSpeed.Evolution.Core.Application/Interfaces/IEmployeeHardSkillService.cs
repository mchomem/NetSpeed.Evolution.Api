namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IEmployeeHardSkillService
{
    public Task<bool> CheckIfExists(EmployeeHardSkillFilter filter);
    public Task<EmployeeHardSkillDto> CreateAsync(EmployeeHardSkillInsertDto entity);
    public Task<EmployeeHardSkillDto> DeleteAsync(long employeeId, long hardSkillId);
    public Task<EmployeeHardSkillDto> GetAsync(long employeeId, long hardSkillId);
    public Task<IEnumerable<EmployeeHardSkillDto>> GetAllAsync(EmployeeHardSkillFilter filter);
    public Task<EmployeeHardSkillDto> UpdateAsync(long employeeId, long hardSkillId, EmployeeHardSkillUpdateDto entity);
}
