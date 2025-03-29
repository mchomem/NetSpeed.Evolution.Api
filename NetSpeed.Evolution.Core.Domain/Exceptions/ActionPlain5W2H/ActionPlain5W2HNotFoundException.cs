namespace NetSpeed.Evolution.Core.Domain.Exceptions.ActionPlain5W2H;

public class ActionPlain5W2HNotFoundException : ActionPlain5W2HException
{
    public ActionPlain5W2HNotFoundException(string message = DefaultMessages.ActionPlain5W2HNotFound) : base(message) { }
}
