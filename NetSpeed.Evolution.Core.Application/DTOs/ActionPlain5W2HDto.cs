namespace NetSpeed.Evolution.Core.Application.DTOs;

public class ActionPlain5W2HDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long CycleId { get; set; }
    public string ImprovementPoint { get; set; }
    public string What { get; set; }
    public string Who { get; set; }
    public string Why { get; set; }
    public string Where { get; set; }
    public string When { get; set; }
    public string How { get; set; }
    public string HowMuch { get; set; }
    public string Observation { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EmployeeDto Employee { get; set; }
    public CycleDto Cycle { get; set; }
}

public class ActionPlain5W2HInsertDto
{
    public long EmployeeId { get; set; }
    public long CycleId { get; set; }
    public string ImprovementPoint { get; set; }
    public string What { get; set; }
    public string Who { get; set; }
    public string Why { get; set; }
    public string Where { get; set; }
    public string When { get; set; }
    public string How { get; set; }
    public string HowMuch { get; set; }
    public string Observation { get; set; }
}

public class ActionPlain5W2HUpdateDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long CycleId { get; set; }
    public string ImprovementPoint { get; set; }
    public string What { get; set; }
    public string Who { get; set; }
    public string Why { get; set; }
    public string Where { get; set; }
    public string When { get; set; }
    public string How { get; set; }
    public string HowMuch { get; set; }
    public string Observation { get; set; }
}
