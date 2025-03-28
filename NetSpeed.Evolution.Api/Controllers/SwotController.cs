namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SwotController : ControllerBase
{
    private readonly ISwotService _swotService;

    public SwotController(ISwotService swotService)
    {
        _swotService = swotService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] long employeeId, [FromQuery] long cycleId)
    {
        var swot = await _swotService.GetAsync(employeeId, cycleId);

        if(swot is null)
            return NotFound(new ApiResponse<IEnumerable<SwotDto>>(null!, DefaultMessages.SwotNotFound));

        return Ok(new ApiResponse<SwotDto>(swot));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SwotInsertDto swotDto)
    {
        var swot = await _swotService.CreateAsync(swotDto);
        return Ok(new ApiResponse<SwotDto>(swot));
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(long id, [FromBody] SwotUpdateDto swotDto)
    {
        var swot = await _swotService.UpdateAsync(id, swotDto);
        return Ok(new ApiResponse<SwotDto>(swot));
    }
}
