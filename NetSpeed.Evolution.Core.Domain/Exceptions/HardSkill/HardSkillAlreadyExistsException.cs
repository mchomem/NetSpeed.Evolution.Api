namespace NetSpeed.Evolution.Core.Domain.Exceptions.HardSkill
{
    public class HardSkillAlreadyExistsException : HardSkillException
    {
        public HardSkillAlreadyExistsException(string message = DefaultMessages.HardSkillAlreadyExists) : base(message) { }
    }
}
