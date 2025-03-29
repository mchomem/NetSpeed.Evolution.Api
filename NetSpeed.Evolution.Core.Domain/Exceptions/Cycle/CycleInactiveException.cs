namespace NetSpeed.Evolution.Core.Domain.Exceptions.Cycle;

public class CycleInactiveException : CycleException
{
    public CycleInactiveException(string message = DefaultMessages.CycleInactive) : base(message) { }
}
