namespace NetSpeed.Evolution.Core.Domain.Entities;

public class HardSkill : BaseEntity
{
    public HardSkill(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name)
    {
        Name = name;
    }

    public void Deleted()
    {
        IsDeleted = true;
    }
}
