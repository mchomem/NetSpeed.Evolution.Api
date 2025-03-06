namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Swot : BaseEntity
{
    private Swot() { }

    public Swot(long employeeId, string strengths, string weaknesses, string opportunities, string threats, DateTime createdAt, SwotStatus status)
    {
        EmployeeId = employeeId;
        Strengths = strengths;
        Weaknesses = weaknesses;
        Opportunities = opportunities;
        Threats = threats;
        CreatedAt = createdAt;
        Status = status;
    }

    public long EmployeeId { get; private set; }
    public string Strengths { get; private set; }
    public string Weaknesses { get; private set; }
    public string Opportunities { get; private set; }
    public string Threats { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public SwotStatus Status { get; private set; }

    #region Navigation Properties

    public Employee Employee { get; set; }

    #endregion

    public void Update(long employeeId, string strengths, string weaknesses, string opportunities, string threats, DateTime createdAt, DateTime updatedAt, SwotStatus status)
    {
        EmployeeId = employeeId;
        Strengths = strengths;
        Weaknesses = weaknesses;
        Opportunities = opportunities;
        Threats = threats;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Status = status;
    }
}
