namespace NetSpeed.Evolution.Core.Domain.Exceptions.HardSkill;

public class HardSkillNotFoundException : HardSkillException
{
    public HardSkillNotFoundException(string message = DefaultMessages.HardSkillNotFound) : base(message) { }
}
