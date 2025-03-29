namespace NetSpeed.Evolution.Core.Application.DTOs;

public class OpportunityDto
{
    public long Id { get; set; }
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class OpportunityInsertDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class OpportunityUpdateDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
