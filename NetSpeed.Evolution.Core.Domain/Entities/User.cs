namespace NetSpeed.Evolution.Core.Domain.Entities;

public class User : BaseEntity
{
    private User() { }

    public User(string login, string password)
    {
        CheckPassword(password);

        Login = login;
        Password = password;
        Blocked = false;
    }

    public string Login { get; private set; }
    public string Password { get; private set; }
    public bool Blocked { get; private set; }

    #region Navigation Properties

    public Employee? Employee { get; private set; }
    public ICollection<Swot> SwotsCreatedByUser { get; private set; }
    public ICollection<Swot> SwotsUpdatedByUser { get; private set; }

    #endregion

    public void ChangePassword(string password)
    {
        CheckPassword(password);
        Password = password;
    }

    public void CheckPassword(string password)
    {
        var maxLength = 8;

        if (password.Length < maxLength)
            throw new UserPasswordInsufficientLengthException($"Password must contain more than {maxLength} characters");

        var regexStringOnly = new Regex("[a-zZ-Z]");

        if (!regexStringOnly.IsMatch(password))
            throw new UserPasswordWithoutLettersException();

        var regexNumberOnly = new Regex(@".*\d");

        if (!regexNumberOnly.IsMatch(password))
            throw new UserPasswordWithoutNumbersException();
    }

    public void Block()
    {
        Blocked = true;
    }
}
