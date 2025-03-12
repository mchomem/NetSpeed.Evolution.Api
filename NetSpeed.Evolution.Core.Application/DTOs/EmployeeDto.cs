namespace NetSpeed.Evolution.Core.Application.DTOs;

public class EmployeeDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string RegistrationNumber { get; set; }
    public long? ManagerId { get; set; }
    public long JobTitleId { get; set; }
    public long DepartmentId { get; set; }
    public bool IsDeleted { get; set; }
}

public class EmployeeInsertDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string RegistrationNumber { get; set; }
    public long? ManagerId { get; set; }
    public long JobTitleId { get; set; }
    public long DepartmentId { get; set; }
}

public class EmployeeUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string RegistrationNumber { get; set; }
    public long? ManagerId { get; set; }
    public long JobTitleId { get; set; }
    public long DepartmentId { get; set; }
}
