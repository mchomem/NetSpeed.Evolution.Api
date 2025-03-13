namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Employee : BaseEntity
{
    private Employee() { }

    public Employee(string name, string email, string registrationNumber, long? managerId, long jobTitleId, long departmentId)
    {
        Name = name;
        Email = email;
        RegistrationNumber = registrationNumber;
        ManagerId = managerId;
        JobTitleId = jobTitleId;
        DepartmentId = departmentId;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string RegistrationNumber { get; private set; }
    public long? ManagerId { get; private set; }
    public long JobTitleId { get; private set; }
    public long DepartmentId { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name, string email, string registrationNumber, long? managerId, long jobTitleId, long departmentId)
    {
        Name = name;
        Email = email;
        RegistrationNumber = registrationNumber;
        ManagerId = managerId;
        JobTitleId = jobTitleId;
        DepartmentId = departmentId;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    #region Navigation Properties

    public Employee Manager { get; private set; }

    public JobTitle JobTitle { get; private set; }

    public Department Department { get; private set; }

    public ICollection<Employee> Subordinates { get; private set; }

    public ICollection<EmployeeHardSkill> EmployeeHardSkills { get; private set; }

    #endregion
}
