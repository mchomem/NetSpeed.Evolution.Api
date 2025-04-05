namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IEmployeeTaskRepository
{
    public Task<IEnumerable<EmployeeTask>> GetAllTasksManagerEmployeeAsync(params object[] parameters);
    public Task<IEnumerable<EmployeeTask>> GetAllTasksEmployeeAsync(params object[] parameters);
}
