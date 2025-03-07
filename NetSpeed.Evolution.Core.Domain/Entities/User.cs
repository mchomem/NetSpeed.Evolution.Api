namespace NetSpeed.Evolution.Core.Domain.Entities;

public class User : BaseEntity
{
    private User() { }

    public User(string name, string password, bool blocked)
    {
        Name = name;
        Password = password;
        Blocked = false;
    }

    public string Name { get; private set; }
    public string Password { get; private set; }
    public bool Blocked { get; private set; }

    public void Update(string name, bool blocked)
    {
        Name = name;
        Blocked = blocked;
    }

    public void Block()
    {
        Blocked = true;
    }
}
