namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Department : BaseEntity
{
    private Department() { }

    public Department(string name)
    {
        Name = name;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name)
    {
        if (IsDeleted)
            throw new DepartmentDeletedRecordHandlingException();

        Name = name;
    }

    public void Delete()
    {
        if (IsDeleted)
            throw new DepartmentDeletedRecordHandlingException();

        IsDeleted = true;
    }

    #region Navigation Properties

    public ICollection<Employee> Employees { get; private set; }

    #endregion
}
