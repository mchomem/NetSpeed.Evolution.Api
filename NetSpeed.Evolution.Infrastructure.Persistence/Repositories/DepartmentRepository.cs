namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IRepositoryBase<Department> _repositoryBase;

    public DepartmentRepository(IRepositoryBase<Department> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<Department> CreateAsync(Department entity)
    {
        var department = await _repositoryBase.CreateAsync(entity);
        return department;
    }

    public async Task<Department> DeleteAsync(Department entity)
    {
        var department = await _repositoryBase.DeleteAsync(entity);
        return department;
    }

    public async Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> filter, IEnumerable<string>? includes = null)
    {
        var departments = await _repositoryBase.GetAllAsync(filter, includes);
        return departments;
    }

    public async Task<Department> GetAsync(long id)
    {
        var department = await _repositoryBase.GetAsync(id);
        return department;
    }

    public async Task<Department> UpdateAsync(Department entity)
    {
        var department = await _repositoryBase.UpdateAsync(entity);
        return department;
    }
}
