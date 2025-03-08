namespace NetSpeed.Evolution.Core.Application.DTOs;

public class HardSkillDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}

public class HardSkillInsertDto
{
    public string Name { get; set; }
}

public class HardSkillUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}