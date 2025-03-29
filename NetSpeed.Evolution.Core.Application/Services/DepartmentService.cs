namespace NetSpeed.Evolution.Core.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckIfExists(DepartmentFilter filter)
    {
        var exists = await _departmentRepository.CheckIfExists(x => x.Name.Equals(filter.Name));
        return exists;
    }

    public async Task<DepartmentDto> CreateAsync(DepartmentInsertDto entity)
    {
        if (await CheckIfExists(new DepartmentFilter() { Name = entity.Name }))
            throw new DepartmentAlreadyExistsException();

        var department = new Department(entity.Name);
        return _mapper.Map<DepartmentDto>(await _departmentRepository.CreateAsync(department));
    }

    public async Task<DepartmentDto> DeleteAsync(long id)
    {
        var department = await _departmentRepository.GetAsync(id);

        if (department is null)
            throw new DepartmentNotFoundException();

        department.Delete();
        return _mapper.Map<DepartmentDto>(await _departmentRepository.UpdateAsync(department));
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync(DepartmentFilter filter)
    {
        Expression<Func<Department, bool>> expressionFilter =
            x => (
                (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name))
                && (!x.IsDeleted)
            );

        IEnumerable<Department> departments = await _departmentRepository.GetAllAsync(expressionFilter);

        if (departments is null)
            throw new DepartmentNotFoundException();

        return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task<DepartmentDto> GetAsync(long id)
    {
        var department = await _departmentRepository.GetAsync(id);

        if(department is null)
            throw new DepartmentNotFoundException();

        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<DepartmentDto> UpdateAsync(long id, DepartmentUpdateDto entity)
    {
        var department = await _departmentRepository.GetAsync(id);

        if (department is null)
            throw new DepartmentNotFoundException();

        if (await CheckIfExists(new DepartmentFilter() { Name = entity.Name }))
            throw new DepartmentAlreadyExistsException();

        department.Update(entity.Name);
        return _mapper.Map<DepartmentDto>(await _departmentRepository.UpdateAsync(department));
    }
}
