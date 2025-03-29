namespace NetSpeed.Evolution.Core.Application.DTOs;

public class SwotDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long CreatedById { get; set; }
    public long? UpdatedById { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public SwotStatus Status { get; set; }
    public long CycleId { get; set; }
    public EmployeeDto Employee { get; set; }
    public UserDto CreatedBy { get; set; }
    public UserDto UpdatedBy { get; set; }
    public CycleDto Cycle { get; set; }
    public IEnumerable<StrengthDto> Strengths { get; set; }
    public IEnumerable<OpportunityDto> Opportunities { get; set; }
    public IEnumerable<WeaknessDto> Weaknesses { get; set; }
    public IEnumerable<ThreatDto> Threats { get; set; }
}

public class SwotInsertDto
{
    public long EmployeeId { get; set; }
    public long CreatedById { get; set; }
    public long CycleId { get; set; }
    public IEnumerable<StrengthInsertDto> Strengths { get; set; }
    public IEnumerable<OpportunityInsertDto> Opportunities { get; set; }
    public IEnumerable<WeaknessInsertDto> Weaknesses { get; set; }
    public IEnumerable<ThreatInsertDto> Threats { get; set; }
}

public class SwotUpdateDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long UpdatedById { get; set; }
    public SwotStatus Status { get; set; }
    public IEnumerable<StrengthUpdateDto> Strengths { get; set; }
    public IEnumerable<OpportunityUpdateDto> Opportunities { get; set; }
    public IEnumerable<WeaknessUpdateDto> Weaknesses { get; set; }
    public IEnumerable<ThreatUpdateDto> Threats { get; set; }
}
