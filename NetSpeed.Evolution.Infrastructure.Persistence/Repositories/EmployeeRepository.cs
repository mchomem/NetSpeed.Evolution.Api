namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IRepositoryBase<Employee> _repositoryBase;

    public EmployeeRepository(IRepositoryBase<Employee> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<bool> CheckIfExists(Expression<Func<Employee, bool>> filter)
    {
        var exists = await _repositoryBase.CheckIfExists(filter);
        return exists;
    }

    public async Task<Employee> CreateAsync(Employee entity)
    {
        var employee = await _repositoryBase.CreateAsync(entity);
        return employee;
    }

    public async Task<Employee> DeleteAsync(Employee entity)
    {
        var employee = await _repositoryBase.DeleteAsync(entity);
        return employee;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter, IEnumerable<string>? includes = null)
    {
        var employees = await _repositoryBase.GetAllAsync(filter, includes);
        return employees;
    }

    public async Task<Employee> GetAsync(long id)
    {
        var employee = await _repositoryBase.GetAsync(id);
        return employee;
    }

    public async Task<Employee> UpdateAsync(Employee entity)
    {
        var employee = await _repositoryBase.UpdateAsync(entity);
        return employee;
    }
}
