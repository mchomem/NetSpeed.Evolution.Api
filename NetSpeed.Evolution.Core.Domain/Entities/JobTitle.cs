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
        if (IsDeleted)
            throw new JobTitleDeletedRecordHandlingException();

        Name = name;
    }

    public void Delete()
    {
        if(IsDeleted)
            throw new JobTitleDeletedRecordHandlingException();

        IsDeleted = true;
    }

    #region Navigation Properties

    public ICollection<Employee> Employees { get; private set; }

    #endregion
}
