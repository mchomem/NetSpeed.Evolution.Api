namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] EmployeeFilter filter)
    {
        var employees = await _employeeService.GetAllAsync(filter);

        if (!employees.Any())
            return NotFound(new ApiResponse<IEnumerable<EmployeeDto>>(null!, DefaultMessages.EmployeeNotFound));

        return Ok(new ApiResponse<IEnumerable<EmployeeDto>>(employees));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var employee = await _employeeService.GetAsync(id);

        if (employee is null)
            return NotFound(new ApiResponse<IEnumerable<EmployeeDto>>(null!, DefaultMessages.EmployeeNotFound));

        return Ok(new ApiResponse<EmployeeDto>(employee));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] EmployeeInsertDto emlpoyeeDto)
    {
        var employee = await _employeeService.CreateAsync(emlpoyeeDto);
        return Ok(new ApiResponse<EmployeeDto>(employee));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] EmployeeUpdateDto emlpoyeeDto)
    {
        var employee = await _employeeService.UpdateAsync(id, emlpoyeeDto);
        return Ok(new ApiResponse<EmployeeDto>(employee));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var employee = await _employeeService.DeleteAsync(id);
        return Ok(new ApiResponse<EmployeeDto>(employee));
    }
}
