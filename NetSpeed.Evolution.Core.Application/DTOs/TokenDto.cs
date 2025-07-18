namespace NetSpeed.Evolution.Core.Application.DTOs;

public class TokenDto
{
    public int? UserId { get; set; }
    public string? Value { get; set; }
    public DateTime? ExpiresIn { get; set; }
}
