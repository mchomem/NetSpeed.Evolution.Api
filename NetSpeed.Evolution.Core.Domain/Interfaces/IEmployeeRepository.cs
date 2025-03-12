namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee> CreateAsync(Employee entity);
    public Task<Employee> DeleteAsync(Employee entity);
    public Task<Employee> GetAsync(long id);
    public Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter, IEnumerable<string>? includes = null);
    public Task<Employee> UpdateAsync(Employee entity);
    public Task<bool> CheckIfExists(Expression<Func<Employee, bool>> filter);
}
