namespace NetSpeed.Evolution.Core.Domain.Exceptions.EmployeeHardSkill;

public class EmployeeHardSkillNotFoundException : EmployeeHardSkillException
{
    public EmployeeHardSkillNotFoundException(string message = DefaultMessages.EmployeeHardSkillNotFound) : base(message) { }
}
