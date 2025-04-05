namespace NetSpeed.Evolution.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeTaskController : ControllerBase
{
    private readonly IEmployeeTaskService _employeeTaskService;

    public EmployeeTaskController(IEmployeeTaskService employeeTaskService)
    {
        _employeeTaskService = employeeTaskService;
    }

    [HttpGet("employee")]
    public async Task<IEnumerable<EmployeeTaskDto>> GetAllTasksEmployeeAsync(long employeeId, long cycleId)
    {
        var employeeTaskServices = await _employeeTaskService.GetAllTasksEmployeeAsync(employeeId, cycleId);
        return employeeTaskServices;
    }

    [HttpGet("manager")]
    public async Task<IEnumerable<EmployeeTaskDto>> GetAllTasksManagerEmployeeAsync(long employeeId, long cycleId)
    {
        var employeeTaskServices = await _employeeTaskService.GetAllTasksManagerEmployeeAsync(employeeId, cycleId);
        return employeeTaskServices;
    }
}
