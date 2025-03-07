namespace NetSpeed.Evolution.Core.Domain.Entities;

public class JobTitle : BaseEntity
{
    private JobTitle() { }

    public JobTitle(string name)
    {
        Name = name;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name)
    {
        Name = name;
    }

    public void Deleted()
    {
        IsDeleted = true;
    }

    #region Navigation Properties

    public ICollection<Employee> Employees { get; private set; }

    #endregion
}
