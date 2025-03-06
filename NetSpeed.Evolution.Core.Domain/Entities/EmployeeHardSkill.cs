namespace NetSpeed.Evolution.Core.Domain.Entities;

public class EmployeeHardSkill
{
    public EmployeeHardSkill(long employeeId, long hardSkillId, HardSkillLevel level)
    {
        EmployeeId = employeeId;
        HardSkillId = hardSkillId;
        Level = level;
    }

    public long EmployeeId { get; private set; }
    public long HardSkillId { get; private set; }
    public HardSkillLevel Level { get; private set; }

    #region Navigation Properties

    public Employee Employee { get; private set; }
    public HardSkill HardSkill { get; private set; }

    #endregion
}
