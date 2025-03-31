namespace NetSpeed.Evolution.Core.Application.Interfaces
{
    public interface IEmployeeTaskService
    {
        public Task<IEnumerable<EmployeeTaskDto>> GetManagerTasks(long employeeId, long cycleId);
    }
}
