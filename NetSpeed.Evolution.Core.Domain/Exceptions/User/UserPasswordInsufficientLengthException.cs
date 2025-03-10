namespace NetSpeed.Evolution.Core.Domain.Exceptions.User;

public class UserPasswordInsufficientLengthException : UserException
{
    public UserPasswordInsufficientLengthException(string message = DefaultMessages.UserPasswordInsufficientLength) : base(message) { }
}
