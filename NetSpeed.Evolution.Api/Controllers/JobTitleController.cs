namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobTitleController : ControllerBase
{
    private readonly IJobTitleService _jobTitleService;

    public JobTitleController(IJobTitleService jobTitleService)
    {
        _jobTitleService = jobTitleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] JobTitleFilter filter)
    {
        var jobTitle = await _jobTitleService.GetAllAsync(filter);
        return Ok(new ApiResponse<IEnumerable<JobTitleDto>>(jobTitle));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var jobTitle = await _jobTitleService.GetAsync(id);
        return Ok(new ApiResponse<JobTitleDto>(jobTitle));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] JobTitleInsertDto jobTitleDto)
    {
        var jobTitle = await _jobTitleService.CreateAsync(jobTitleDto);
        return Ok(new ApiResponse<JobTitleDto>(jobTitle));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] JobTitleUpdateDto jobTitleDto)
    {
        var jobTitle = await _jobTitleService.UpdateAsync(id, jobTitleDto);
        return Ok(new ApiResponse<JobTitleDto>(jobTitle));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        var jobTitle = await _jobTitleService.DeleteAsync(id);
        return Ok(new ApiResponse<JobTitleDto>(jobTitle));
    }
}
