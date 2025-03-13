namespace NetSpeed.Evolution.Core.Domain.Entities;

public class HardSkill : BaseEntity
{
    private HardSkill() { }

    public HardSkill(string name)
    {
        Name = name;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name)
    {
        if(IsDeleted)        
            throw new HardSkillDeletedRecordHandlingException();

        Name = name;
    }

    public void Delete()
    {
        if (IsDeleted)
            throw new HardSkillDeletedRecordHandlingException();

        IsDeleted = true;
    }

    #region Navigation Properties

    public ICollection<EmployeeHardSkill> EmployeeHardSkills { get; private set; }

    #endregion
}
