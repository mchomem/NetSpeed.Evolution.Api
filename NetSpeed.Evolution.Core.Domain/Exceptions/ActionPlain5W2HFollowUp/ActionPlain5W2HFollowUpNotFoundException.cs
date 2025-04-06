namespace NetSpeed.Evolution.Core.Domain.Exceptions.ActionPlain5W2HFollowUp;

public class ActionPlain5W2HFollowUpNotFoundException : ActionPlain5W2HException
{
    public ActionPlain5W2HFollowUpNotFoundException(string message = DefaultMessages.ActionPlain5W2HFollowUpNotFound) : base(message) { }
}
