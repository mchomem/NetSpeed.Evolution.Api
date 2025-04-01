namespace NetSpeed.Evolution.Core.Domain.Entities;

public class ActionPlain5W2HFollowUp : BaseEntity
{
    private ActionPlain5W2HFollowUp() { }

    public ActionPlain5W2HFollowUp(long actionPlain5W2HId, string annotation, DateTime createdAt, DateTime? updatedAt)
    {
        ActionPlain5W2HId = actionPlain5W2HId;
        Annotation = annotation;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public long ActionPlain5W2HId { get; private set; }
    public string Annotation { get; private set; }
    public long CreatedById { get; private set; }
    public long? UpdatedById { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    #region Navigation Properties

    public ActionPlain5W2H ActionPlain5W2H { get; private set; }
    public User CreatedBy { get; private set; }
    public User? UpdatedBy { get; private set; }

    #endregion
}
