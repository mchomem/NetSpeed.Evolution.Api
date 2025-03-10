namespace NetSpeed.Evolution.Core.Domain.Exceptions.HardSkill;

public class HardSkillDeletedRecordHandlingException : HardSkillException
{
    public HardSkillDeletedRecordHandlingException(string message = DefaultMessages.HardSkillDeletedRecordHandling) : base(message) { }
}
