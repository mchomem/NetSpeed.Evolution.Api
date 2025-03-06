namespace NetSpeed.Evolution.Core.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() { }

    protected BaseEntity(long id)
    {
        Id = id;
    }

    public long Id { get; private set; }
}
