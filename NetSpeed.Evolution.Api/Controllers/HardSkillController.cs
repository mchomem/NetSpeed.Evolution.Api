namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HardSkillController : ControllerBase
{
    private readonly IHardSkillService _hardSkillService;

    public HardSkillController(IHardSkillService hardSkillService)
    {
        _hardSkillService = hardSkillService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] HardSkillFilter filter)
    {
        var hardSkill = await _hardSkillService.GetAllAsync(filter);
        return Ok(new ApiResponse<IEnumerable<HardSkillDto>>(hardSkill));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var hardSkill = await _hardSkillService.GetAsync(id);
        return Ok(new ApiResponse<HardSkillDto>(hardSkill));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] HardSkillInsertDto hardSkillDto)
    {
        var hardSkill = await _hardSkillService.CreateAsync(hardSkillDto);
        return Ok(new ApiResponse<HardSkillDto>(hardSkill));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] HardSkillUpdateDto hardSkillDto)
    {
        var hardSkill = await _hardSkillService.UpdateAsync(id, hardSkillDto);
        return Ok(new ApiResponse<HardSkillDto>(hardSkill));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        var hardSkill = await _hardSkillService.DeleteAsync(id);
        return Ok(new ApiResponse<HardSkillDto>(hardSkill));
    }
}
