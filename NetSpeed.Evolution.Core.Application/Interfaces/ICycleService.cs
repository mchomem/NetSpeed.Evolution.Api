namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface ICycleService
{
    public Task<bool> CheckIfExists(CycleFilter filter);
    public Task<CycleDto> CreateAsync(CycleInsertDto entity);
    public Task<CycleDto> GetAsync(long id);
    public Task<IEnumerable<CycleDto>> GetAllAsync(CycleFilter filter);
    public Task<CycleDto> UpdateAsync(long id, CycleUpdateDto entity);
    public Task<CycleDto> DeactivateAsync(long id);
}
