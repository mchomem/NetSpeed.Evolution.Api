namespace NetSpeed.Evolution.Core.Domain.Exceptions.User;

public class UserAccessDeniedException : UserException
{
    public UserAccessDeniedException(string message = DefaultMessages.UserAccessDenied) : base(message) { }
}
