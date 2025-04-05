namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActionPlain5W2HFollowUpController : ControllerBase
{
    private readonly IActionPlain5W2HFollowUpService _actionPlain5W2HFollowUpService;

    public ActionPlain5W2HFollowUpController(IActionPlain5W2HFollowUpService actionPlain5W2HFollowUpService)
    {
        _actionPlain5W2HFollowUpService = actionPlain5W2HFollowUpService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] ActionPlain5W2HFollowUpFilter filter)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpService.GetAllAsync(filter);
        return Ok(new ApiResponse<IEnumerable<ActionPlain5W2HFollowUpDto>>(actionPlain5W2HFollowUp));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpService.GetAsync(id);
        return Ok(new ApiResponse<ActionPlain5W2HFollowUpDto>(actionPlain5W2HFollowUp));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ActionPlain5W2HFollowUpInsertDto actionPlain5W2HFollowUpDto)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpService.CreateAsync(actionPlain5W2HFollowUpDto);
        return Ok(new ApiResponse<ActionPlain5W2HFollowUpDto>(actionPlain5W2HFollowUp));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] ActionPlain5W2HFollowUpUpdateDto actionPlain5W2HFollowUpDto)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpService.UpdateAsync(id, actionPlain5W2HFollowUpDto);
        return Ok(new ApiResponse<ActionPlain5W2HFollowUpDto>(actionPlain5W2HFollowUp));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        var actionPlain5W2HFollowUp = await _actionPlain5W2HFollowUpService.DeleteAsync(id);
        return Ok(new ApiResponse<ActionPlain5W2HFollowUpDto>(actionPlain5W2HFollowUp));
    }
}
