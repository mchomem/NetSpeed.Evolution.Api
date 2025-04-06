namespace NetSpeed.Evolution.Core.Application.Services;

public class EmployeeTaskService : IEmployeeTaskService
{
    private readonly IEmployeeTaskRepository _employeeTaskRepository;
    private readonly IMapper _mapper;

    public EmployeeTaskService(IEmployeeTaskRepository employeeTaskRepository, IMapper mapper)
    {
        _employeeTaskRepository = employeeTaskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeTaskDto>> GetAllTasksEmployeeAsync(long employeeId, long cycleId)
    {
        IEnumerable<EmployeeTask> employeeTasks = await _employeeTaskRepository.GetAllTasksEmployeeAsync(employeeId, cycleId);
        return _mapper.Map<IEnumerable<EmployeeTaskDto>>(employeeTasks);
    }

    public async Task<IEnumerable<EmployeeTaskDto>> GetAllTasksManagerEmployeeAsync(long employeeId, long cycleId)
    {
        IEnumerable<EmployeeTask> employeeTasks = await _employeeTaskRepository.GetAllTasksManagerEmployeeAsync(employeeId, cycleId);
        return _mapper.Map<IEnumerable<EmployeeTaskDto>>(employeeTasks);
    }
}
