namespace NetSpeed.Evolution.Core.Domain.Exceptions.Cycle;

public class CycleAlreadyExistsException : CycleException
{
    public CycleAlreadyExistsException(string message = DefaultMessages.CycleAlreadyExists) : base(message) { }
}
