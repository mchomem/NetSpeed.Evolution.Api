namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface ITokenService
{
    public Task<TokenDto> GetTokenAsync(UserDto user);
}
