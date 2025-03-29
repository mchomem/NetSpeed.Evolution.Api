namespace NetSpeed.Evolution.Core.Domain.Exceptions.ActionPlain5W2H;

public class ActionPlain5W2HAlreadyExistsException : ActionPlain5W2HException
{
    public ActionPlain5W2HAlreadyExistsException(string message = DefaultMessages.ActionPlain5W2HAlreadyExists) : base(message) { }
}
