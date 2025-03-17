namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IDepartmentRepository
{
    public Task<Department> CreateAsync(Department entity);
    public Task<Department> DeleteAsync(Department entity);
    public Task<Department> GetAsync(long id);
    public Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> filter, IEnumerable<Expression<Func<Department, object>>>? includes = null);
    public Task<Department> UpdateAsync(Department entity);
    public Task<bool> CheckIfExists(Expression<Func<Department, bool>> filter);
}
