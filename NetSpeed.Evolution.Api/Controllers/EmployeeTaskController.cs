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

    [HttpGet("manager")]
    public async Task<IEnumerable<EmployeeTaskDto>> GetManagerTasks(long employeeId, long cycleId)
    {
        var employeeTaskServices = await _employeeTaskService.GetManagerTasks(employeeId, cycleId);
        return employeeTaskServices;
    }
}
