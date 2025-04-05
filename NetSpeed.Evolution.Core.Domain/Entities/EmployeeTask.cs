namespace NetSpeed.Evolution.Core.Domain.Entities;

public class EmployeeTask
{
    public EmployeeTask(long employeeId, long cycleId, string taskDescrption, string employeeTaskType)
    {
        EmployeeId = employeeId;
        CycleId = cycleId;
        TaskDescrption = taskDescrption;
        EmployeeTaskType = employeeTaskType;
    }

    public long EmployeeId { get; private set; }
    public long CycleId { get; private set; }
    public string TaskDescrption { get; private set; }
    public string EmployeeTaskType { get; private set; }
}
