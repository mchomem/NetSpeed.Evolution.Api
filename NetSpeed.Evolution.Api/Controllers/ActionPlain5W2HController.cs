namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActionPlain5W2HController : ControllerBase
{
    private readonly IActionPlain5W2HService _actionPlain5W2HService;

    public ActionPlain5W2HController(IActionPlain5W2HService actionPlain5W2HService)
    {
        _actionPlain5W2HService = actionPlain5W2HService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] ActionPlain5W2HFilter filter)
    {
        var actionPlain5W2Hs = await _actionPlain5W2HService.GetAllAsync(filter);
        return Ok(new ApiResponse<IEnumerable<ActionPlain5W2HDto>>(actionPlain5W2Hs));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var actionPlain5W2H = await _actionPlain5W2HService.GetAsync(id);
        return Ok(new ApiResponse<ActionPlain5W2HDto>(actionPlain5W2H));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ActionPlain5W2HInsertDto actionPlain5W2HDto)
    {
        var actionPlain5W2H = await _actionPlain5W2HService.CreateAsync(actionPlain5W2HDto);
        return Ok(new ApiResponse<ActionPlain5W2HDto>(actionPlain5W2H));
    }

    [HttpPost("many")]
    public async Task<IActionResult> PostManyAsync([FromBody] IEnumerable<ActionPlain5W2HInsertDto> actionPlain5W2HDto)
    {
        var actionPlain5W2H = await _actionPlain5W2HService.CreateManyAsync(actionPlain5W2HDto);
        return Ok(new ApiResponse<IEnumerable<ActionPlain5W2HDto>>(actionPlain5W2H));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] ActionPlain5W2HUpdateDto actionPlain5W2HDto)
    {
        var actionPlain5W2H = await _actionPlain5W2HService.UpdateAsync(id, actionPlain5W2HDto);
        return Ok(new ApiResponse<ActionPlain5W2HDto>(actionPlain5W2H));
    }
}
