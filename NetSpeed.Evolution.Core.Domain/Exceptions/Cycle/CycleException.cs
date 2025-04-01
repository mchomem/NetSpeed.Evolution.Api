namespace NetSpeed.Evolution.Core.Domain.Exceptions.Cycle;

public class CycleException : Exception
{
    public CycleException(string message) : base(message) { }
}
