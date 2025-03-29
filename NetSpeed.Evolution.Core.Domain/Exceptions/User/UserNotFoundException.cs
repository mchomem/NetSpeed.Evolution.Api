namespace NetSpeed.Evolution.Core.Domain.Exceptions.User;

public class UserNotFoundException : UserException
{
    public UserNotFoundException(string message = DefaultMessages.UserNotFound) : base(message) { }
}
