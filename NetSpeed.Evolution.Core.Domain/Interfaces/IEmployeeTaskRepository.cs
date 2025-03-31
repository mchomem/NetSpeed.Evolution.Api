namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IEmployeeTaskRepository
{
    public Task<IEnumerable<EmployeeTask>> ExecuteSqlQueryAsync(params object[] parameters);
}
