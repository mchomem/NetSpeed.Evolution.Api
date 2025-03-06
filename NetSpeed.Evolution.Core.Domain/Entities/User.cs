namespace NetSpeed.Evolution.Core.Domain.Entities;

public class User : BaseEntity
{
    private User() { }

    public User(string name, bool blocked)
    {
        Name = name;
        Blocked = blocked;
    }

    public string Name { get; private set; }
    public bool Blocked { get; private set; }

    public void Update(string name, bool blocked)
    {
        Name = name;
        Blocked = blocked;
    }
}
