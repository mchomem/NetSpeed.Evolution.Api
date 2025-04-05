namespace NetSpeed.Evolution.Core.Application.Interfaces
{
    public interface IEmployeeTaskService
    {
        public Task<IEnumerable<EmployeeTaskDto>> GetAllTasksManagerEmployeeAsync(long employeeId, long cycleId);
        public Task<IEnumerable<EmployeeTaskDto>> GetAllTasksEmployeeAsync(long employeeId, long cycleId);
    }
}
