namespace NetSpeed.Evolution.Core.Application.DTOs;

public class EmployeeHardSkillDto
{
    public long EmployeeId { get; private set; }
    public long HardSkillId { get; private set; }
    public HardSkillLevel Level { get; private set; }
    public EmployeeDto Employee { get; private set; }
    public HardSkillDto HardSkill { get; private set; }
}

public class EmployeeHardSkillInsertDto
{
    public long EmployeeId { get; private set; }
    public long HardSkillId { get; private set; }
    public HardSkillLevel Level { get; private set; }
}

public class EmployeeHardSkillUpdateDto
{
    public long EmployeeId { get; private set; }
    public long HardSkillId { get; private set; }
    public HardSkillLevel Level { get; private set; }
}
