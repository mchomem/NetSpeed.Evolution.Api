namespace NetSpeed.Evolution.Core.Domain.Entities;

public class EmployeeHardSkill
{
    private EmployeeHardSkill() { }

    public EmployeeHardSkill(long employeeId, long hardSkillId, HardSkillLevel level)
    {
        EmployeeId = employeeId;
        HardSkillId = hardSkillId;
        Level = level;
    }

    public long EmployeeId { get; private set; }
    public long HardSkillId { get; private set; }
    public HardSkillLevel Level { get; private set; }

    public void Update(HardSkillLevel level)
    {
        Level = level;
    }

    #region Navigation Properties

    public Employee Employee { get; private set; }
    public HardSkill HardSkill { get; private set; }

    #endregion
}
