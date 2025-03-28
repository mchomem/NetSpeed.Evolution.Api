namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Opportunity : BaseEntity
{
    public Opportunity(long swotId, string description, int order)
    {
        SwotId = swotId;
        Description = description;
        Order = order;
    }

    public long SwotId { get; private set; }
    public string Description { get; private set; }
    public int Order { get; private set; }

    #region Navigation Properties

    public Swot Swot { get; private set; }

    #endregion
}
