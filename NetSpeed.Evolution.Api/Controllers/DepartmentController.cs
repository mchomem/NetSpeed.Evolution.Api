namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] DepartmentFilter filter)
    {
        var department = await _departmentService.GetAllAsync(filter);

        if (!department.Any())
            return NotFound(new ApiResponse<IEnumerable<DepartmentDto>>(null!, DefaultMessages.DepartmentNotFound));

        return Ok(new ApiResponse<IEnumerable<DepartmentDto>>(department));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var department = await _departmentService.GetAsync(id);

        if (department is null)
            return NotFound(new ApiResponse<IEnumerable<DepartmentDto>>(null!, DefaultMessages.DepartmentNotFound));

        return Ok(new ApiResponse<DepartmentDto>(department));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] DepartmentInsertDto departmentDto)
    {
        var department = await _departmentService.CreateAsync(departmentDto);
        return Ok(new ApiResponse<DepartmentDto>(department));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] DepartmentUpdateDto departmentDto)
    {
        var department = await _departmentService.UpdateAsync(id, departmentDto);
        return Ok(new ApiResponse<DepartmentDto>(department));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var department = await _departmentService.DeleteAsync(id);
        return Ok(new ApiResponse<DepartmentDto>(department));
    }
}
