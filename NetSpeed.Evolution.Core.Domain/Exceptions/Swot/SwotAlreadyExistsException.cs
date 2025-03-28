namespace NetSpeed.Evolution.Core.Domain.Exceptions.Swot;

public class SwotAlreadyExistsException : SwotException
{
    public SwotAlreadyExistsException(string message = DefaultMessages.SwotAlreadyExists) : base(message) { }
}
