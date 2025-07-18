namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CypherController : ControllerBase
{
    private readonly ICypherService _cypherService;

    public CypherController(ICypherService cypherService)
    {
        _cypherService = cypherService;
    }

#if DEBUG

    [HttpGet("encrypt")]
    public ActionResult<string> GetEncrypt(string value)
    {
        var result = _cypherService.Encrypt(value);
        return Ok(result);
    }

    [HttpGet("decrypt")]

    public ActionResult<string> GetDecrypt(string value)
    {
        var result = _cypherService.Decrypt(value);
        return Ok(result);
    }

#endif
}
