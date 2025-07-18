namespace NetSpeed.Evolution.Core.Domain.Exceptions.User;

public class UserBlockedException : UserException
{
    public UserBlockedException(string message = DefaultMessages.UserBlocked) : base(message) { }
}
