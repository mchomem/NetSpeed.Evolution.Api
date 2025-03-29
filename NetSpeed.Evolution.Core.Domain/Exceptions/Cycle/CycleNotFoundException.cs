namespace NetSpeed.Evolution.Core.Domain.Exceptions.Cycle
{
    public class CycleNotFoundException : CycleException
    {
        public CycleNotFoundException(string message = DefaultMessages.CycleNotFound) : base(message) { }
    }
}
