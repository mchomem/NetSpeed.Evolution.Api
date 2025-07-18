namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthController(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> GetLogin(string login, string password)
    {
        UserDto user = await _userService.GetAuthenticateAsync(login, password);
        TokenDto token = await _tokenService.GetTokenAsync(user);
        token.UserId = user.Id;

        var reponse = new ApiResponse<TokenDto>(token);
        return Ok(reponse);
    }
}
