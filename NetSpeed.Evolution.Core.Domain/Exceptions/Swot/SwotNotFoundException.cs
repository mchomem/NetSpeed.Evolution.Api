namespace NetSpeed.Evolution.Core.Domain.Exceptions.Swot;

public class SwotNotFoundException : SwotException
{
    public SwotNotFoundException(string message = DefaultMessages.SwotNotFound) : base(message) { }
}
