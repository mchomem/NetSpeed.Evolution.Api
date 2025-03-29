namespace NetSpeed.Evolution.Core.Application.DTOs;

public class CycleDto
{
    public long Id { get; set; }
    public int Year { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CycleInsertDto
{
    public int Year { get; set; }
}

public class CycleUpdateDto
{
    public long Id { get; set; }
    public int Year { get; set; }
}
