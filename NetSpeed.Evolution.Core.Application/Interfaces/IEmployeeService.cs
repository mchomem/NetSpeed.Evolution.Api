namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IEmployeeService
{
    public Task<bool> CheckIfExists(EmployeeFilter filter);
    public Task<EmployeeDto> CreateAsync(EmployeeInsertDto entity);
    public Task<EmployeeDto> DeleteAsync(long id);
    public Task<EmployeeDto> GetAsync(long id);
    public Task<IEnumerable<EmployeeDto>> GetAllAsync(EmployeeFilter filter);
    public Task<EmployeeDto> UpdateAsync(long id, EmployeeUpdateDto entity);
}
