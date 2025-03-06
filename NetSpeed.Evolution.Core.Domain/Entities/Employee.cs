namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Employee : BaseEntity
{
    private Employee() { }

    public Employee(string name, string email, string registrationNumber, long managerId)
    {
        Name = name;
        Email = email;
        RegistrationNumber = registrationNumber;
        ManagerId = managerId;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string RegistrationNumber { get; private set; }
    public long ManagerId { get; private set; }

    public void Update(string name, string email, string registrationNumber, long managerId)
    {
        Name = name;
        Email = email;
        RegistrationNumber = registrationNumber;
        ManagerId = managerId;
    }

    #region Navigation Properties

    public Employee Manager { get; private set; }

    #endregion
}
