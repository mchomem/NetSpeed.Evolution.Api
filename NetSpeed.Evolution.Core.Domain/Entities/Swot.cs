namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Swot : BaseEntity
{
    private Swot() { }

    public Swot(long employeeId, string strengths, string weaknesses, string opportunities, string threats, long createdById)
    {
        EmployeeId = employeeId;
        Strengths = strengths;
        Weaknesses = weaknesses;
        Opportunities = opportunities;
        Threats = threats;
        CreatedById = createdById;
        CreatedAt = DateTime.UtcNow;
        Status = SwotStatus.Available;
    }

    public long EmployeeId { get; private set; }
    public string Strengths { get; private set; }
    public string Weaknesses { get; private set; }
    public string Opportunities { get; private set; }
    public string Threats { get; private set; }
    public long CreatedById { get; private set; }
    public long? UpdatedById { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public SwotStatus Status { get; private set; }

    #region Navigation Properties

    public Employee Employee { get; private set; }
    public User CreatedBy { get; private set; }
    public User UpdatedBy { get; private set; }

    #endregion

    public void Update(long employeeId, string strengths, string weaknesses, string opportunities, string threats, long updatedById, SwotStatus status)
    {
        EmployeeId = employeeId;
        Strengths = strengths;
        Weaknesses = weaknesses;
        Opportunities = opportunities;
        Threats = threats;
        UpdatedById = updatedById;
        UpdatedAt = DateTime.UtcNow;
        Status = status;
    }

    public void Completed()
    {
        Status = SwotStatus.Completed;
    }
}
