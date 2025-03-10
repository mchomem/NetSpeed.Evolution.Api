namespace NetSpeed.Evolution.Core.Domain.Exceptions.User
{
    public class UserPasswordWithoutNumbersException : UserException
    {
        public UserPasswordWithoutNumbersException(string message = DefaultMessages.UserPasswordWithoutNumbers) : base(message) { }
    }
}
