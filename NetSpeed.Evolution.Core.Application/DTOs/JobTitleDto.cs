namespace NetSpeed.Evolution.Core.Application.DTOs;

public class JobTitleDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}

public class JobTitleInsertDto
{
    public string Name { get; set; }
}

public class JobTitleUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
