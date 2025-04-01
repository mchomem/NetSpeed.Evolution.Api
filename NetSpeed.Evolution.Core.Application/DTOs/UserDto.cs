namespace NetSpeed.Evolution.Core.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public bool Blocked { get; set; }
    public EmployeeDto Employee { get; set; }
}

public class UserInsertDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
