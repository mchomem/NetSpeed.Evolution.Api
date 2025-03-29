namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Swot : BaseEntity
{
    private Swot() { }

    public Swot(long employeeId, long createdById, ICollection<Strength> strengths, ICollection<Opportunity> opportunities, ICollection<Weakness> weaknesses, ICollection<Threat> threats, long cycleId)
    {
        EmployeeId = employeeId;
        CreatedById = createdById;
        CreatedAt = DateTime.UtcNow;
        Status = SwotStatus.Available;
        Strengths = strengths;
        Opportunities = opportunities;
        Weaknesses = weaknesses;
        Threats = threats;
        CycleId = cycleId;
    }

    public long EmployeeId { get; private set; }
    public long CreatedById { get; private set; }
    public long? UpdatedById { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public SwotStatus Status { get; private set; }
    public long CycleId { get; private set; }

    #region Navigation Properties

    public Employee Employee { get; private set; }
    public User CreatedBy { get; private set; }
    public User UpdatedBy { get; private set; }
    public Cycle Cycle { get; private set; }
    public ICollection<Strength> Strengths { get; private set; }
    public ICollection<Opportunity> Opportunities { get; private set; }
    public ICollection<Weakness> Weaknesses { get; private set; }
    public ICollection<Threat> Threats { get; private set; }

    #endregion

    public void Update(long employeeId, long updatedById, SwotStatus status, ICollection<Strength> strengths, ICollection<Opportunity> opportunities, ICollection<Weakness> weaknesses, ICollection<Threat> threats)
    {
        EmployeeId = employeeId;
        UpdatedById = updatedById;
        UpdatedAt = DateTime.UtcNow;
        Status = status;
        Strengths = strengths;
        Opportunities = opportunities;
        Weaknesses = weaknesses;
        Threats = threats;
    }

    public void Completed()
    {
        // TODO: verificar o ciclo de estados que não podem ser feridos.
        Status = SwotStatus.Completed;
    }
}
