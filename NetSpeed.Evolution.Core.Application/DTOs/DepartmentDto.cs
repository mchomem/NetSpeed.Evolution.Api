namespace NetSpeed.Evolution.Core.Application.DTOs;

public class DepartmentDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}

public class DepartmentInsertDto
{
    public string Name { get; set; }
}

public class DepartmentUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
