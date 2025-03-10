namespace NetSpeed.Evolution.Core.Domain.Exceptions.User;

public class UserPasswordWithoutLettersException : UserException
{
    public UserPasswordWithoutLettersException(string message = DefaultMessages.UserPasswordWithoutLetters) : base(message) { }
}
