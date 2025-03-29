namespace NetSpeed.Evolution.Core.Application.Filters;

public class SwotFilter
{
    public long? EmployeeId { get; set; }
    public SwotStatus Status { get; set; }
    public long? CycleId { get; set; }
    public DateTime? StartCreatedAt { get; set; }
    public DateTime? EndCreatedAt { get; set; }
}
