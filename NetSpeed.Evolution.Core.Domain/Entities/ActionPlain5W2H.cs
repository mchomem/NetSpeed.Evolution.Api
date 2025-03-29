using Microsoft.VisualBasic;

namespace NetSpeed.Evolution.Core.Domain.Entities;

public class ActionPlain5W2H : BaseEntity
{
    private ActionPlain5W2H() { }

    public ActionPlain5W2H(long employeeId, long cycleId, string improvementPoint, string what, string who, string why, string where, string when, string how, string howMuch, string observation)
    {
        EmployeeId = employeeId;
        CycleId = cycleId;
        ImprovementPoint = improvementPoint;
        What = what;
        Who = who;
        Why = why;
        Where = where;
        When = when;
        How = how;
        HowMuch = howMuch;
        Observation = observation;
        CreatedAt = DateTime.Now;
    }

    public long EmployeeId { get; private set; }
    public long CycleId { get; private set; }
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
    public DateTime? UpdatedAt { get; private set; }

    #region Navigation Properties

    public Employee Employee { get; private set; }
    public Cycle Cycle { get; private set; }

    #endregion

    public void Update(long employeeId, string improvementPoint, string what, string who, string why, string where, string when, string how, string howMuch, string observation)
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
        UpdatedAt = DateTime.Now;
    }
}
