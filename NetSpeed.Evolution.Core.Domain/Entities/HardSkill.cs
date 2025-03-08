namespace NetSpeed.Evolution.Core.Domain.Entities;

public class HardSkill : BaseEntity
{
    private HardSkill() { }

    public HardSkill(string name)
    {
        Name = name;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name)
    {
        Name = name;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
