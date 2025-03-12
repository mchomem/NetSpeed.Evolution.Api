namespace NetSpeed.Evolution.Core.Application.Filters;

public class EmployeeFilter
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? RegistrationNumber { get; set; }
    public long? ManagerId { get; set; }
    public long? JobTitleId { get; set; }
    public long? DepartmentId { get; set; }
}
