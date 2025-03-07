namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IDepartmentService
{
    public Task<DepartmentDto> CreateAsync(DepartmentInsertDto entity);
    public Task<DepartmentDto> DeleteAsync(long id);
    public Task<DepartmentDto> GetAsync(long id);
    public Task<IEnumerable<DepartmentDto>> GetAllAsync(DepartmentFilter filter, IEnumerable<string>? includes = null);
    public Task<DepartmentDto> UpdateAsync(long id, DepartmentUpdateDto entity);
}
