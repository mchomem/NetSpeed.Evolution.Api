namespace NetSpeed.Evolution.Core.Domain.Entities;

public class ActionPlain : BaseEntity
{
    private ActionPlain() { }

    public ActionPlain(long employeeId, string improvementPoint, string what, string who, string why, string where, string when, string how, string howMuch, string observation, DateTime createdAt)
    {
        EmployeeId = employeeId;
        ImprovementPoint = improvementPoint;
        What = what;
        Who = who;
        Why = why;
        Where = where;
        When = when;
        How = how;
        HowMuch = howMuch;
        Observation = observation;
        CreatedAt = createdAt;
    }

    public long EmployeeId { get; private set; }
    public string ImprovementPoint { get; private set; }
    public string What { get; private set; }
    public string Who { get; private set; }
    public string Why { get; private set; }
    public string Where { get; private set; }
    public string When { get; private set; }
    public string How { get; private set; }
    public string HowMuch { get; private set; }
    public string Observation { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    #region Navigation Properties

    public Employee Employee { get; private set; }

    #endregion

    public void Update(long employeeId, string improvementPoint, string what, string who, string why, string where, string when, string how, string howMuch, string observation, DateTime updatedAt)
    {
        EmployeeId = employeeId;
        ImprovementPoint = improvementPoint;
        What = what;
        Who = who;
        Why = why;
        Where = where;
        When = when;
        How = how;
        HowMuch = howMuch;
        Observation = observation;
        UpdatedAt = updatedAt;
    }
}
