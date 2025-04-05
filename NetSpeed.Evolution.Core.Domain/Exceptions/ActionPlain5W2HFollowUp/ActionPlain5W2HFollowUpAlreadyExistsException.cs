namespace NetSpeed.Evolution.Core.Domain.Exceptions.ActionPlain5W2HFollowUp;

public class ActionPlain5W2HFollowUpAlreadyExistsException : ActionPlain5W2HFollowUpException
{
    public ActionPlain5W2HFollowUpAlreadyExistsException(string message = DefaultMessages.ActionPlain5W2HFollowUpAlreadyExists) : base(message) { }
}
