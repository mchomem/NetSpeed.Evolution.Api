namespace NetSpeed.Evolution.Core.Application.DTOs;

public class WeaknessDto
{
    public long Id { get; set; }
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class WeaknessInsertDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
