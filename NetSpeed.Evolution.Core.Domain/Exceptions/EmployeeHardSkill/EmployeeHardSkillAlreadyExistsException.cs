namespace NetSpeed.Evolution.Core.Domain.Exceptions.EmployeeHardSkill;

public class EmployeeHardSkillAlreadyExistsException : EmployeeHardSkillException
{
    public EmployeeHardSkillAlreadyExistsException(string message = DefaultMessages.EmployeeHardSkillAlreadyExists) : base(message) { }
}
