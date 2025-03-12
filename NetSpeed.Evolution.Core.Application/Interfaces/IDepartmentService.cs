namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IDepartmentService
{
    public Task<bool> CheckIfExists(DepartmentFilter filter);
    public Task<DepartmentDto> CreateAsync(DepartmentInsertDto entity);
    public Task<DepartmentDto> DeleteAsync(long id);
    public Task<DepartmentDto> GetAsync(long id);
    public Task<IEnumerable<DepartmentDto>> GetAllAsync(DepartmentFilter filter);
    public Task<DepartmentDto> UpdateAsync(long id, DepartmentUpdateDto entity);
}
