namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeHardSkillController : ControllerBase
{
    private readonly IEmployeeHardSkillService _employeeHardSkillService;
    
    public EmployeeHardSkillController(IEmployeeHardSkillService employeeHardSkillService)
    {
        _employeeHardSkillService = employeeHardSkillService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] EmployeeHardSkillFilter filter)
    {
        var employeeHardSkills = await _employeeHardSkillService.GetAllAsync(filter);

        if (!employeeHardSkills.Any())
            return NotFound(new ApiResponse<IEnumerable<EmployeeHardSkillDto>>(null!, DefaultMessages.EmployeeHardSkillNotFound));

        return Ok(employeeHardSkills);
    }

    [HttpGet("{employeeId}/{hardSkillId}")]
    public async Task<IActionResult> GetActionResultAsync([FromRoute] long employeeId, [FromRoute] long hardSkillId)
    {
        var employeeHardSkill = await _employeeHardSkillService.GetAsync(employeeId, hardSkillId);

        if (employeeHardSkill is null)
            return NotFound(new ApiResponse<EmployeeHardSkillDto>(null!, DefaultMessages.EmployeeHardSkillNotFound));

        return Ok(employeeHardSkill);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] EmployeeHardSkillInsertDto employeeHardSkillDto)
    {
        var employeeHardSkill = await _employeeHardSkillService.CreateAsync(employeeHardSkillDto);
        return Ok(new ApiResponse<EmployeeHardSkillDto>(employeeHardSkill));
    }

    [HttpPut("{employeeId}/{hardSkillId}")]
    public async Task<IActionResult> PutAsync([FromRoute] long employeeId, [FromRoute] long hardSkillId, [FromBody] EmployeeHardSkillUpdateDto employeeHardSkillDto)
    {
        var employeeHardSkill = await _employeeHardSkillService.UpdateAsync(employeeId, hardSkillId, employeeHardSkillDto);
        return Ok(new ApiResponse<EmployeeHardSkillDto>(employeeHardSkill));
    }

    [HttpDelete("{employeeId}/{hardSkillId}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long employeeId, [FromRoute] long hardSkillId)
    {
        var employeeHardSkill = await _employeeHardSkillService.DeleteAsync(employeeId, hardSkillId);
        return Ok(new ApiResponse<EmployeeHardSkillDto>(employeeHardSkill));
    }
}
