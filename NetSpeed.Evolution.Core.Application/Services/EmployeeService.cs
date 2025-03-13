namespace NetSpeed.Evolution.Core.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IJobTitleRepository jobTitleRepository, IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _jobTitleRepository = jobTitleRepository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(EmployeeFilter filter)
    {
        var exists = await _employeeRepository.CheckIfExists(x => x.Name.Equals(filter.Name) && x.RegistrationNumber.Equals(filter.RegistrationNumber));
        return exists;
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeInsertDto entity)
    {
        var jobTitle = await _jobTitleRepository.GetAsync(entity.JobTitleId);
        var department = await _departmentRepository.GetAsync(entity.DepartmentId);

        if (entity.ManagerId.HasValue)
        {
            var manager = await _employeeRepository.GetAsync(entity.ManagerId.Value);

            if (manager is null)
                throw new EmployeeNotFoundException("Employee manager not found");
        }

        if (jobTitle is null)
            throw new JobTitleNotFoundException();

        if (department is null)
            throw new DepartmentNotFoundException();

        if (await CheckIfExists(new EmployeeFilter() { RegistrationNumber = entity.RegistrationNumber }))
            throw new EmployeeAlreadyExistsException();

        var employee = new Employee(entity.Name, entity.Email, entity.RegistrationNumber, entity.ManagerId, entity.JobTitleId, entity.DepartmentId);
        return _mapper.Map<EmployeeDto>(await _employeeRepository.CreateAsync(employee));
    }

    public async Task<EmployeeDto> DeleteAsync(long id)
    {
        var employee = await _employeeRepository.GetAsync(id);

        if (employee is null)
            throw new EmployeeNotFoundException();

        employee.Delete();
        return _mapper.Map<EmployeeDto>(await _employeeRepository.UpdateAsync(employee));
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync(EmployeeFilter filter)
    {
        Expression<Func<Employee, bool>> expressionFilter =
            x => (
                (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name))
                && (!x.IsDeleted)
            );

        IEnumerable<string> includes = new List<string> { nameof(JobTitle), nameof(Department), "Manager" };
        IEnumerable<Employee> employees = await _employeeRepository.GetAllAsync(expressionFilter, includes);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> GetAsync(long id)
    {
        var employee = await _employeeRepository.GetAsync(id);

        if (employee is null)
            throw new EmployeeNotFoundException();

        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> UpdateAsync(long id, EmployeeUpdateDto entity)
    {
        var employee = await _employeeRepository.GetAsync(entity.Id);
        var jobTitle = await _jobTitleRepository.GetAsync(entity.JobTitleId);
        var department = await _departmentRepository.GetAsync(entity.DepartmentId);

        if (entity.ManagerId.HasValue)
        {
            var manager = await _employeeRepository.GetAsync(entity.ManagerId.Value);

            if (manager is null)
                throw new EmployeeNotFoundException("Employee manager not found");
        }

        if (employee is null)
            throw new EmployeeNotFoundException();

        if (jobTitle is null)
            throw new JobTitleNotFoundException();

        if (department is null)
            throw new DepartmentNotFoundException();

        // A matrícula do colaborador não pode ser usada novamente.
        if (await CheckIfExists(new EmployeeFilter() { RegistrationNumber = entity.RegistrationNumber }))
            throw new EmployeeAlreadyExistsException();

        employee.Update(entity.Name, entity.Email, entity.RegistrationNumber, entity.ManagerId, entity.JobTitleId, entity.DepartmentId);

        return _mapper.Map<EmployeeDto>(await _employeeRepository.UpdateAsync(employee));
    }
}
